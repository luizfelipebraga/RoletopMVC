namespace RoletopMVC.Models
{
    public class Produto
    {
        public string Nome{get;set;}
        public double Preco{get;set;}
        public Som som {get;set;}
        public Iluminacao iluminacao{get;set;}

        public Produto()
        {

        }

        public Produto(string nome, double preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}