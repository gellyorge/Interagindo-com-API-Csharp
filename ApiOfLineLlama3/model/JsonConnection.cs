using System.Configuration;
using System.Text.Json;


namespace ApiOfLineLlama3.model
{
    public class JsonConnection
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiIA"];

        public static async Task<string> GetResposta(Requisicao requestData)
        {
            try
            {
                string jsonRequest = JsonSerializer.Serialize(requestData);

                var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // Parse do JSON para obter o campo 'response'
                    JsonDocument doc = JsonDocument.Parse(jsonResponse);
                    JsonElement root = doc.RootElement;

                    string rs = root.GetProperty("response").GetString();
                    return rs;
                }
                else
                {
                    return $"Erro ao chamar a API: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                
                return $"Ocorreu um erro: {ex.Message}"; 
            }
        }
    }
}

