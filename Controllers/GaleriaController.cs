using Microsoft.AspNetCore.Mvc;
using RoletopMVC.ViewModel;

namespace RoletopMVC.Controllers
{
    public class GaleriaController : AbstractController
    {
        public IActionResult index()
        {
            ViewData["NomeView"] =  "Galeria";
            return View(new BaseViewModel(){NomeView="Galeria", UsuarioEmail=GetUsuarioSession(),UsuarioNome=GetUsuarioNomeSession()});
        }
    }
}