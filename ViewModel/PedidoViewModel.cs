using System.Collections.Generic;
using RoletopMVC.Models;
using RoletopMVC.ViewModel;

namespace RoletopMVC.ViewModel
{
    public class PedidoViewModel : BaseViewModel
    {
        public List<Produto> Produtos {get;set;}
        public string NomeCliente {get;set;}
        public Cliente Cliente{get;set;}
        public List<Evento> Eventos{get;set;}

        public PedidoViewModel()
        {
            this.Produtos = new List<Produto>();
            this.Cliente = new Cliente();
            this.NomeCliente = "Jovem";
            this.Eventos = new List<Evento>();
        }
    }
}