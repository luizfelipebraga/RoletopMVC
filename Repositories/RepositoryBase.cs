namespace RoletopMVC.Repositories
{
    public class RepositoryBase
    {
        protected string ExtrairValorDoCampo(string nomeCampo, string linha)
        {
            var chave = nomeCampo;
            var indiceChave = linha.IndexOf(chave);
            
            //!ANCHOR o primeiro ";" quando comeca o "email no csv"
            var indiceTerminal = linha.IndexOf(";", indiceChave);

            var valor = "";

            if(indiceTerminal != -1)
            {
                valor = linha.Substring(indiceChave, indiceTerminal - indiceChave);
            }

            else
            {
                valor = linha.Substring(indiceChave);
            }

            System.Console.WriteLine($"Campo: {nomeCampo} e valor {valor}");

            // * ANCHOR Substituir o "cliente" + "=" e colocar nada;
            return valor.Replace(nomeCampo + "=","");
        }
    }
}