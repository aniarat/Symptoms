using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Symptoms.ApiClient
{
    class GlobalExceptionHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    // Obsługa błędów dla nieudanych odpowiedzi
                    var errorMessage = $"HTTP Error: {(int)response.StatusCode} - {response.ReasonPhrase}";
                    // Możesz dodać kod do logowania lub powiadamiania użytkownika
                    Console.WriteLine(errorMessage);
                }
                return response;
            }
            catch (HttpRequestException e)
            {
                // Obsługa wyjątków
                Console.WriteLine($"Network error occurred: {e.Message}");
                // Możesz zwrócić specjalny błąd lub defaultową odpowiedź
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
