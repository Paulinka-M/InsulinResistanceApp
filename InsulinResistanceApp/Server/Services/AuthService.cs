using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace InsulinResistanceApp.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> CzyIstnieje(string email)
        {
            if (await _context.Uzytkownicy.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ServiceResponse<string>> Logowanie(string email, string haslo)
        {
            var response = new ServiceResponse<string>();
            var uzytkownik = await _context.Uzytkownicy
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

            if (uzytkownik == null)
            {
                response.Success = false;
                response.Message = "Nie znaleziono użytkownika o podanym adresie e-mail";
            }

            else if (!WeryfikujHaslo(haslo, uzytkownik.HashowaneHaslo, uzytkownik.Sol))
            { 
                response.Success = false;

                response.Message = "Błędne Hasło";
            }
            else
            { 
                response.Data = CreateToken(uzytkownik);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Rejestracja(Uzytkownik uzytkownik, string haslo)
        {
            if (await CzyIstnieje(uzytkownik.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Istnieje już konto o podanym adresie email"
                };
            }
            double entropia = CountEntropy(haslo);
            if (entropia < 60)
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Twoje hasło jest za słabe, jego entropia wynosi: " + Math.Round(entropia, 2) +
                    ", a powinna wynosić co najmniej 60. " +
                    "Bezpieczne Hasło powinno zawierać: " +
                    "duże i małe litery, " +
                    "znaki specjalne, " +
                    "liczby. " +
                    "Ponadto powinno mieć co najmniej 8 znaków."
                };
            }

            HashPassword(haslo, out byte[] hashedPassword, out byte[] sol);

            uzytkownik.Sol = sol;
            uzytkownik.HashowaneHaslo = hashedPassword;

            _context.Uzytkownicy.Add(uzytkownik); //do bazy danych
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = uzytkownik.Id, Message = "Z powodzeniem założyłeś nowe konto! :)" };
        }

        private static double CountEntropy(string password)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string special = "!@#$%^&*()_+-=[]{};':,./<>?`~";
            int possibleChars = 0;

            if (password.Any(c => lowercase.Contains(c)))
            {
                possibleChars += 26;
            }
            if (password.Any(c => uppercase.Contains(c)))
            {
                possibleChars += 26;
            }
            if (password.Any(c => digits.Contains(c)))
            {
                possibleChars += 10;
            }
            if (password.Any(c => special.Contains(c)))
            {
                possibleChars += 32;
            }
            return Math.Log(possibleChars, 2) * password.Length;
        }


        private void HashPassword(string haslo, out byte[] hashedPassword, out byte[] sol)
        {
            // Dodawanie pieprzu do hasła
            string pieprz = "MySuperSecurePepper";
            haslo = haslo + pieprz;

            // Generowanie losowej soli
            using (var rng = new RNGCryptoServiceProvider())
            {
                sol = new byte[32];
                rng.GetBytes(sol);
            }

            // Key stretching i hashowanie przy użyciu PBKDF2 - 10000 iteracji, jako input użyta sól generowana wyżej
            using (var pbkdf2 = new Rfc2898DeriveBytes(haslo, sol, 10000))
            {
                hashedPassword = pbkdf2.GetBytes(512);
            }

        }

        private bool WeryfikujHaslo(string haslo, byte[] hashFromDb, byte[] solFromDb)
        {
            byte[]? hashedPassword = null;

            // Dodawanie pieprzu do hasła
            string pieprz = "MySuperSecurePepper";
            haslo = haslo + pieprz;


            // Key stretching i hashowanie przy użyciu PBKDF2 - 10000 iteracji, jako input sol z bazy danych
            using (var pbkdf2 = new Rfc2898DeriveBytes(haslo, solFromDb, 10000))
            {
                hashedPassword = pbkdf2.GetBytes(512);
            }

            return hashedPassword.SequenceEqual(hashFromDb); // zwraca true jeśli oba hashe takie same, false jeśli nie

        }

        private string CreateToken(Uzytkownik uzytkownik)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, uzytkownik.Id.ToString()),
                new Claim(ClaimTypes.Name, uzytkownik.Email)
            };
            var key = new SymmetricSecurityKey
                (System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials
            );

            var jsonWebToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jsonWebToken;

        }

        public async Task<ServiceResponse<bool>> ZmianaHasla(string StareHaslo, int uzytkownikId, string noweHaslo)
        {

            var uzytkownik = await _context.Uzytkownicy.FindAsync(uzytkownikId);
            if (uzytkownik == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Nie znaleziono takiego użytkownika."
                };
            }
            else if (!WeryfikujHaslo(StareHaslo, uzytkownik.HashowaneHaslo, uzytkownik.Sol))
            { //jesli haslo sie nie zgadza
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Błędne Hasło."
                };
            }

            double entropia = CountEntropy(noweHaslo);
            if (entropia < 60)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Twoje hasło jest za słabe"  +
                    "Hasło powinno zawierać: " +
                    "duże i małe litery, " +
                    "znaki specjalne, " +
                    "liczby. " +
                    "co najmniej 8 znaków."
                };
            }

            HashPassword(noweHaslo, out byte[] Hash, out byte[] Sol);

            uzytkownik.HashowaneHaslo = Hash;
            uzytkownik.Sol = Sol;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Zmiana hasła się powiodła." };
        }

        public async Task<ServiceResponse<string>> ZapomnianeHaslo(string email)
        {
            var uzytkownik = await _context.Uzytkownicy
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

            if (uzytkownik == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Nie znaleziono użytkownika o podanym adresie e-mail"
                };
            }
            else
            {
                uzytkownik.resetPasswordToken = CreateRandomToken();
                uzytkownik.resetTokenNiewazny = DateTime.Now.AddMinutes(10);

                try
                {
                    var smtpClient = new SmtpClient("smtp.office365.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("ProjektOchronaDanych@outlook.com", "Pomarancza88"),
                        EnableSsl = true,
                    };

                    smtpClient.Send("InsulinResistanceApp@outlook.com", email, "Zmiana zapomnianego hasla. Aplikacja dla osób z insulinoopornością.", "Link do zmiany hasła w naszym " +
                        "serwisie: https://projektochronadanych.azurewebsites.net/zmiana-zapomnianego-hasla/. https://localhost:7192/zmiana-zapomnianego-hasla/ Twój tajny token:" + uzytkownik.resetPasswordToken + ". Prosimy nie odpowiadać na tą wiadomość");

                }
                catch (Exception e)
                {
                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Message = e.Message
                    };
                }

                await _context.SaveChangesAsync();
                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = "Wysłano wiadomość e-mail z linkiem do zmiany hasła"
                };

            }
        }
        public async Task<ServiceResponse<string>> NoweHaslo(string Token, string haslo)
        {
            var uzytkownik = await _context.Uzytkownicy.FirstOrDefaultAsync(u => u.resetPasswordToken == Token);
            if (uzytkownik == null || uzytkownik.resetTokenNiewazny < DateTime.Now)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Nieważny token. Najprawdopodobniej minęło ponad 10minut."
                };
            }
            HashPassword(haslo, out byte[] hashedPassword, out byte[] sol);

            uzytkownik.Sol = sol;
            uzytkownik.HashowaneHaslo = hashedPassword;
            uzytkownik.resetPasswordToken = null;
            uzytkownik.resetTokenNiewazny = null;

            await _context.SaveChangesAsync();

            return new ServiceResponse<string> { Success = true, Message = "Z powodzeniem zmieniłeś hasło" };
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

    }
}
