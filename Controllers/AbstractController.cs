using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoletopMVC.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "email_cliente";
        protected const string SESSION_CLIENTE_NOME = "nome_cliente";
        protected const string SESSION_CLIENTE_TIPO = "cliente_tipo";

        protected string GetUsuarioSession()
        {
            var emailUsuario = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);

            if(!string.IsNullOrEmpty(emailUsuario))
            {
                return emailUsuario;
            }

            else
            {
                return "";
            }

        }

        protected string GetUsuarioNomeSession()
        {
            var nomeUsuario = HttpContext.Session.GetString(SESSION_CLIENTE_NOME);
            if(!string.IsNullOrEmpty(nomeUsuario))
            {
                return nomeUsuario;
            }

            else 
            {
                return "";
            }
        }

        protected string GetUsuarioTipoSession()
        {
            var tipo_usuario = HttpContext.Session.GetString(SESSION_CLIENTE_TIPO);
            if(!string.IsNullOrEmpty(tipo_usuario))
            {
                return tipo_usuario;
            }
            else
            {
                return "";
            }
        }
    }
}