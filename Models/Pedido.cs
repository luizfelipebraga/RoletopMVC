using System;
using System.Collections.Generic;
using RoletopMVC.Enums;

namespace RoletopMVC.Models
{
    public class Pedido
    {
        public ulong Id{get;set;}
        public Cliente Cliente {get;set;}

        public List<Produto> Produtos{get;set;}

        public string Eventos {get;set;}
        public string NomeEvento{get;set;}
        public string Endereco {get;set;}

        public string Email {get;set;}

        public string Telefone{get;set;}

        public string Planos{get;set;}

        public DateTime DataPedido{get;set;}

        public double PrecoTotal {get;set;}
        public uint Status {get;set;}

        public Pedido(Cliente cliente,string nome_evento,string email,string eventos,string produtos,string telefone )
        {
            this.Cliente = cliente;
            this.NomeEvento = nome_evento;
            this.Email = email;
            this.Eventos = eventos;
            this.Planos = produtos;
            this.Telefone = telefone;
            this.DataPedido = DateTime.Now;
            

        }

        public Pedido()
        {
            this.Cliente = new Cliente();
            this.DataPedido = DateTime.Now;
            this.Id = 0; // * todo Id começa com 0;
            this.Status = (uint)StatusPedido.PENDENTE; // * pendente ;
        }
    }
}