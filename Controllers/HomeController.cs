using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoletopMVC.Models;
using RoletopMVC.ViewModel;

namespace RoletopMVC.Controllers
{
    public class HomeController : AbstractController
    {
        public IActionResult index()
        {
            return View(new BaseViewModel(){NomeView = "Home",UsuarioEmail=GetUsuarioSession(),UsuarioNome=GetUsuarioNomeSession()});
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
