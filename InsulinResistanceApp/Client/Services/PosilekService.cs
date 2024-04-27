namespace InsulinResistanceApp.Client.Services
{
    public class PosilekService : IPosilekService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        public PosilekService(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }
        public event Action OnChange;
        public async Task DodajDoPosilku(ProduktWPosilku produktWPosilku)
        {
            var posilek = await _localStorage.GetItemAsync<List<ProduktWPosilku>>("posilek");
            if (posilek == null)
            {
                posilek = new List<ProduktWPosilku>();
            }
            posilek.Add(produktWPosilku);

            await _localStorage.SetItemAsync("posilek", posilek);
        }
        public async Task<List<ProduktWPosilku>> GetProduktyWPosilku()
        {
            var posilek = await _localStorage.GetItemAsync<List<ProduktWPosilku>>("posilek");
            if (posilek == null)
            {
                posilek = new List<ProduktWPosilku>();
            }
            return posilek;
        }

        public async Task<List<ProduktWPosilkuResponse>> GetProduktyWPosilkuResponse()
        {
            var produktyWPosilku = await _localStorage.GetItemAsync<List<ProduktWPosilku>>("posilek");
            var response = await _http.PostAsJsonAsync("api/posilek/produkty", produktyWPosilku);
            var produktyWPosilkuResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<List<ProduktWPosilkuResponse>>>();
            return produktyWPosilkuResponse.Data;
        }
    }
}
