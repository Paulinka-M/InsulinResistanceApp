namespace InsulinResistanceApp.Server.Services
{
    public class ProduktService : IProduktService
    {
        private readonly DataContext _context;

        public ProduktService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Produkt>> GetProduktAsync(int produktId)
        {
            var response = new ServiceResponse<Produkt>();
            var produkt = await _context.Produkty
                .FirstOrDefaultAsync(v => v.Id == produktId);

            if (produkt == null)
            {
                response.Success = false;
                response.Message = "Przepraszamy, ten produkt nie istnieje.";
            }
            else
            {
                response.Data = produkt;
            }

            return response;
        }
        public async Task<ServiceResponse<List<Produkt>>> GetProduktAsync()
        {
            var response = new ServiceResponse<List<Produkt>>()
            {
                Data = await _context.Produkty.ToListAsync()
            };

            return response;
        }
        public async Task<ServiceResponse<List<Produkt>>> GetProduktByCategory(string kategoriaUrl)
        {
            Console.WriteLine("servis produkt server otrzymana kategoria" + kategoriaUrl);
            var response = new ServiceResponse<List<Produkt>>
            {
                Data = await _context.Produkty
                .Where(p => p.Kategoria.Nazwa.ToLower().Equals(kategoriaUrl.ToLower()))
                .ToListAsync()
            };
            

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetSearchSuggestions(string searchText)
        {
            var produkty = await FindProduktyBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var produkt in produkty)
            {
                if (produkt.Nazwa.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(produkt.Nazwa);
                }

            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<ProductSearchResultDTO>> SearchProdukt(string searchText, int requestedPage)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling((await FindProduktyBySearchText(searchText)).Count / pageResults);
            var produkty = await _context.Produkty
                                .Where(p => p.Nazwa.ToLower().Contains(searchText.ToLower()))
                                .Skip((requestedPage - 1) * (int)pageResults)
                                .Take((int)pageResults)
                                .ToListAsync();

            var response = new ServiceResponse<ProductSearchResultDTO>
            {
                Data = new ProductSearchResultDTO
                {
                    Produkty = produkty,
                    ObecnaStrona = requestedPage,
                    Strony = (int)pageCount
                }
            };

            return response;

        }

        private async Task<List<Produkt>> FindProduktyBySearchText(string searchText)
        {
            return await _context.Produkty
                                .Where(p => p.Nazwa.ToLower().Contains(searchText.ToLower()))
                                .ToListAsync();
        }
    }
}
