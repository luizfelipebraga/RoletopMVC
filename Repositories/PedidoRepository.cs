using System;
using System.Collections.Generic;
using System.IO;
using RoletopMVC.Models;

namespace RoletopMVC.Repositories
{
    public class PedidoRepository : RepositoryBase
    {
        public const string PATH = "Database/Pedido.csv";
        public PedidoRepository()
        {   
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }    
        }

        public bool Inserir(Pedido pedido)
        {
            var quantidadePedidos = File.ReadAllLines(PATH).Length;
            pedido.Id = (ulong) quantidadePedidos+1;
            var linha = new string[] {PrepararRegistroCSV(pedido)};
            File.AppendAllLines(PATH, linha);
            return true;
        }

        public List<Pedido> GetTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Pedido> pedidos = new List<Pedido>();
            foreach (var linha in linhas)
            {
                Pedido pedido = new Pedido();

                pedido.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                pedido.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
                pedido.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);
                pedido.Cliente.Endereco = ExtrairValorDoCampo("cliente_endereco",linha);
                pedido.Eventos = ExtrairValorDoCampo("eventos",linha);
                pedido.NomeEvento = ExtrairValorDoCampo("nome_evento",linha);
                pedido.Planos = ExtrairValorDoCampo("planos",linha);
                pedido.DataPedido = DateTime.Parse(ExtrairValorDoCampo("data_pedido",linha));
                pedido.PrecoTotal = double.Parse(ExtrairValorDoCampo("preco_total",linha));
                pedido.Id = ulong.Parse(ExtrairValorDoCampo("id_pedido",linha));
                pedido.Status = uint.Parse(ExtrairValorDoCampo("status",linha));
                pedido.DataEvento = DateTime.Parse(ExtrairValorDoCampo("dataevento",linha)); 

                pedidos.Add(pedido);
            }

            return pedidos;
        }
    
        public List<Pedido> GetTodosPorCliente(string emailCliente)
        {
            // * obter todos os pedidos dos clientes;
            var pedidos = GetTodos();
            List<Pedido> pedidosCliente = new List<Pedido>();
            foreach(var pedido in pedidos)
            {
                if(pedido.Cliente.Email.Equals(emailCliente))
                {
                    pedidosCliente.Add(pedido);
                }
            }
            return pedidosCliente;
        }

        public Pedido GetPor(ulong Id)
        {
            var pedidosTotais = GetTodos();
            foreach (var pedido in pedidosTotais)
            {
                if(Id.Equals(pedido.Id))
                {
                    return pedido;
                }

            }return null;

        }

        public bool Atualizar(Pedido pedido)
        {
            var pedidosTotais = File.ReadAllLines(PATH);
            var pedidoCSV = PrepararRegistroCSV(pedido);
            var linhaPedido = -1;
            var resultado = false;

            for (int i = 0; i < pedidosTotais.Length; i++)
            {
                var IdConvertido = ulong.Parse(ExtrairValorDoCampo("id_pedido", pedidosTotais[i]));
                if(pedido.Id.Equals(IdConvertido))
                {
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado)
            {
                pedidosTotais[linhaPedido] = pedidoCSV;     // * acessa a linha do vetor linha pedido
                File.WriteAllLines(PATH, pedidosTotais); 
            }
            
            return resultado;
        }

        private string PrepararRegistroCSV(Pedido pedido)
        {

            Cliente cliente = pedido.Cliente;
            return $"cliente_nome={cliente.Nome};cliente_endereco={cliente.Endereco};cliente_telefone={cliente.Telefone};cliente_email={cliente.Email};eventos={pedido.Eventos};nome_evento={pedido.NomeEvento};planos={pedido.Planos};data_pedido={pedido.DataPedido};dataevento={pedido.DataEvento};preco_total={pedido.PrecoTotal};id_pedido={pedido.Id};status={pedido.Status}";
        }
    }
}