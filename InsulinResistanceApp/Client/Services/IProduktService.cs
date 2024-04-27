namespace InsulinResistanceApp.Client.Services
{
    public interface IProduktService
    {
        event Action ProduktyChanged;
        List<Produkt> Produkty { get; set; }
        string Message { get; set; }
        string OstatnieWyszukiwanie { get; set; }
        Task GetProdukty(string kategoriaUrl);
        Task<ServiceResponse<Produkt>> GetProdukt(int produktId);
        Task SearchProdukt(string searchText, int requestedPage);
        Task<List<string>> GetSearchSuggestions(string searchText);
    }
}
