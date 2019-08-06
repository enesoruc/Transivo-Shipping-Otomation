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
            countries.Add(new Country { Name = "Türkiye" });
            context.Countries.AddRange(countries);
            context.SaveChanges();

            List<City> cities = new List<City>();
            cities.Add(new City { Name = "Adana", Country = countries[0] });
            cities.Add(new City { Name = "Ankara", Country = countries[0] });
            cities.Add(new City { Name = "Antalya", Country = countries[0] });
            cities.Add(new City { Name = "Bursa", Country = countries[0] });
            cities.Add(new City { Name = "Bilecik", Country = countries[0] });
            cities.Add(new City { Name = "Ýstanbul", Country = countries[0] });
            cities.Add(new City { Name = "Ýzmir", Country = countries[0] });
            context.Cities.AddRange(cities);
            context.SaveChanges();

            List<District> districts = new List<District>();
            districts.Add(new District { Name = "Ceyhan", City = cities[0] });
            districts.Add(new District { Name = "Çukurova", City = cities[0] });
            districts.Add(new District { Name = "Çankaya", City = cities[1] });
            districts.Add(new District { Name = "Ulus", City = cities[1] });
            districts.Add(new District { Name = "Kepez", City = cities[2] });
            districts.Add(new District { Name = "Uludað", City = cities[3] });
            districts.Add(new District { Name = "Gemlik", City = cities[3] });
            districts.Add(new District { Name = "Osmangazi", City = cities[3] });
            districts.Add(new District { Name = "Ayvalýk", City = cities[4] });
            districts.Add(new District { Name = "Bandýrma", City = cities[4] });
            districts.Add(new District { Name = "Maltepe", City = cities[5] });
            districts.Add(new District { Name = "Ataþehir", City = cities[5] });
            districts.Add(new District { Name = "Küçükyalý", City = cities[5] });
            districts.Add(new District { Name = "Kadýköy", City = cities[5] });
            districts.Add(new District { Name = "Çiðli", City = cities[6] });
            districts.Add(new District { Name = "Merkez", City = cities[6] });
            context.Districts.AddRange(districts);
            context.SaveChanges();

            List<Address> addresses = new List<Address>();
            addresses.Add(new Address { District = districts[10], AddresssDetail = "Fýndýklý Mah. Atatürk Cad. Fýrat Sok. No:10", Name = "Ev" });
            context.Addresses.AddRange(addresses);
            context.SaveChanges();

            addresses.Add(new Address { District = districts[0], AddresssDetail = "Gündoðdu mahallesi 2473 sokak no:3", Name = "Evim" });
            context.Addresses.AddRange(addresses);
            context.SaveChanges();

            Company company = new Company();
            company.About = "2003 yýlýnda kurulan MNG Kargo 800’den fazla þubesi, 7 tanesi Teknolojik Aktarma Merkezi olmak üzere toplam 25 aktarma merkezi, 14 bölge müdürlüðü, 6500’ü kendi bünyesinde, 3500’ü ise acentelerinde olmak üzere 10000’e yakýn çalýþaný, 3000 kara taþýma aracý ile hizmet vermektedir. MNG Kargo, Türkiye’nin bir ucundan diðer ucuna ve dünyada 220 farklý ülkede, günde 700 bin adrese dünya standartlarýnda hizmet ulaþtýran Türkiye’nin lider kargo þirketlerindendir.";
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
            company1.About = @"Yurtiçi Kargo, 'Söz Verdiðimiz Gibi' sloganýndan hareketle 1982 yýlýnda, Dr. Ýbrahim Arýkan liderliðinde ve Arýkanlý Holding çatýsý altýnda, Türkiye’deki ilk Türk kargo markasý olarak kurulmuþtur. Günümüzde, 17 Bölge Müdürlüðü, 33 Aktarma Merkezi, 880’den fazla þubesi, 15.000’den fazla çalýþaný ve 4000’in üzerinde araç filosu ile Türkiye'nin 81 ilinde ve Kuzey Kýbrýs Türk Cumhuriyeti'nde hizmet sunan Yurtiçi Kargo, 2003 yýlýndan bu yana Avrupa’nýn en büyük kargo þirketlerinden biri olan çözüm ortaðý Geopost ile birlikte müþterilerinin uluslararasý gönderilerini dünyada 220’den fazla noktaya, bir baþka deyiþle dünyanýn her yerine taþýmaktadýr. ";

            company1.Freight = 50.10M;
            company1.IsActive = true;
            company1.LogoPath = "https://www.yurticikargo.com/web_files/yurtici-kargo/Uploads/yk-haberler.jpg";
            company1.Phone = "905052673738";
            company1.TaxNumber = "TK1021";
            company1.CreatedDate = DateTime.Now;
            company1.CompanyName = "Yurtiçi Kargo";
            context.Companies.Add(company1);
            context.SaveChanges();

            Company company2 = new Company();
            company2.About = "1979 yýlýnda Celal Aras tarafýndan kurulan Aras Daðýtým ve Pazarlama, eriþtiði daðýtým aðý gücüyle, bu gücün taþýmacýlýkta da kullanýlmasý kararý alýnarak 1989'da faaliyete geçen Aras Kargo'nun da temellerini oluþturmuþtur.";
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
            company3.About = @"Sürat Kargo 2003 yýlýnýn Temmuz ayýnda kuruldu. Kargo sektörünün en genç markalarýndan biri olarak kýsa zamanda en önemli oyuncularý arasýnda yerini aldý. Bugün 700’e yakýn þube, 1600 araçlýk dev filosu, 1100 üzerinde mobil daðýtým alaný, 5000’i aþkýn personeli ile gönderilerinizi Türkiye'nin her yerine ve dünyanýn 228 ülkesine güvenle taþýyor.

Kurumsal ya da bireysel diye ayýrmadan tüm müþterilerinin gereksinimlerini onlardan önce düþünerek yeni teknolojiler ve hizmetler geliþtiriyor.Gönderilerinize en az sizin kadar deðer veriyor ve bekleyenin de gönderenin de içi rahat olsun diye gece gündüz çalýþýyor.";
            company3.Freight = 50.00M;
            company3.IsActive = true;
            company3.LogoPath = "http://destek.tsoft.com.tr/upload/omer/surat_kargo_logo.png";
            company3.Phone = "905052673740";
            company3.TaxNumber = "SK1021";
            company3.CreatedDate = DateTime.Now;
            company3.CompanyName = "Sürat Kargo";
            context.Companies.Add(company3);
            context.SaveChanges();

            Company company4 = new Company();
            company4.About = @"Transivo, Nakliye Firmalarý ve nakliye talebi olan kiþileri buluþturmayý amaçlayan bir platformudur.";
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
            user.FirstName = "Ýzzettin";
            user.LastName = "Eroðlu";
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
            user2.LastName = "Oruç";
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
                Name = "Þehirler arasý",
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
                TypeName = "Kredi Kartý",
                CreatedDate = DateTime.Now
            });

            context.PayTypes.AddRange(payTypes);
            context.SaveChanges();
        }
    }
}
