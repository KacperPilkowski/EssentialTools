﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        private Product[] products =
        {
            new Product {Name = "Kajak", Category = "Sporty wodne", Price = 275M},
            new Product {Name = "Kamizelak ratunkowa", Category = "Sporty wodne", Price = 48.95M},
            new Product {Name = "Piłka nożna", Category = "Piłka nożna", Price = 19.50M},
            new Product {Name = "Flaga narodowa", Category = "Piłka nożna", Price = 34.95M}
        };

        public HomeController(IValueCalculator calcParam, IValueCalculator calc2)
        {
            calc = calcParam;
        }
        
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart(calc) {Products = products};

            decimal tolalValue = cart.CalculateProductTotal();

            return View(tolalValue);
        }
    }
}