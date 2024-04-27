namespace InsulinResistanceApp.Client.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Rejestracja(RejestracjaUzytkownika request);
        Task<ServiceResponse<string>> Logowanie(LogowanieUzytkownika request);
        Task<ServiceResponse<bool>> ZmianaHasla(ZmianaHasla request);
        Task<ServiceResponse<string>> ZapomnianeHaslo(ZapomnianeHaslo request);
        Task<ServiceResponse<string>> NoweHasloZmiana(NoweHasloRequest request);
    }
}
