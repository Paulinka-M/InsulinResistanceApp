namespace InsulinResistanceApp.Server.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Rejestracja(Uzytkownik uzytkownik, string haslo);
        Task<bool> CzyIstnieje(string email);
        Task<ServiceResponse<string>> Logowanie(string email, string haslo);
        Task<ServiceResponse<bool>> ZmianaHasla(string StareHaslo, int uzytkownikId, string noweHaslo);
        Task<ServiceResponse<string>> ZapomnianeHaslo(string email);
        Task<ServiceResponse<string>> NoweHaslo(string Token, string haslo);
    }
}
