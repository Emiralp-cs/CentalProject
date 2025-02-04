﻿using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Concrate;
using Cental.DTOLayer.CarDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminCarController : Controller
    {

        private readonly ICarService _carService;

        private readonly IMapper _mapper;
        public AdminCarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _carService.TGetCarWithBrands();

            var result = _mapper.Map<List<ToListCarDto>>(values);

            return View(result);
        }
    }
}
