using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;

namespace WebClient.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using BLEntity;

    using BLL;

    using WebClient.Filters;
    using WebClient.Models;

    public class SaleController : Controller
    {
        private readonly SalesService salesService;

        private ModelMapper modelMapper;

        public SaleController(SalesService salesService)
        {
            this.salesService = salesService;
            this.modelMapper = new ModelMapper();
        }

        [AuthenticationFilter]
        [Role("Admin", "User")]
        public ActionResult Index()
        {
            ViewBag.Sales = salesService.GetAllSales();
            return View();
        }

        [HttpGet]
        [AuthenticationFilter]
        [Role("Admin", "User")]
        public ActionResult Edit(int saleId)
        {
            var sale = salesService.GetSaleById(saleId);
            ViewBag.Sale = modelMapper.ToModel(sale);
            return View();
        }

        [HttpPost]
        [AuthenticationFilter]
        [Role("Admin")]
        public ActionResult Edit(SaleModel saleModel)
        {
            TryUpdateModel(saleModel);
            if (ModelState.IsValid)
            {
                salesService.UpdateSale(modelMapper.ToBLO(saleModel));
                return View("Index");
            }

            return View("Error");
        }

    }
}
