namespace Transivo.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Transivo.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Transivo.DAL.Concrete.EntityFramework.TransivoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Transivo.DAL.Concrete.EntityFramework.TransivoDbContext context)
        {
            List<UserRole> userRoles = new List<UserRole>();
            userRoles.Add(new UserRole { RoleName = "Standart" });
            userRoles.Add(new UserRole { RoleName = "Guest" });
            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();

            List<AdminRole> adminRoles = new List<AdminRole>();
            adminRoles.Add(new AdminRole { Name = "System Admin" });
            adminRoles.Add(new AdminRole { Name = "Company Admin" });
            context.AdminRoles.AddRange(adminRoles);
            context.SaveChanges();

            List<Country> countries = new List<Country>();
            countries.Add(new Country { Name = "T�rkiye" });
            context.Countries.AddRange(countries);
            context.SaveChanges();

            List<City> cities = new List<City>();
            cities.Add(new City { Name = "Adana", Country = countries[0] });
            cities.Add(new City { Name = "Ankara", Country = countries[0] });
            cities.Add(new City { Name = "Antalya", Country = countries[0] });
            cities.Add(new City { Name = "Bursa", Country = countries[0] });
            cities.Add(new City { Name = "Bilecik", Country = countries[0] });
            cities.Add(new City { Name = "�stanbul", Country = countries[0] });
            cities.Add(new City { Name = "�zmir", Country = countries[0] });
            context.Cities.AddRange(cities);
            context.SaveChanges();

            List<District> districts = new List<District>();
            districts.Add(new District { Name = "Ceyhan", City = cities[0] });
            districts.Add(new District { Name = "�ukurova", City = cities[0] });
            districts.Add(new District { Name = "�ankaya", City = cities[1] });
            districts.Add(new District { Name = "Ulus", City = cities[1] });
            districts.Add(new District { Name = "Kepez", City = cities[2] });
            districts.Add(new District { Name = "Uluda�", City = cities[3] });
            districts.Add(new District { Name = "Gemlik", City = cities[3] });
            districts.Add(new District { Name = "Osmangazi", City = cities[3] });
            districts.Add(new District { Name = "Ayval�k", City = cities[4] });
            districts.Add(new District { Name = "Band�rma", City = cities[4] });
            districts.Add(new District { Name = "Maltepe", City = cities[5] });
            districts.Add(new District { Name = "Ata�ehir", City = cities[5] });
            districts.Add(new District { Name = "K���kyal�", City = cities[5] });
            districts.Add(new District { Name = "Kad�k�y", City = cities[5] });
            districts.Add(new District { Name = "�i�li", City = cities[6] });
            districts.Add(new District { Name = "Merkez", City = cities[6] });
            context.Districts.AddRange(districts);
            context.SaveChanges();

            List<Address> addresses = new List<Address>();
            addresses.Add(new Address { District = districts[10], AddresssDetail = "F�nd�kl� Mah. Atat�rk Cad. F�rat Sok. No:10", Name = "Ev" });
            context.Addresses.AddRange(addresses);
            context.SaveChanges();

            addresses.Add(new Address { District = districts[0], AddresssDetail = "G�ndo�du mahallesi 2473 sokak no:3", Name = "Evim" });
            context.Addresses.AddRange(addresses);
            context.SaveChanges();

            Company company = new Company();
            company.About = "2003 y�l�nda kurulan MNG Kargo 800�den fazla �ubesi, 7 tanesi Teknolojik Aktarma Merkezi olmak �zere toplam 25 aktarma merkezi, 14 b�lge m�d�rl���, 6500�� kendi b�nyesinde, 3500�� ise acentelerinde olmak �zere 10000�e yak�n �al��an�, 3000 kara ta��ma arac� ile hizmet vermektedir. MNG Kargo, T�rkiye�nin bir ucundan di�er ucuna ve d�nyada 220 farkl� �lkede, g�nde 700 bin adrese d�nya standartlar�nda hizmet ula�t�ran T�rkiye�nin lider kargo �irketlerindendir.";
            company.Freight = 50.65M;
            company.IsActive = true;
            company.LogoPath = "https://www.mngkargo.com.tr/images/logo.png";
            company.Phone = "905052673737";
            company.TaxNumber = "MNG1021";
            company.CreatedDate = DateTime.Now;
            company.CompanyName = "MNG Kargo";
            context.Companies.Add(company);
            context.SaveChanges();

            Admin companyAdmin = new Admin();
            companyAdmin.Company = company;
            companyAdmin.AdminRole = adminRoles[1];
            companyAdmin.EMail = "mng@mng.com";
            companyAdmin.Password = "mng";
            companyAdmin.Username = "mngAdmin";
            companyAdmin.IsActive = true;

            context.Admins.Add(companyAdmin);
            context.SaveChanges();

            Company company1 = new Company();
            company1.About = @"Yurti�i Kargo, 'S�z Verdi�imiz Gibi' slogan�ndan hareketle 1982 y�l�nda, Dr. �brahim Ar�kan liderli�inde ve Ar�kanl� Holding �at�s� alt�nda, T�rkiye�deki ilk T�rk kargo markas� olarak kurulmu�tur. G�n�m�zde, 17 B�lge M�d�rl���, 33 Aktarma Merkezi, 880�den fazla �ubesi, 15.000�den fazla �al��an� ve 4000�in �zerinde ara� filosu ile T�rkiye'nin 81 ilinde ve Kuzey K�br�s T�rk Cumhuriyeti'nde hizmet sunan Yurti�i Kargo, 2003 y�l�ndan bu yana Avrupa�n�n en b�y�k kargo �irketlerinden biri olan ��z�m orta�� Geopost ile birlikte m��terilerinin uluslararas� g�nderilerini d�nyada 220�den fazla noktaya, bir ba�ka deyi�le d�nyan�n her yerine ta��maktad�r. ";

            company1.Freight = 50.10M;
            company1.IsActive = true;
            company1.LogoPath = "https://www.yurticikargo.com/web_files/yurtici-kargo/Uploads/yk-haberler.jpg";
            company1.Phone = "905052673738";
            company1.TaxNumber = "TK1021";
            company1.CreatedDate = DateTime.Now;
            company1.CompanyName = "Yurti�i Kargo";
            context.Companies.Add(company1);
            context.SaveChanges();

            Company company2 = new Company();
            company2.About = "1979 y�l�nda Celal Aras taraf�ndan kurulan Aras Da��t�m ve Pazarlama, eri�ti�i da��t�m a�� g�c�yle, bu g�c�n ta��mac�l�kta da kullan�lmas� karar� al�narak 1989'da faaliyete ge�en Aras Kargo'nun da temellerini olu�turmu�tur.";
            company2.Freight = 40.15M;
            company2.IsActive = true;
            company2.LogoPath = "https://www.evrensel.net/images/840/upload/dosya/132093.jpg";
            company2.Phone = "905052673739";
            company2.TaxNumber = "AK1021";
            company2.CreatedDate = DateTime.Now;
            company2.CompanyName = "Aras Kargo";
            context.Companies.Add(company2);
            context.SaveChanges();



            Company company3 = new Company();
            company3.About = @"S�rat Kargo 2003 y�l�n�n Temmuz ay�nda kuruldu. Kargo sekt�r�n�n en gen� markalar�ndan biri olarak k�sa zamanda en �nemli oyuncular� aras�nda yerini ald�. Bug�n 700�e yak�n �ube, 1600 ara�l�k dev filosu, 1100 �zerinde mobil da��t�m alan�, 5000�i a�k�n personeli ile g�nderilerinizi T�rkiye'nin her yerine ve d�nyan�n 228 �lkesine g�venle ta��yor.

Kurumsal ya da bireysel diye ay�rmadan t�m m��terilerinin gereksinimlerini onlardan �nce d���nerek yeni teknolojiler ve hizmetler geli�tiriyor.G�nderilerinize en az sizin kadar de�er veriyor ve bekleyenin de g�nderenin de i�i rahat olsun diye gece g�nd�z �al���yor.";
            company3.Freight = 50.00M;
            company3.IsActive = true;
            company3.LogoPath = "http://destek.tsoft.com.tr/upload/omer/surat_kargo_logo.png";
            company3.Phone = "905052673740";
            company3.TaxNumber = "SK1021";
            company3.CreatedDate = DateTime.Now;
            company3.CompanyName = "S�rat Kargo";
            context.Companies.Add(company3);
            context.SaveChanges();

            Company company4 = new Company();
            company4.About = @"Transivo, Nakliye Firmalar� ve nakliye talebi olan ki�ileri bulu�turmay� ama�layan bir platformudur.";
            company4.Freight = 0;
            company4.IsActive = true;
            company4.LogoPath = "";
            company4.Phone = "905055555555";
            company4.TaxNumber = "TS1021";
            company4.CreatedDate = DateTime.Now;
            company4.CompanyName = "Transivo";
            context.Companies.Add(company4);
            context.SaveChanges();

            Admin admin = new Admin();
            admin.Company = company4;
            admin.AdminRole = adminRoles[0];
            admin.EMail = "admin@transivo.com";
            admin.Password = "admin123";
            admin.Username = "adminTransivo";
            admin.IsActive = true;

            context.Admins.Add(admin);
            context.SaveChanges();
            
            User user = new User();
            user.FirstName = "�zzettin";
            user.LastName = "Ero�lu";
            user.UserName = "izzettin";
            user.EMail = "eroglu@outlook.com";
            user.Phone = "905536699443";
            user.Address = addresses[0];
            user.BirthDate = DateTime.Now;
            user.MemberDate = DateTime.Now;
            user.Password = "12345678";
            user.UserRole = userRoles[0];
            user.ActivationCode = new Guid();
            user.TotalPayment = 15.4M;
            user.LastLoginDate = DateTime.Now;
            user.IsActive = true;
            context.Users.Add(user);
            context.SaveChanges();

            User user2 = new User();
            user2.FirstName = "Enes";
            user2.LastName = "Oru�";
            user2.UserName = "enes";
            user2.EMail = "orucenes95@gmail.com";
            user2.Phone = "905343816895";
            user2.Address = addresses[0];
            user2.BirthDate = DateTime.Parse("23.10.1995");
            user2.MemberDate = DateTime.Now;
            user2.Password = "147";
            user2.UserRole = userRoles[0];
            user2.ActivationCode = new Guid();
            user2.TotalPayment = 15.4M;
            user2.LastLoginDate = DateTime.Now;
            user2.IsActive = true;
            context.Users.Add(user2);
            context.SaveChanges();


            List<ShipCategory> shipCategories = new List<ShipCategory>();
            shipCategories.Add(new ShipCategory
            {
                Name = "Evden Eve",
                CreatedDate = DateTime.Now
            });

            shipCategories.Add(new ShipCategory
            {
                Name = "Fuar",
                CreatedDate = DateTime.Now
            });
            shipCategories.Add(new ShipCategory
            {
                Name = "�ehirler aras�",
                CreatedDate = DateTime.Now
            });
            context.ShipCategories.AddRange(shipCategories);
            context.SaveChanges();

            List<PayType> payTypes = new List<PayType>();
            payTypes.Add(new PayType
            {
                TypeName = "Nakit",
                CreatedDate = DateTime.Now

            });

            payTypes.Add(new PayType
            {
                TypeName = "Kredi Kart�",
                CreatedDate = DateTime.Now
            });

            context.PayTypes.AddRange(payTypes);
            context.SaveChanges();
        }
    }
}
