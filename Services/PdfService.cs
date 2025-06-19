using DinkToPdf;
using DinkToPdf.Contracts;
using ControleEstoqueAPI.Dtos;

namespace ControleEstoqueAPI.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GerarPdfDoDashboard(DashboardDto dashboard)
        {
            var html = MontarHtmlDashboard(dashboard);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(doc);
        }

        private string MontarHtmlDashboard(DashboardDto dashboard)
        {
            var html = $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial; }}
                        table {{ border-collapse: collapse; width: 100%; }}
                        th, td {{ border: 1px solid #000; padding: 8px; text-align: left; }}
                        th {{ background-color: #f2f2f2; }}
                    </style>
                </head>
                <body>
                    <h2>Relatório Dashboard</h2>
                    <p><b>Data:</b> {DateTime.Now:dd/MM/yyyy HH:mm}</p>
                    
                    <h3>Resumo Geral</h3>
                    <table>
                        <tr><th>Total Produtos</th><td>{dashboard.TotalProdutos}</td></tr>
                        <tr><th>Quantidade Estoque Disponível</th><td>{dashboard.QuantidadeEstoqueDisponivel}</td></tr>
                        <tr><th>Total Entradas no Mês</th><td>{dashboard.TotalEntradasMes}</td></tr>
                        <tr><th>Valor Total Entradas</th><td>R$ {dashboard.ValorTotalEntradasMes:N2}</td></tr>
                        <tr><th>Total Saídas no Mês</th><td>{dashboard.TotalSaidasMes}</td></tr>
                        <tr><th>Valor Total Saídas</th><td>R$ {dashboard.ValorTotalSaidasMes:N2}</td></tr>
                        <tr><th>Lucro do Mês</th><td>R$ {dashboard.LucroMes:N2}</td></tr>
                    </table>

                    <h3>Top 5 Produtos Mais Vendidos</h3>
                    <table>
                        <tr>
                            <th>Produto</th>
                            <th>Quantidade Vendida</th>
                        </tr>";

            foreach (var item in dashboard.TopProdutosMaisVendidos)
            {
                html += $"<tr><td>{item.ProdutoNome}</td><td>{item.QuantidadeVendida}</td></tr>";
            }

            html += @"
                    </table>
                </body>
                </html>";

            return html;
        }
    }
}
