namespace InsulinResistanceApp.Client.Services
{
    public class ProduktService : IProduktService
    {
        private readonly HttpClient _http;

        public ProduktService(HttpClient http)
        {
            _http = http;
        }
        public List<Produkt> Produkty { get; set; } = new List<Produkt>();
        public string Message { get; set; } = "Ładowanie produktów. . .";
        public string OstatnieWyszukiwanie { get; set; } = string.Empty;

        public event Action ProduktyChanged;
        public async Task<ServiceResponse<Produkt>> GetProdukt(int produktId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Produkt>>($"api/Produkt/{produktId}");

            return result;
        }
        public async Task GetProdukty(string kategoriaUrl)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Produkt>>>($"api/produkt/kategoria/{kategoriaUrl}");
            if (result != null && result.Data != null)
            {
                Produkty = result.Data;
                Console.WriteLine("cos tam znaleziono" + result.Data.Count);
            }


            if (Produkty.Count == 0)
            {
                Message = "Nie znaleziono produktów";
            }

            ProduktyChanged.Invoke();
        }

        public async Task<List<string>> GetSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/produkt/szukajsugestie/{searchText}");

            return result.Data;
        }

        public async Task SearchProdukt(string searchText, int requestedPage)
        {
            OstatnieWyszukiwanie = searchText;
            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"api/produkt/szukaj/{searchText}/{requestedPage}");

            if (result != null && result.Data != null)
            {
                Produkty = result.Data.Produkty;
            }

            if (Produkty.Count == 0)
                Message = "Nie znaleziono produktów odpowiadających zapytaniu";

            ProduktyChanged?.Invoke();
        }
    }
}

