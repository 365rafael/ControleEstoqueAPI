using ControleEstoqueAPI.Dtos;

namespace ControleEstoqueAPI.Services
{
    public interface IPdfService
    {
        byte[] GerarPdfDoDashboard(DashboardDto dashboard);
    }
}
