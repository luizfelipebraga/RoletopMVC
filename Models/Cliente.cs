using System;
namespace RoletopMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Endereco {get;set;}
        public string Telefone {get;set;}
        public string Senha {get;set;}
        public string ConfirmarSenha {get;set;}
        public string Email {get;set;}
        public DateTime DataNascimento {get;set;}
        public uint TipoUsuario {get;set;}



        public Cliente()
        {

        }


        public Cliente(string nome, string telefone, string senha,string confimarsenha, string email, DateTime dataNascimento)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.ConfirmarSenha = confimarsenha;
            this.Senha = senha;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.TipoUsuario = (uint)RoletopMVC.Enums.TipoUsuario.CLIENTE;
        }
    }
}