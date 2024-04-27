namespace InsulinResistanceApp.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<int>> Rejestracja(RejestracjaUzytkownika request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/rejestracja", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
        public async Task<ServiceResponse<string>> Logowanie(LogowanieUzytkownika request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/logowanie", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> NoweHasloZmiana(NoweHasloRequest request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/nowe-haslo", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
        public async Task<ServiceResponse<string>> ZapomnianeHaslo(ZapomnianeHaslo request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/zapomniane-haslo", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> ZmianaHasla(ZmianaHasla request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/zmiana-hasla", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
