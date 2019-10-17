﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinneapolisMachines.App.Models.Factories;
using MinneapolisMachines.Data.Interfaces;
using MinneapolisMachines.Models.Specials;

namespace MinneapolisMachines.App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ISpecialsRepo specialsRepo = RepoFactory.CreateSpecialsRepo();
            return View(specialsRepo.GetAll());
        }
    }
}