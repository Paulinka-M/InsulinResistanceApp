namespace InsulinResistanceApp.Server.Services
{
    public class PosilekService : IPosilekService
    {
        private readonly DataContext _context;
        public PosilekService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<ServiceResponse<List<ProduktWPosilkuResponse>>> GetProduktyWPosilku(List<ProduktWPosilku> produktyWPosilku)
        {
            var result = new ServiceResponse<List<ProduktWPosilkuResponse>>()
            {
                Data = new List<ProduktWPosilkuResponse>()
            };

            foreach (var item in produktyWPosilku)
            {
                var produkt = await _context.Produkty
                    .Where(p => p.Id == item.ProduktId)
                    .FirstOrDefaultAsync();

                if (produkt == null)
                {
                    continue;
                }

                var produktWPosilku = new ProduktWPosilkuResponse
                {
                    ProduktId = produkt.Id,
                    Nazwa = produkt.Nazwa,
                    kcal = produkt.kcal,
                    weglowodany = produkt.weglowodany,
                    bialko = produkt.bialko,
                    tluszcze = produkt.tluszcze,
                    indeksglikemiczny = produkt.indeksglikemiczny,
                    waga = item.Waga
                    
                };
                
                result.Data.Add(produktWPosilku);
            }
            return result;
        }
    }
}
