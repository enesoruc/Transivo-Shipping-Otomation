Nakliye firmaları ile kullanıcıları buluşturmayı amaçlayan bir MVC Web sayfası projesidir.
Kullanıcıların kayıt olarak, diledikleri firmalara başlangıç-bitiş adresi girerek nakliye talepleri oluşturabildikleri,
Firmaların kayıt olarak nakliye talepleri alabildikleri ve diğer çeşitli işlemleri Admin Panel üzerinden gerçekleştirebildikleri bir Web sayfası projesidir.

Ana Sayfa:
>* Kullanıcılar burada başlangıç-bitiş adresleri, gönderi tarihi,total km bilgilerini doldurur,
>* Ardından Firma Ara butonuna basarak işlemlerine devam edebilirler.
![Image of Yaktocat](https://raw.githubusercontent.com/enesoruc/Transivo-Shipping-Otomation/master/UI%20Pages%20Pictures/Index.png)

Nakliye:
>* Kullanıcılar burada yapmış oldukarı seçimlere göre firmaların birim fiyatları üzerinden ödeyecekleri ortalama ücreti görebilirler.
>* İşleme devam etmek isteyen kullanıcılar giriş yapmak zorundadır. Kayıtlı olmayan kullanıcılar nakliye talebi oluşturamamakla birlikte kayıt olduktan sonra işlemlerine devam edebilirler.

resim

Firmalar:
>* Kullanıcılar burada sisteme kayıtlı tüm firmalar ile ilgili detaylı bilgilere ulaşabilirler.
>* Dileyen kullanıcılar Guest kullanıcı profili olarak, gerekli bilgilerini girdikten sonra sistem üzerinden mesaj atabilirler.

resim

Giriş Ekranı:
>* Kullanıcı ve Firma girişleri ayrı ekranlardan gerçekleştirilmektedir.
>* Bilgilerin doğruluğu kontrol edildikten sonra giriş ekranına yönlendirme yapılır.

login resim

### Admin

Ana Sayfa:
* Firma yetkilileri giriş yaptıktan sonra Admin Panele yönlendirilir.
* Yetkili burada,
   * Firmaya Kayıtlı Şoför sayısı,
   * Onay Bekleyen Nakliye sayısı,
   * Teslimatı Bekleyen Nakliye sayısı,
   * Toplam Kazanç gibi bilgileri görüntüleyebilir.
   * Kullanıcılar tarafından gönderilmiş mesajlar,
   * Aktif onay bekleyen nakliyeler ve detaylarını görüntüleyebilir.

Admin Home resim

Nakliye Menü:
>* Yetkili bu menü üzerinden: Taşıma durumundaki nakliyeler ve Onay bekleyen nakliye talepleri ile ilgili tüm detayları görüntüleyebilir
* Mevcut Nakliyeler

resim

* Onay Bekleyen Nakliyeler

resim

Sürücü Menü:
>* Yetkili bu menü üzerinden: Firmaya kayıtlı sürücüleri görüntüleyebilir veya yeni sürücü kaydı yapabilir.

* Sürücü Kayıt

resim

* Sürücü Listesi

resim

Araç Menü:
>* Yetkili bu menü üzerinden: Firmaya kayıtlı araçları görüntüleyebilir veya yeni araç kaydı yapabilir.

* Araç Kayıt

resim

* Araç Listesi

Mesajları Görüntüle:
>* Yetkili bu menü üzerinden: Kullanıcıların firmaya sistem üzerinden göndermiş olduğu mesajları, tarih filtrelerine göre görüntüleyebilir.

resim
