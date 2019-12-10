using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoletopMVC.Enums;
using RoletopMVC.Models;
using RoletopMVC.Repositories;
using RoletopMVC.ViewModel;

namespace RoletopMVC.Controllers
{
    public class CadastroEventoController : AbstractController
    {
    PedidoViewModel pvm = new PedidoViewModel();

    ClienteRepository clienteRepository = new ClienteRepository();
    PedidoRepository pedidoRepository = new PedidoRepository();
    ProdutoRepository produtoRepository = new ProdutoRepository();
    EventoRepository eventoRepository = new EventoRepository();
        
        public IActionResult index()
        {
            ViewData["NomeView"] = "CadastroEvento";

            pvm.Produtos = produtoRepository.GetTodos();

            pvm.Eventos = eventoRepository.GetTodos();

            var emailCliente = GetUsuarioSession();

            if (!string.IsNullOrEmpty(emailCliente))
            {
                pvm.Cliente = clienteRepository.GetPor(emailCliente);
            }

            var nomeUsuario = GetUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuario))
            {
                pvm.NomeCliente = nomeUsuario;
            }

            pvm.NomeView = "CadastroEvento";
            pvm.UsuarioEmail = emailCliente;
            pvm.UsuarioNome = nomeUsuario;
            return View(pvm);
            
        }

        public IActionResult Registrar(IFormCollection form)
        {
            ViewData["Action"] = "CadastroEvento";

            try{

            List<Produto> produtos = new List<Produto>();

            List<Evento> eventos = new List<Evento>();

            string nomeProduto = form["planos"];

            string nomeEvento = form["eventos"];
            
            if(form["planos"] == "Som")
            {
                Produto produto = new Produto(nomeProduto,produtoRepository.GetPrecoDe(nomeProduto));
                
            }
            
            else if(form["planos"] == "Iluminacao")
            {
                Produto produto = new Produto(nomeProduto,produtoRepository.GetPrecoDe(nomeProduto));
                
            }

            else if (form["planos"] == "Som/Iluminacao")
            {
                Produto produto = new Produto(nomeProduto,produtoRepository.GetPrecoDe(nomeProduto));

            }else if(form["planos"]=="Sem serviço")
            {
                Produto produto = new Produto(nomeProduto,produtoRepository.GetPrecoDe(nomeProduto));

            }

            Evento evento = new Evento(nomeEvento, eventoRepository.GetPrecoDe(nomeEvento));

            var emailCliente = GetUsuarioSession();

            Cliente cliente = clienteRepository.GetPor(emailCliente);

            Pedido pedido = new Pedido(
            
            cliente,form["nome_evento"],cliente.Email=form["email"],form["eventos"],form["planos"],cliente.Telefone=form["telefone"]
            );

            pedido.Cliente = cliente;
            pedido.DataPedido = DateTime.Now;
            pedido.PrecoTotal = produtoRepository.GetPrecoDe(form["planos"]) + eventoRepository.GetPrecoDe(form["eventos"]);


            PedidoRepository pedidoRepository = new PedidoRepository();

            pedidoRepository.Inserir(pedido);
            return View("Sucesso", new RespostaViewModel("Cadastro do Evento deu bom! agora espere para que seu formulário seja aprovado!"){NomeView="Sucesso",UsuarioEmail=GetUsuarioSession(),UsuarioNome=GetUsuarioNomeSession(),UsuarioTipo=GetUsuarioTipoSession()});
            }

            catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new RespostaViewModel("Cadastro do Evento deu ruim! Cadastre novamente seu evento!"){NomeView="Erro",UsuarioEmail=GetUsuarioSession(),UsuarioNome=GetUsuarioNomeSession(),UsuarioTipo=GetUsuarioTipoSession()});
            }

        }

        public IActionResult Reprovar(ulong Id)
        {
            var pedido = pedidoRepository.GetPor(Id);
            pedido.Status = (uint) StatusPedido.REPROVADO;

            if(pedidoRepository.Atualizar(pedido))
            {
                return RedirectToAction("index", "Administrador");
            }

            else
            {
                return View("Erro", new RespostaViewModel("Não foi possivel aprovar o pedido."){
                    NomeView = "index",
                    UsuarioEmail = GetUsuarioSession(),
                    UsuarioNome = GetUsuarioNomeSession(),
                    UsuarioTipo = GetUsuarioTipoSession(),
                });
            }
        }
        public IActionResult Aprovar(ulong Id)
        {
            var pedido = pedidoRepository.GetPor(Id);
            pedido.Status = (uint) StatusPedido.APROVADO;

            if(pedidoRepository.Atualizar(pedido))
            {
                return RedirectToAction("index", "Administrador");
            }

            else
            {
                return View("Erro", new RespostaViewModel("Não foi possivel aprovar o pedido."){
                    NomeView = "index",
                    UsuarioEmail = GetUsuarioSession(),
                    UsuarioNome = GetUsuarioNomeSession(),
                    UsuarioTipo = GetUsuarioTipoSession(),
                });
            }
        }
    }
}