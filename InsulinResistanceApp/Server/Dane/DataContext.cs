﻿using System.Collections.Generic;
using System.Reflection.Emit;

namespace InsulinResistanceApp.Server.Dane
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoria>().HasData(
                new Kategoria { Id = 1, Nazwa = "Owoce" },
                new Kategoria { Id = 2, Nazwa = "Warzywa" },
                new Kategoria { Id = 3, Nazwa = "Nabiał" },
                new Kategoria { Id = 4, Nazwa = "Mięso" },
                new Kategoria { Id = 5, Nazwa = "Ryby" },
                new Kategoria { Id = 6, Nazwa = "Produkty zbożowe" },
                new Kategoria { Id = 7, Nazwa = "Słodycze" },
                new Kategoria { Id = 8, Nazwa = "Napoje" },
                new Kategoria { Id = 9, Nazwa = "Inne" }
            );
            modelBuilder.Entity<Produkt>().HasData(
                new Produkt { Id = 1, Nazwa = "Jabłka", kcal = 52, weglowodany = 14, tluszcze = 0, bialko = 0, indeksglikemiczny = 38, KategoriaId = 1 },
                new Produkt { Id = 2, Nazwa = "Banany", kcal = 89, weglowodany = 23, tluszcze = 0, bialko = 1, indeksglikemiczny = 51, KategoriaId = 1 },
                new Produkt { Id = 3, Nazwa = "Pomarańcze", kcal = 43, weglowodany = 9, tluszcze = 0, bialko = 1, indeksglikemiczny = 43, KategoriaId = 1 },
                new Produkt { Id = 4, Nazwa = "Awokado", kcal = 160, weglowodany = 9, tluszcze = 15, bialko = 2, indeksglikemiczny = 10, KategoriaId = 1 },
                new Produkt { Id = 5, Nazwa = "Chleb pełnoziarnisty", kcal = 250, weglowodany = 45, tluszcze = 4, bialko = 10, indeksglikemiczny = 50, KategoriaId = 6 },
                new Produkt { Id = 6, Nazwa = "Masło orzechowe", kcal = 588, weglowodany = 20, tluszcze = 50, bialko = 25, indeksglikemiczny = 30, KategoriaId = 9 },
                new Produkt { Id = 7, Nazwa = "Jogurt naturalny", kcal = 61, weglowodany = 4, tluszcze = 3, bialko = 10, indeksglikemiczny = 36, KategoriaId = 3 },
                new Produkt { Id = 8, Nazwa = "Mleko 2%", kcal = 50, weglowodany = 5, tluszcze = 2, bialko = 3, indeksglikemiczny = 30, KategoriaId = 3 },
                new Produkt { Id = 9, Nazwa = "Twaróg", kcal = 174, weglowodany = 3, tluszcze = 9, bialko = 18, indeksglikemiczny = 45, KategoriaId = 3 },
                new Produkt { Id = 10, Nazwa = "Kurczak", kcal = 239, weglowodany = 0, tluszcze = 14, bialko = 27, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 11, Nazwa = "Łosoś", kcal = 208, weglowodany = 0, tluszcze = 13, bialko = 20, indeksglikemiczny = 0, KategoriaId = 5 },
                new Produkt { Id = 12, Nazwa = "Jajko", kcal = 68, weglowodany = 1, tluszcze = 5, bialko = 6, indeksglikemiczny = 0, KategoriaId = 3 },
                new Produkt { Id = 13, Nazwa = "Ryż brązowy", kcal = 111, weglowodany = 23, tluszcze = 1, bialko = 2, indeksglikemiczny = 50, KategoriaId = 6 },
                new Produkt { Id = 14, Nazwa = "Makaron pełnoziarnisty", kcal = 158, weglowodany = 31, tluszcze = 1, bialko = 7, indeksglikemiczny = 40, KategoriaId = 6 },
                new Produkt { Id = 15, Nazwa = "Oliwa z oliwek", kcal = 884, weglowodany = 0, tluszcze = 100, bialko = 0, indeksglikemiczny = 0, KategoriaId = 9 },
                new Produkt { Id = 16, Nazwa = "Orzechy włoskie", kcal = 654, weglowodany = 14, tluszcze = 65, bialko = 16, indeksglikemiczny = 15, KategoriaId = 9 },
                new Produkt { Id = 17, Nazwa = "Kasza jaglana", kcal = 346, weglowodany = 77, tluszcze = 1, bialko = 8, indeksglikemiczny = 40, KategoriaId = 6 },
                new Produkt { Id = 18, Nazwa = "Owies", kcal = 389, weglowodany = 66, tluszcze = 7, bialko = 17, indeksglikemiczny = 50, KategoriaId = 6 },
                new Produkt { Id = 19, Nazwa = "Czekolada gorzka", kcal = 546, weglowodany = 31, tluszcze = 32, bialko = 5, indeksglikemiczny = 22, KategoriaId = 7 },
                new Produkt { Id = 20, Nazwa = "Czosnek", kcal = 149, weglowodany = 33, tluszcze = 0, bialko = 6, indeksglikemiczny = 30, KategoriaId = 2 },
                new Produkt { Id = 21, Nazwa = "Cebula", kcal = 40, weglowodany = 9, tluszcze = 0, bialko = 1, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 22, Nazwa = "Brokuły", kcal = 34, weglowodany = 7, tluszcze = 0, bialko = 3, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 23, Nazwa = "Papryka czerwona", kcal = 31, weglowodany = 7, tluszcze = 0, bialko = 1, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 24, Nazwa = "Pomidor", kcal = 18, weglowodany = 4, tluszcze = 0, bialko = 1, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 25, Nazwa = "Tymianek", kcal = 276, weglowodany = 64, tluszcze = 7, bialko = 9, indeksglikemiczny = 15, KategoriaId = 9 },
                new Produkt { Id = 26, Nazwa = "Sól", kcal = 0, weglowodany = 0, tluszcze = 0, bialko = 0, indeksglikemiczny = 0, KategoriaId = 9 },
                new Produkt { Id = 27, Nazwa = "Pieprz", kcal = 251, weglowodany = 64, tluszcze = 3, bialko = 10, indeksglikemiczny = 15, KategoriaId = 9 },
                new Produkt { Id = 28, Nazwa = "Kurkuma", kcal = 354, weglowodany = 65, tluszcze = 10, bialko = 8, indeksglikemiczny = 0, KategoriaId = 9 },
                new Produkt { Id = 29, Nazwa = "Chili", kcal = 40, weglowodany = 9, tluszcze = 0, bialko = 2, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 30, Nazwa = "Kawa", kcal = 1, weglowodany = 0, tluszcze = 0, bialko = 0, indeksglikemiczny = 0, KategoriaId = 8 },
                new Produkt { Id = 31, Nazwa = "Herbata", kcal = 1, weglowodany = 0, tluszcze = 0, bialko = 0, indeksglikemiczny = 0, KategoriaId = 8 },
                new Produkt { Id = 32, Nazwa = "Miod", kcal = 304, weglowodany = 82, tluszcze = 0, bialko = 0, indeksglikemiczny = 50, KategoriaId = 7 },
                new Produkt { Id = 33, Nazwa = "Cytryna", kcal = 29, weglowodany = 9, tluszcze = 0, bialko = 1, indeksglikemiczny = 20, KategoriaId = 1 },
                new Produkt { Id = 34, Nazwa = "Liczi", kcal = 66, weglowodany = 16, tluszcze = 0, bialko = 0, indeksglikemiczny = 50, KategoriaId = 1 },
                new Produkt { Id = 35, Nazwa = "Winogrona", kcal = 69, weglowodany = 18, tluszcze = 0, bialko = 1, indeksglikemiczny = 59, KategoriaId = 1 },
                new Produkt { Id = 36, Nazwa = "Truskawki", kcal = 32, weglowodany = 8, tluszcze = 0, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 37, Nazwa = "Pizza Margherita", kcal = 266, weglowodany = 32, tluszcze = 9, bialko = 12, indeksglikemiczny = 30, KategoriaId = 9 },
                new Produkt { Id = 38, Nazwa = "Sałatka grecka", kcal = 159, weglowodany = 11, tluszcze = 10, bialko = 7, indeksglikemiczny = 15, KategoriaId = 2 },
                new Produkt { Id = 39, Nazwa = "Czekolada mleczna", kcal = 535, weglowodany = 58, tluszcze = 30, bialko = 8, indeksglikemiczny = 40, KategoriaId = 7 },
                new Produkt { Id = 40, Nazwa = "Burger wołowy", kcal = 254, weglowodany = 28, tluszcze = 14, bialko = 12, indeksglikemiczny = 30, KategoriaId = 4 },
                new Produkt { Id = 41, Nazwa = "Kanapka z szynką", kcal = 210, weglowodany = 23, tluszcze = 8, bialko = 12, indeksglikemiczny = 30, KategoriaId = 4 },
                new Produkt { Id = 42, Nazwa = "Owsianka z miodem", kcal = 230, weglowodany = 50, tluszcze = 4, bialko = 6, indeksglikemiczny = 40, KategoriaId = 6 },
                new Produkt { Id = 43, Nazwa = "Kiełbasa", kcal = 331, weglowodany = 2, tluszcze = 30, bialko = 15, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 44, Nazwa = "Lody waniliowe", kcal = 207, weglowodany = 25, tluszcze = 11, bialko = 3, indeksglikemiczny = 40, KategoriaId = 7 },
                new Produkt { Id = 45, Nazwa = "Chipsy ziemniaczane", kcal = 536, weglowodany = 50, tluszcze = 34, bialko = 6, indeksglikemiczny = 75, KategoriaId = 7 },
                new Produkt { Id = 46, Nazwa = "Herbata z cukrem", kcal = 43, weglowodany = 11, tluszcze = 0, bialko = 0, indeksglikemiczny = 65, KategoriaId = 8 },
                new Produkt { Id = 47, Nazwa = "Kawa z mlekiem i cukrem", kcal = 43, weglowodany = 7, tluszcze = 1, bialko = 1, indeksglikemiczny = 45, KategoriaId = 8 },
                new Produkt { Id = 48, Nazwa = "Coca-Cola", kcal = 42, weglowodany = 11, tluszcze = 0, bialko = 0, indeksglikemiczny = 63, KategoriaId = 8 },
                new Produkt { Id = 49, Nazwa = "Sałatka owocowa z majonezem", kcal = 210, weglowodany = 45, tluszcze = 5, bialko = 3, indeksglikemiczny = 40, KategoriaId = 2 },
                new Produkt { Id = 50, Nazwa = "Ciastka czekoladowe", kcal = 480, weglowodany = 63, tluszcze = 22, bialko = 5, indeksglikemiczny = 50, KategoriaId = 7 },
                new Produkt { Id = 51, Nazwa = "Orzechy nerkowca", kcal = 553, weglowodany = 30, tluszcze = 44, bialko = 18, indeksglikemiczny = 20, KategoriaId = 7 },
                new Produkt { Id = 52, Nazwa = "Lody czekoladowe", kcal = 216, weglowodany = 28, tluszcze = 12, bialko = 3, indeksglikemiczny = 40, KategoriaId = 7 },
                new Produkt { Id = 53, Nazwa = "Jogurt owocowy", kcal = 85, weglowodany = 15, tluszcze = 2, bialko = 4, indeksglikemiczny = 35, KategoriaId = 3 },
                new Produkt { Id = 54, Nazwa = "Kurczak pieczony", kcal = 165, weglowodany = 0, tluszcze = 3, bialko = 31, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 55, Nazwa = "Makaron biały", kcal = 158, weglowodany = 31, tluszcze = 1, bialko = 5, indeksglikemiczny = 50, KategoriaId = 5 },
                new Produkt { Id = 56, Nazwa = "Chipsy kukurydziane", kcal = 536, weglowodany = 51, tluszcze = 35, bialko = 6, indeksglikemiczny = 85, KategoriaId = 7 },
                new Produkt { Id = 57, Nazwa = "Sok pomarańczowy", kcal = 45, weglowodany = 11, tluszcze = 0, bialko = 1, indeksglikemiczny = 40, KategoriaId = 8 },
                new Produkt { Id = 58, Nazwa = "Pączek", kcal = 280, weglowodany = 31, tluszcze = 16, bialko = 4, indeksglikemiczny = 70, KategoriaId = 7 },
                new Produkt { Id = 59, Nazwa = "Czekolada gorzka 70%", kcal = 581, weglowodany = 45, tluszcze = 42, bialko = 7, indeksglikemiczny = 30, KategoriaId = 7 },
                new Produkt { Id = 60, Nazwa = "Ryż biały", kcal = 130, weglowodany = 28, tluszcze = 0, bialko = 3, indeksglikemiczny = 70, KategoriaId = 5 },
                new Produkt { Id = 61, Nazwa = "Ser żółty", kcal = 402, weglowodany = 2, tluszcze = 33, bialko = 25, indeksglikemiczny = 0, KategoriaId = 3 },
                new Produkt { Id = 62, Nazwa = "Piwo", kcal = 43, weglowodany = 3, tluszcze = 0, bialko = 1, indeksglikemiczny = 55, KategoriaId = 8 },
                new Produkt { Id = 63, Nazwa = "Wódka", kcal = 231, weglowodany = 0, tluszcze = 0, bialko = 0, indeksglikemiczny = 0, KategoriaId = 8 },
                new Produkt { Id = 64, Nazwa = "Szpinak", kcal = 23, weglowodany = 3, tluszcze = 0, bialko = 2, indeksglikemiczny = 15, KategoriaId = 2 },
                new Produkt { Id = 65, Nazwa = "Mleko kozie", kcal = 68, weglowodany = 4, tluszcze = 5, bialko = 3, indeksglikemiczny = 30, KategoriaId = 4 },
                new Produkt { Id = 66, Nazwa = "Olej rzepakowy", kcal = 884, weglowodany = 0, tluszcze = 100, bialko = 0, indeksglikemiczny = 0, KategoriaId = 9 },
                new Produkt { Id = 67, Nazwa = "Mleko sojowe", kcal = 33, weglowodany = 1, tluszcze = 1, bialko = 3, indeksglikemiczny = 20, KategoriaId = 4 },
                new Produkt { Id = 68, Nazwa = "Tofu", kcal = 76, weglowodany = 1, tluszcze = 4, bialko = 8, indeksglikemiczny = 15, KategoriaId = 4 },
                new Produkt { Id = 69, Nazwa = "Quinoa", kcal = 120, weglowodany = 21, tluszcze = 2, bialko = 4, indeksglikemiczny = 53, KategoriaId = 5 },
                new Produkt { Id = 70, Nazwa = "Jabłka suszone", kcal = 243, weglowodany = 63, tluszcze = 0, bialko = 2, indeksglikemiczny = 38, KategoriaId = 1 },
                new Produkt { Id = 71, Nazwa = "Mango", kcal = 60, weglowodany = 15, tluszcze = 0, bialko = 1, indeksglikemiczny = 51, KategoriaId = 1 },
                new Produkt { Id = 72, Nazwa = "Orzechy laskowe", kcal = 628, weglowodany = 20, tluszcze = 61, bialko = 15, indeksglikemiczny = 15, KategoriaId = 7 },
                new Produkt { Id = 73, Nazwa = "Kawa z syropem waniliowym", kcal = 293, weglowodany = 42, tluszcze = 7, bialko = 3, indeksglikemiczny = 45, KategoriaId = 8 },
                new Produkt { Id = 74, Nazwa = "Kiełki lucerny", kcal = 23, weglowodany = 4, tluszcze = 0, bialko = 4, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 75, Nazwa = "Kasza gryczana", kcal = 335, weglowodany = 70, tluszcze = 3, bialko = 13, indeksglikemiczny = 50, KategoriaId = 5 },
                new Produkt { Id = 76, Nazwa = "Kapusta kiszona", kcal = 19, weglowodany = 4, tluszcze = 0, bialko = 1, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 77, Nazwa = "Woda gazowana", kcal = 0, weglowodany = 0, tluszcze = 0, bialko = 0, indeksglikemiczny = 0, KategoriaId = 8 },
                new Produkt { Id = 78, Nazwa = "Mięta", kcal = 70, weglowodany = 14, tluszcze = 1, bialko = 4, indeksglikemiczny = 15, KategoriaId = 2 },
                new Produkt { Id = 79, Nazwa = "Miód", kcal = 304, weglowodany = 82, tluszcze = 0, bialko = 0, indeksglikemiczny = 50, KategoriaId = 4 },
                new Produkt { Id = 80, Nazwa = "Kurkuma", kcal = 354, weglowodany = 65, tluszcze = 10, bialko = 8, indeksglikemiczny = 0, KategoriaId = 2 },
                new Produkt { Id = 81, Nazwa = "Sardynki w oleju", kcal = 208, weglowodany = 0, tluszcze = 11, bialko = 25, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 82, Nazwa = "Krewetki", kcal = 85, weglowodany = 0, tluszcze = 1, bialko = 18, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 83, Nazwa = "Czarna porzeczka", kcal = 56, weglowodany = 14, tluszcze = 0, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 84, Nazwa = "Sushi z łososiem", kcal = 132, weglowodany = 22, tluszcze = 3, bialko = 4, indeksglikemiczny = 45, KategoriaId = 4 },
                new Produkt { Id = 85, Nazwa = "Awokado", kcal = 160, weglowodany = 9, tluszcze = 15, bialko = 2, indeksglikemiczny = 10, KategoriaId = 1 },
                new Produkt { Id = 86, Nazwa = "Migdały", kcal = 575, weglowodany = 22, tluszcze = 49, bialko = 21, indeksglikemiczny = 0, KategoriaId = 7 },
                new Produkt { Id = 87, Nazwa = "Pomarańczowy sok", kcal = 45, weglowodany = 11, tluszcze = 0, bialko = 1, indeksglikemiczny = 45, KategoriaId = 8 },
                new Produkt { Id = 88, Nazwa = "Granola", kcal = 471, weglowodany = 58, tluszcze = 20, bialko = 12, indeksglikemiczny = 55, KategoriaId = 5 },
                new Produkt { Id = 89, Nazwa = "Kokosowe mleko", kcal = 230, weglowodany = 6, tluszcze = 23, bialko = 2, indeksglikemiczny = 45, KategoriaId = 4 },
                new Produkt { Id = 90, Nazwa = "Banany suszone", kcal = 346, weglowodany = 87, tluszcze = 1, bialko = 3, indeksglikemiczny = 65, KategoriaId = 1 },
                new Produkt { Id = 91, Nazwa = "Grapefruit", kcal = 42, weglowodany = 11, tluszcze = 0, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 92, Nazwa = "Kurkuma w proszku", kcal = 312, weglowodany = 68, tluszcze = 3, bialko = 9, indeksglikemiczny = 0, KategoriaId = 2 },
                new Produkt { Id = 93, Nazwa = "Herbata zielona", kcal = 1, weglowodany = 0, tluszcze = 0, bialko = 0, indeksglikemiczny = 0, KategoriaId = 8 },
                new Produkt { Id = 94, Nazwa = "Woda kokosowa", kcal = 19, weglowodany = 4, tluszcze = 0, bialko = 0, indeksglikemiczny = 45, KategoriaId = 8 },
                new Produkt { Id = 95, Nazwa = "Czosnek", kcal = 149, weglowodany = 33, tluszcze = 0, bialko = 6, indeksglikemiczny = 30, KategoriaId = 2 },
                new Produkt { Id = 96, Nazwa = "Bób", kcal = 341, weglowodany = 63, tluszcze = 1, bialko = 27, indeksglikemiczny = 20, KategoriaId = 2 },
                new Produkt { Id = 97, Nazwa = "Pietruszka", kcal = 45, weglowodany = 10, tluszcze = 0, bialko = 4, indeksglikemiczny = 20, KategoriaId = 2 },
                new Produkt { Id = 98, Nazwa = "Jogurt naturalny", kcal = 61, weglowodany = 4, tluszcze = 3, bialko = 10, indeksglikemiczny = 36, KategoriaId = 3 },
                new Produkt { Id = 99, Nazwa = "Ryż basmati", kcal = 130, weglowodany = 28, tluszcze = 0, bialko = 3, indeksglikemiczny = 58, KategoriaId = 6 },
                new Produkt { Id = 100, Nazwa = "Migdałowe mleko", kcal = 56, weglowodany = 1, tluszcze = 5, bialko = 1, indeksglikemiczny = 25, KategoriaId = 3 },
                new Produkt { Id = 101, Nazwa = "Sok jabłkowy", kcal = 46, weglowodany = 12, tluszcze = 0, bialko = 0, indeksglikemiczny = 40, KategoriaId = 8 },
                new Produkt { Id = 102, Nazwa = "Tahini", kcal = 595, weglowodany = 17, tluszcze = 53, bialko = 17, indeksglikemiczny = 0, KategoriaId = 9 },
                new Produkt { Id = 103, Nazwa = "Oliwa z oliwek", kcal = 884, weglowodany = 0, tluszcze = 100, bialko = 0, indeksglikemiczny = 0, KategoriaId = 9 },
                new Produkt { Id = 104, Nazwa = "Truskawki", kcal = 32, weglowodany = 8, tluszcze = 0, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 105, Nazwa = "Jabłko", kcal = 52, weglowodany = 14, tluszcze = 0, bialko = 0, indeksglikemiczny = 38, KategoriaId = 1 },
                new Produkt { Id = 106, Nazwa = "Mango", kcal = 60, weglowodany = 15, tluszcze = 0, bialko = 1, indeksglikemiczny = 51, KategoriaId = 1 },
                new Produkt { Id = 107, Nazwa = "Maliny", kcal = 52, weglowodany = 12, tluszcze = 0, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 108, Nazwa = "Ananas", kcal = 50, weglowodany = 13, tluszcze = 0, bialko = 0, indeksglikemiczny = 66, KategoriaId = 1 },
                new Produkt { Id = 109, Nazwa = "Ogórek", kcal = 15, weglowodany = 3, tluszcze = 0, bialko = 1, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 110, Nazwa = "Marchew", kcal = 41, weglowodany = 10, tluszcze = 0, bialko = 1, indeksglikemiczny = 35, KategoriaId = 2 },
                new Produkt { Id = 111, Nazwa = "Szpinak", kcal = 23, weglowodany = 3, tluszcze = 0, bialko = 2, indeksglikemiczny = 15, KategoriaId = 2 },
                new Produkt { Id = 112, Nazwa = "Banan", kcal = 89, weglowodany = 23, tluszcze = 0, bialko = 1, indeksglikemiczny = 51, KategoriaId = 2 },
                new Produkt { Id = 113, Nazwa = "Kasza jaglana", kcal = 346, weglowodany = 77, tluszcze = 1, bialko = 8, indeksglikemiczny = 40, KategoriaId = 6 },
                new Produkt { Id = 114, Nazwa = "Orzechy włoskie", kcal = 654, weglowodany = 14, tluszcze = 65, bialko = 16, indeksglikemiczny = 15, KategoriaId = 9 },
                new Produkt { Id = 115, Nazwa = "Kurczak", kcal = 239, weglowodany = 0, tluszcze = 14, bialko = 27, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 116, Nazwa = "Losos", kcal = 208, weglowodany = 0, tluszcze = 13, bialko = 20, indeksglikemiczny = 0, KategoriaId = 5 },
                new Produkt { Id = 117, Nazwa = "Jajko", kcal = 68, weglowodany = 1, tluszcze = 5, bialko = 6, indeksglikemiczny = 0, KategoriaId = 3 },
                new Produkt { Id = 118, Nazwa = "Czekolada gorzka", kcal = 546, weglowodany = 31, tluszcze = 32, bialko = 5, indeksglikemiczny = 22, KategoriaId = 7 },
                new Produkt { Id = 119, Nazwa = "Czekolada mleczna", kcal = 535, weglowodany = 58, tluszcze = 30, bialko = 8, indeksglikemiczny = 40, KategoriaId = 7 },
                new Produkt { Id = 120, Nazwa = "Mleko", kcal = 42, weglowodany = 5, tluszcze = 2, bialko = 3, indeksglikemiczny = 30, KategoriaId = 3 },
                new Produkt { Id = 121, Nazwa = "Herbata", kcal = 1, weglowodany = 0, tluszcze = 0, bialko = 0, indeksglikemiczny = 0, KategoriaId = 8 },
                new Produkt { Id = 122, Nazwa = "Coca-Cola", kcal = 42, weglowodany = 11, tluszcze = 0, bialko = 0, indeksglikemiczny = 63, KategoriaId = 8 },
                new Produkt { Id = 123, Nazwa = "Kawa", kcal = 1, weglowodany = 0, tluszcze = 0, bialko = 0, indeksglikemiczny = 0, KategoriaId = 8 },
                new Produkt { Id = 124, Nazwa = "Arbuz", kcal = 30, weglowodany = 8, tluszcze = 0, bialko = 1, indeksglikemiczny = 70, KategoriaId = 1 },
                new Produkt { Id = 125, Nazwa = "Brzoskwinia", kcal = 39, weglowodany = 10, tluszcze = 0, bialko = 1, indeksglikemiczny = 28, KategoriaId = 1 },
                new Produkt { Id = 126, Nazwa = "Kiwi", kcal = 61, weglowodany = 15, tluszcze = 0, bialko = 1, indeksglikemiczny = 52, KategoriaId = 1 },
                new Produkt { Id = 127, Nazwa = "Granat", kcal = 83, weglowodany = 19, tluszcze = 1, bialko = 1, indeksglikemiczny = 53, KategoriaId = 1 },
                new Produkt { Id = 128, Nazwa = "Śliwki", kcal = 46, weglowodany = 11, tluszcze = 0, bialko = 1, indeksglikemiczny = 39, KategoriaId = 1 },
                new Produkt { Id = 129, Nazwa = "Mandarynki", kcal = 53, weglowodany = 13, tluszcze = 0, bialko = 1, indeksglikemiczny = 47, KategoriaId = 1 },
                new Produkt { Id = 130, Nazwa = "Czarna porzeczka", kcal = 56, weglowodany = 14, tluszcze = 0, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 131, Nazwa = "Kumkwat", kcal = 71, weglowodany = 16, tluszcze = 0, bialko = 2, indeksglikemiczny = 40, KategoriaId = 1 },
                new Produkt { Id = 132, Nazwa = "Liczi", kcal = 66, weglowodany = 17, tluszcze = 0, bialko = 1, indeksglikemiczny = 50, KategoriaId = 1 },
                new Produkt { Id = 133, Nazwa = "Papaja", kcal = 43, weglowodany = 11, tluszcze = 0, bialko = 1, indeksglikemiczny = 59, KategoriaId = 1 },
                new Produkt { Id = 134, Nazwa = "Czereśnie", kcal = 63, weglowodany = 16, tluszcze = 0, bialko = 1, indeksglikemiczny = 22, KategoriaId = 1 },
                new Produkt { Id = 135, Nazwa = "Nektarynka", kcal = 44, weglowodany = 11, tluszcze = 0, bialko = 1, indeksglikemiczny = 32, KategoriaId = 1 },
                new Produkt { Id = 136, Nazwa = "Jeżyny", kcal = 43, weglowodany = 10, tluszcze = 1, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 137, Nazwa = "Granat", kcal = 83, weglowodany = 19, tluszcze = 1, bialko = 1, indeksglikemiczny = 53, KategoriaId = 1 },
                new Produkt { Id = 138, Nazwa = "Papryka czerwona", kcal = 31, weglowodany = 7, tluszcze = 0, bialko = 1, indeksglikemiczny = 30, KategoriaId = 2 },
                new Produkt { Id = 139, Nazwa = "Malina", kcal = 52, weglowodany = 12, tluszcze = 0, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 140, Nazwa = "Truskawka", kcal = 32, weglowodany = 8, tluszcze = 0, bialko = 1, indeksglikemiczny = 25, KategoriaId = 1 },
                new Produkt { Id = 141, Nazwa = "Por", kcal = 31, weglowodany = 7, tluszcze = 0, bialko = 2, indeksglikemiczny = 15, KategoriaId = 2 },
                new Produkt { Id = 142, Nazwa = "Rzodkiewka", kcal = 16, weglowodany = 3, tluszcze = 0, bialko = 1, indeksglikemiczny = 15, KategoriaId = 2 },
                new Produkt { Id = 143, Nazwa = "Dynia", kcal = 26, weglowodany = 6, tluszcze = 0, bialko = 1, indeksglikemiczny = 75, KategoriaId = 2 },
                new Produkt { Id = 144, Nazwa = "Kapusta pekińska", kcal = 13, weglowodany = 3, tluszcze = 0, bialko = 1, indeksglikemiczny = 10, KategoriaId = 2 },
                new Produkt { Id = 145, Nazwa = "Kalafior", kcal = 25, weglowodany = 5, tluszcze = 0, bialko = 2, indeksglikemiczny = 15, KategoriaId = 2 },
                new Produkt { Id = 146, Nazwa = "Mleko krowie", kcal = 42, weglowodany = 5, tluszcze = 2, bialko = 3, indeksglikemiczny = 30, KategoriaId = 3 },
                new Produkt { Id = 147, Nazwa = "Ser biały", kcal = 98, weglowodany = 4, tluszcze = 5, bialko = 10, indeksglikemiczny = 35, KategoriaId = 3 },
                new Produkt { Id = 148, Nazwa = "Jogurt naturalny", kcal = 61, weglowodany = 4, tluszcze = 3, bialko = 10, indeksglikemiczny = 36, KategoriaId = 3 },
                new Produkt { Id = 149, Nazwa = "Twaróg", kcal = 103, weglowodany = 3, tluszcze = 5, bialko = 18, indeksglikemiczny = 30, KategoriaId = 3 },
                new Produkt { Id = 150, Nazwa = "Masło", kcal = 717, weglowodany = 0, tluszcze = 81, bialko = 1, indeksglikemiczny = 0, KategoriaId = 9 },
                new Produkt { Id = 151, Nazwa = "Kurczak", kcal = 239, weglowodany = 0, tluszcze = 14, bialko = 27, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 152, Nazwa = "Wołowina", kcal = 250, weglowodany = 0, tluszcze = 16, bialko = 28, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 153, Nazwa = "Śledź", kcal = 203, weglowodany = 0, tluszcze = 14, bialko = 18, indeksglikemiczny = 0, KategoriaId = 5 },
                new Produkt { Id = 154, Nazwa = "Szynka", kcal = 101, weglowodany = 1, tluszcze = 4, bialko = 15, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 155, Nazwa = "Indyk", kcal = 135, weglowodany = 0, tluszcze = 3, bialko = 30, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 156, Nazwa = "Kiełbasa", kcal = 325, weglowodany = 2, tluszcze = 29, bialko = 14, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 157, Nazwa = "Boczek", kcal = 458, weglowodany = 0, tluszcze = 45, bialko = 9, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 158, Nazwa = "Żółtko jajka", kcal = 322, weglowodany = 1, tluszcze = 27, bialko = 17, indeksglikemiczny = 0, KategoriaId = 3 },
                new Produkt { Id = 159, Nazwa = "Wieprzowina", kcal = 242, weglowodany = 0, tluszcze = 17, bialko = 21, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 160, Nazwa = "Kaczka", kcal = 337, weglowodany = 0, tluszcze = 27, bialko = 24, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 161, Nazwa = "Cielęcina", kcal = 111, weglowodany = 0, tluszcze = 3, bialko = 21, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 162, Nazwa = "Baranina", kcal = 294, weglowodany = 0, tluszcze = 23, bialko = 22, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 163, Nazwa = "Kurczak", kcal = 239, weglowodany = 0, tluszcze = 14, bialko = 27, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 164, Nazwa = "Indyk", kcal = 135, weglowodany = 0, tluszcze = 3, bialko = 30, indeksglikemiczny = 0, KategoriaId = 4 },
                new Produkt { Id = 165, Nazwa = "Jajko", kcal = 68, weglowodany = 1, tluszcze = 5, bialko = 6, indeksglikemiczny = 0, KategoriaId = 3 },
                new Produkt { Id = 166, Nazwa = "Tunczyk", kcal = 116, weglowodany = 0, tluszcze = 1, bialko = 26, indeksglikemiczny = 0, KategoriaId = 5 }
            );
        }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
    }


}
