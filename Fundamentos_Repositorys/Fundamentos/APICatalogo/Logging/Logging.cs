using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Logging
{
    public class Logging
    {
        private readonly ILogger<Logging> _logger;
        public Logging(ILogger<Logging> logger)
        {
            _logger = logger;
        }

        public void TipodLoggings() {
            // _logger.LogCritical(); - Descrevem falhas de sitema que requer atenção imediata
            // _logger.LogDebug(); - São usados pra investigação interativa durante o desenvolvimento
            // _logger.LogError(); - Destacam quando o fluxo atual de execução é interrompido devido a uma falha
            // _logger.LogInformation(); - Rastreiam fluxo geral do aplicativo
            // _logger.LogTrace() - Tem mensagens mais detalhadas. pode conter dados importantes e não devem ser usada em produção
            // _logger.LogWarning - Destacam eventos anormal ou inesperada no fluxo do aplicativo
        }

    }
}
