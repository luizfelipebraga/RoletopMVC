using System.Collections.Generic;
using System.IO;
using RoletopMVC.Models;

namespace RoletopMVC.Repositories
{
    public class EventoRepository
    {
        private const string PATH = "Database/Eventos.csv";

        public double GetPrecoDe(string nomeEvento)
        {
            string[] linhas = File.ReadAllLines(PATH);
            double preco = 0.0;

            foreach(string linha in linhas)
            {
                List<Evento> lista = GetTodos();

                foreach(Evento evento in lista)
                {
                    if (evento.NomeEvento == nomeEvento)
                    {
                        preco = evento.Preco;
                        break;
                    }
                }
            }
            return preco;
        }
        public List<Evento> GetTodos()
        {
            List<Evento> eventos = new List<Evento>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var linha in linhas)
            {
                Evento evento = new Evento();

                string[] dados = linha.Split(";");
                evento.NomeEvento = dados[0];
                evento.Preco = double.Parse(dados[1]);
                eventos.Add(evento);

                System.Console.WriteLine(linha);
            }

            return eventos;
        }
    }
}