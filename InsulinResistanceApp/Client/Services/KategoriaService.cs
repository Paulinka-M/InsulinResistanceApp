namespace InsulinResistanceApp.Client.Services
{
    public class KategoriaService : IKategoriaService
    {
        private readonly HttpClient _http;

        public KategoriaService(HttpClient http)
        {
            _http = http;
        }
        public List<Kategoria> Kategoria { get; set; } = new List<Kategoria>();

        public async Task GetKategorie()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Kategoria>>>("api/kategoria");
            if (response != null && response.Data != null)
            {
                Kategoria = response.Data;
            }
        }
    }
}
