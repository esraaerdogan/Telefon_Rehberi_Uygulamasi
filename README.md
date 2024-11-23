# Telefon_Rehberi_Uygulamasi
 
 Yeni kisi kaydi eklenebilen, kisi kaydi guncellenebilen, kisi kaydi silinebilen, kisi rehber bilgisi görüntülenebilen ve rehberdeki kişilerin bir tabloda listelendigi uygulama yapilmistir.

KULLANILAN TEKNOLOJİLER
  Client Side: Angular
  Server Side: .Net Core Web API
  ORM: Entity Framework
  Veritabanı: MS SQL SERVER

Yapılan tüm işlemler sonucunda kullanıcıya bilgi mesajı döndürülmektedir. Silme işleminde kullanıcıdan onay alınmaktadır.
Server Side tarafta katmanlı mimari yapılmıştır.
Generic Repository Design Pattern kullanılmıştır.
Tablo olarak Angular Ag-Grid kullanılmıştır. 
Nlog kütüphanesi ile yapılan tüm işlemler loglanmıştır. Hem veritabanında hem de projedeki log klasöründe txt uzantılı dosyada loglanmıştır. 
