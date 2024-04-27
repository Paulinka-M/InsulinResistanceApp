namespace InsulinResistanceApp.Client.Services
{
    public interface IPosilekService
    {
        event Action OnChange;
        Task DodajDoPosilku(ProduktWPosilku produktWPosilku);
        Task<List<ProduktWPosilku>> GetProduktyWPosilku();

        Task<List<ProduktWPosilkuResponse>> GetProduktyWPosilkuResponse();
    }
}
