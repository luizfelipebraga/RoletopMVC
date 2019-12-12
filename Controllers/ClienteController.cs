using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoletopMVC.Enums;
using RoletopMVC.Repositories;
using RoletopMVC.ViewModel;

namespace RoletopMVC.Controllers
{
    public class ClienteController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
        private PedidoRepository pedidoRepository = new PedidoRepository();

        [HttpGet]
        public IActionResult index()
        {
            ViewData["NomeView"] =  "Login";

            return View(new BaseViewModel(){NomeView="Login",UsuarioEmail=GetUsuarioSession(),UsuarioNome=GetUsuarioNomeSession()});
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            try
            {
                System.Console.WriteLine("========================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("========================");

                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.GetPor(usuario);

                if(cliente != null)
                {
                    // * primeira Senha é do banco e a segunda a do usuario que digitou;
                    if(cliente.Senha.Equals(senha)){
                        switch (cliente.TipoUsuario)
                        {

                        case (uint) TipoUsuario.CLIENTE:
                            
                            // *  string = "session_cliente_email"; variavel cost string Session_cliente_email;
                            HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                            HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());

                            // * action = "Historico" ; ControllerName = "Cliente" ;  RedirectAction("Historico", "Cliente");
                        
                        return RedirectToAction("Historico", "Cliente");
                        
                        default:

                            // *  string = "session_cliente_email"; variavel cost string Session_cliente_email;
                            HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                            HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, cliente.TipoUsuario.ToString());
                            // * action = "Historico" ; ControllerName = "Cliente" ;  RedirectAction("Historico", "Cliente");
                        
                        return RedirectToAction("Index", "Administrador");
                        
                        }
                    }else
                    {
                        return View("Erro", new RespostaViewModel("Senha incorreta"){NomeView="Erro",UsuarioEmail=GetUsuarioSession(),UsuarioNome=GetUsuarioNomeSession()});
                    }   
                }else
                {
                    // * instanciando um objeto RespostaViewModel rvm = new RespostaViewModel(); diminuindo o código
                    return View("Erro",new RespostaViewModel($"Usuário {usuario} não encontrado, tente novamente!"){NomeView = "Erro", UsuarioEmail = GetUsuarioSession(), UsuarioNome = GetUsuarioNomeSession()});
                }
                
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.GetBaseException());
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new RespostaViewModel(){NomeView = "Erro", UsuarioEmail = GetUsuarioSession(), UsuarioNome = GetUsuarioNomeSession()});
            }
        }

        public IActionResult Historico()
        {
            var emailCliente = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            var pedidosCliente = pedidoRepository.GetTodosPorCliente(emailCliente);

            return View(new HistoricoViewModel() {Pedidos = pedidosCliente, NomeView = "Historico",UsuarioEmail=GetUsuarioSession(), UsuarioNome=GetUsuarioNomeSession()});
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }
    }
}