namespace InsulinResistanceApp.Server.Services
{
    public interface IKategoriaService
    {
        Task<ServiceResponse<List<Kategoria>>> GetKategoria();
    }
}
