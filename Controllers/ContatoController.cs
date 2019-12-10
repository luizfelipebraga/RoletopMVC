using Microsoft.AspNetCore.Mvc;
using RoletopMVC.ViewModel;

namespace RoletopMVC.Controllers
{
    public class ContatoController : AbstractController
    {
        public IActionResult index()
        {
        ViewData["NomeView"] =  "Contato";

            return View(new BaseViewModel(){NomeView="Contato",UsuarioEmail=GetUsuarioSession(),UsuarioNome=GetUsuarioNomeSession()});
        }    
    }
}