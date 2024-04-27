namespace InsulinResistanceApp.Server.Services
{
    public interface IPosilekService
    {
        Task<ServiceResponse<List<ProduktWPosilkuResponse>>> GetProduktyWPosilku(List<ProduktWPosilku> produktyWPosilku);
    }
}
