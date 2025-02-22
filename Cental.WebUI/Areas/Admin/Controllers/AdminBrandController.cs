﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DTOLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PagedList.Core;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminBrandController : Controller
    {
        private readonly IBrandService _brandService;

        public AdminBrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index(int page = 1, int pageSize = 3)
        {
            var brands = _brandService.TListN().AsQueryable();

            var values = new PagedList<ToListBrandDTO>(brands, page, pageSize);

            TempData["Count"] = 0;

            return View(values);
        }


        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(CreateBrandDTO NewBrand)
        {
            if (!ModelState.IsValid)
            {
                return View(NewBrand);
            }


            _brandService.TCreateN(NewBrand);

            return RedirectToAction("Index");
        }


        [HttpGet]

        public IActionResult UpdateBrand(int id)
        {

            var value = _brandService.TGetById(id);

            //Brandi UpdateBrandDtoya mapleme
            var result = _brandService.TUpdate_GetN;


            return View(result);
        }

        [HttpPost]

        public IActionResult UpdateBrand(UpdateBrandDTO NewBrand)
        {

            //UpdateBrandDtoyu Brande mapleme
            _brandService.T_Update_PostN(NewBrand);


            return RedirectToAction("Index");
        }

    }
}
