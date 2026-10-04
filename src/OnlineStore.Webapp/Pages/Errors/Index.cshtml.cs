using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineStore.Webapp.Pages.Errors
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public int Code { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? OriginalPath { get; set; }
        public bool ShowOriginalPath => !string.IsNullOrEmpty(OriginalPath);

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int? code)
        {
            // Define o código recebido ou assume 500 caso seja omitido
            Code = code ?? Response.StatusCode;
            if (Code == 200) Code = 500;

            // 1. Recupera o caminho original antes do erro (para erros como 404/403)
            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                OriginalPath = statusCodeReExecuteFeature.OriginalPath;
            }

            // 2. Recupera detalhes da Exceção C# (no caso de erros 500 via UseExceptionHandler)
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandlerFeature != null)
            {
                OriginalPath = exceptionHandlerFeature.Path;

                // Registra o erro real no sistema de Log
                _logger.LogError(
                    exceptionHandlerFeature.Error,
                    "Exceção não tratada capturada na rota: {Path}",
                    exceptionHandlerFeature.Path
                );
            }

            // Ajusta o texto da interface de acordo com o código HTTP
            ConfigurePageTexts(Code);
        }

        private void ConfigurePageTexts(int code)
        {
            switch (code)
            {
                case 404:
                    Title = "Página Não Encontrada";
                    Message = "O recurso ou página que você tentou acessar não existe ou mudou de endereço.";
                    break;
                case 403:
                    Title = "Acesso Negado";
                    Message = "Você não possui permissão suficiente para acessar este recurso.";
                    break;
                case 401:
                    Title = "Não Autorizado";
                    Message = "É necessário realizar login para visualizar esta página.";
                    break;
                case 500:
                default:
                    Code = 500;
                    Title = "Erro Interno do Servidor";
                    Message = "Ocorreu uma falha inesperada em nossos servidores. Nossa equipe já foi notificada.";
                    break;
            }
        }
    }
}
