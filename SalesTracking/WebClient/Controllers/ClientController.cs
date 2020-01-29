using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient.Controllers
{
    using BLL;

    using WebClient.Filters;
    using WebClient.Models;

    public class ClientController : Controller
    {
        private ClientService clientService;

        private ModelMapper modelMapper;

        public ClientController()
        {
            this.clientService = new ClientService();
            this.modelMapper = new ModelMapper();
        }

        [AuthenticationFilter]
        [Role("Admin", "User")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AuthenticationFilter]
        [Role("Admin", "User")]
        public ActionResult Edit(int clientId)
        {
            var client = this.clientService.GetClientById(clientId);
            ViewBag.Sale = modelMapper.ToModel(client);
            return View();
        }

        [HttpPost]
        [AuthenticationFilter]
        [Role("Admin")]
        public ActionResult Edit(ClientModel client)
        {
            TryUpdateModel(client);
            if (ModelState.IsValid)
            {
                clientService.UpdateClient(this.modelMapper.ToBLO(client));
                return View("Index");
            }

            return View("Error");
        }
    }
}