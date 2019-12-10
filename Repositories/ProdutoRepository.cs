using System.Collections.Generic;
using System.IO;
using RoletopMVC.Models;

namespace RoletopMVC.Repositories
{
    public class ProdutoRepository
    {
        private const string PATH = "Database/Produtos.csv";

        public double GetPrecoDe(string nomeProduto)
        {
            string[] linhas = File.ReadAllLines(PATH);
            double preco = 0.0;

            foreach(string linha in linhas)
            {
                List<Produto> lista = GetTodos();

                foreach(Produto produto in lista)
                {
                    if (produto.Nome == nomeProduto)
                    {
                        preco = produto.Preco;
                        break;
                    }
                }
            }
            return preco;
        }
        public List<Produto> GetTodos()
        {
            List<Produto> produtos = new List<Produto>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach(var linha in linhas)
            {
                Produto s = new Produto();
                string[] dados = linha.Split(";");
                s.Nome = dados[0];
                s.Preco = double.Parse(dados[1]);
                produtos.Add(s);
            }

            return produtos;
        }
    }
}