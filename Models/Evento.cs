using System;
namespace RoletopMVC.Models
{
    public class Evento
    {
        public string NomeEvento{get;set;}
        public double Preco{get;set;}

        public Evento()
        {

        }

        public Evento(string nomeEvento, double preco)
        {
            this.NomeEvento = nomeEvento;
            this.Preco = preco;
        }
    }
}