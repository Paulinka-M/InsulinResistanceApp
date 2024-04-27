namespace InsulinResistanceApp.Server.Services
{
    public class KategoriaService : IKategoriaService
    {
        private readonly DataContext _context;

        public KategoriaService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Kategoria>>> GetKategoria()
        {
            var kategoria = await _context.Kategorie.ToListAsync();
            return new ServiceResponse<List<Kategoria>>
            {
                Data = kategoria
            };
        }
    }
}
