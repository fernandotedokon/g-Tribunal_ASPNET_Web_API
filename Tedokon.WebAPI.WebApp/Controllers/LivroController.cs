﻿using System.Linq;
using Tedokon.ListaLivraria.Persistencia;
using Tedokon.ListaLivraria.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tedokon.ListaLivraria.WebApp.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        private readonly IRepository<Livro> _repo;

        public LivroController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View(new LivroUpload());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                _repo.Incluir(model.ToLivro());
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ImagemCapa(int id)
        {
            byte[] img = _repo.All
                .Where(l => l.Id == id)
                .Select(l => l.ImagemCapa)
                .FirstOrDefault();
            if (img != null)
            {
                return File(img, "image/png");
            }
            return File("~/images/capas/capa-vazia.png", "image/png");
        }

        public Livro RecuperaLivro(int id)
        {
            return _repo.Find(id);          
        }

        public ActionResult<LivroUpload> DetalhesJason(int id)
        {
            var model = RecuperaLivro(id);
            if (model == null)
            {
                return NotFound();
            }
            return model.ToModel();
        }


        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Detalhes(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model.ToModel());
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Detalhes(LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                if (model.Capa == null)
                {
                    livro.ImagemCapa = _repo.All
                        .Where(l => l.Id == livro.Id)
                        .Select(l => l.ImagemCapa)
                        .FirstOrDefault();
                }
                _repo.Alterar(livro);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }



        // VIROU API/Recuperar
        //[HttpGet]
        //public IActionResult DetalhesSemHTML (int id)
        //{
        //    var model = _repo.Find(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return Json(model.ToModel()); //View(model.ToModel());
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            var model = _repo.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _repo.Excluir(model);
            return RedirectToAction("Index", "Home");
        }
    }
}