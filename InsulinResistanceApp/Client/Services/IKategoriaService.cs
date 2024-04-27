namespace InsulinResistanceApp.Client.Services
{
    public interface IKategoriaService
    {
        List<Kategoria> Kategoria { get; set; }
        Task GetKategorie();
    }
}
