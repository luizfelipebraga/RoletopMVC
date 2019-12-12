using System;
using System.IO;
using RoletopMVC.Models;
using RoletopMVC.Repositories;

namespace RoletopMVC.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";
        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }

            

        }

        public bool Inserir(Cliente cliente)
        {
            var linha = new string[] {PrepararRegistroCSV(cliente)};
            File.AppendAllLines(PATH, linha);
            return true;
        }

        public Cliente GetPor(string email)
        {
            var linhas = File.ReadAllLines(PATH);
            
            foreach (var item in linhas)
            {
                if(ExtrairValorDoCampo("email", item).Equals(email))
                {
                    Cliente cliente = new Cliente();
                    cliente.Nome = ExtrairValorDoCampo("nome", item);
                    cliente.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario",item));
                    cliente.Email = ExtrairValorDoCampo("email", item);
                    cliente.DataNascimento = DateTime.Parse(ExtrairValorDoCampo("data_nascimento", item));
                    cliente.Telefone = ExtrairValorDoCampo("telefone", item);
                    cliente.Senha = ExtrairValorDoCampo("senha", item);

                    return cliente;
                }
            }
            return null;
        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"tipo_usuario={cliente.TipoUsuario};nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};telefone={cliente.Telefone};data_nascimento={cliente.DataNascimento.Date}";
        }
    }
}