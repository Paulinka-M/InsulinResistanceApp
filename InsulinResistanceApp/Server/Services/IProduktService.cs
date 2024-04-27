namespace InsulinResistanceApp.Server.Services
{
    public interface IProduktService
    {
        Task<ServiceResponse<List<Produkt>>> GetProduktAsync();
        Task<ServiceResponse<Produkt>> GetProduktAsync(int produktId);
        Task<ServiceResponse<List<Produkt>>> GetProduktByCategory(string kategoriaUrl);
        Task<ServiceResponse<ProductSearchResultDTO>> SearchProdukt(string searchText, int requestedPage);
        Task<ServiceResponse<List<string>>> GetSearchSuggestions(string searchText);
    }
}
