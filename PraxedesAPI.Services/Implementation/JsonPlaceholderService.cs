using PraxedesAPI.Services.Interfaces;

namespace PraxedesAPI.Services.Implementation
{
    public class JsonPlaceholderService: IJsonPlaceholderService
    {
        public async Task<string> RunService(string apiUrl) 
        {
            // Crear el cliente HttpClient
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Realizar la solicitud GET a la URL
                    var response = await httpClient.GetAsync(apiUrl);

                    // Verificar si la solicitud fue exitosa (código de estado 200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        return responseBody;
                    }
                    else
                        return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
                catch (Exception ex)
                {
                    var exception = ex.InnerException?.ToString() ?? ex.Message;
                    return $"Error: {exception}";
                }
            }
        }
    }
}
