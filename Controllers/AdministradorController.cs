using Microsoft.AspNetCore.Mvc;
using RoletopMVC.Enums;
using RoletopMVC.Repositories;
using RoletopMVC.ViewModel;

namespace RoletopMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();
        public IActionResult index()
        {
            // * verficiador para ve se a pessoa é realmente um admin

        bool ninguemLogado = string.IsNullOrEmpty(GetUsuarioTipoSession());
        if(!ninguemLogado && (uint)TipoUsuario.ADMINISTRADOR == uint.Parse(GetUsuarioTipoSession()))
        {
        var pedidos = pedidoRepository.GetTodos();
        DashboardViewModel dashboardViewModel = new DashboardViewModel();

        foreach (var pedido in pedidos)
        {
            switch (pedido.Status)
            {
                case (uint) StatusPedido.APROVADO:
                    dashboardViewModel.PedidosAprovados++;
                break;
                case (uint) StatusPedido.REPROVADO:
                    dashboardViewModel.PedidosReprovados++;
                break;

                default:
                    dashboardViewModel.PedidosPendentes++;
                    dashboardViewModel.Pedidos.Add(pedido); // * Adicionar na lista de pedidos no dashboardViewModel um novo pedido quer deu certo(pedido);
                break;
            }
        }
        
        dashboardViewModel.NomeView = "Administrador";
        dashboardViewModel.UsuarioEmail = GetUsuarioSession();
        dashboardViewModel.UsuarioNome = GetUsuarioNomeSession();
        
        return View(dashboardViewModel);
        }
        else
        {
            return View("Erro", new RespostaViewModel(){NomeView="Administrador", Mensagem="Você não tem permissão para acessar o Dashboard!"});
        }
        }
    }
}