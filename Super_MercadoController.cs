using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Super_Mercado.Services;
using Super_Mercado.Models;

namespace Super_Mercado.Controllers
{

    public class Super_MercadoController : Controller
    {
        private readonly Super_mercadoService _service;

        public Super_MercadoController(Super_mercadoService srv)
        {
            _service = srv;
        }

        public IActionResult Index()
        {
            var productos = _service.GetAll();
            return View(productos);
        }

        public async Task<IActionResult> See(long id)
        {
            Producto result = await _service.GetById(id);
            if (result != null)
            {
                return View(result);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                Producto result = await _service.Create(producto);
                if (result != null)
                {
                    return View(result);
                }
            }
            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public IActionResult Update(long? Id)
        {
            if (Id != null)
            {
                Producto result = _service.GetById(Id).Result;
                if (result != null)
                {
                    return View(result);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Producto producto)
        {
            if (ModelState.IsValid)
            {
                Producto result = await _service.Update(producto);
                if (result !=null)
                {
                    return View(producto +""+"El producto ha sido modificado");
                }
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long Id)
        {
            Producto result = await _service.GetById(Id);
            if (result != null)
            {
               Producto productoDeleted =await _service.Delete(result);
                if (productoDeleted != null)
                {
                    return RedirectToAction(nameof(Index), new { Message = "Video eliminado exitosamente" });
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}