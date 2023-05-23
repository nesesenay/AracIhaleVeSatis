# Araç Satış, Alım ve İhale Projesi - Admin Paneli

## Bu proje, ASP.NET MVC ve Entity Framework kullanılarak geliştirilmiş bir araç satış, alım ve ihale yönetim sistemidir. Burada sizlere, projenin genel yapısını, kullanılan teknolojileri açıklamak istiyorum.

### Proje Hakkında

Bu proje, bir araç satış, alım ve ihale yönetim sisteminin admin panelini içermektedir. Aşağıda, projenin ana özellikleri hakkında bazı bilgiler yer almaktadır:
- Projede ASP.NET MVC (Model-View-Controller) mimarisi kullanılmıştır.
- Veritabanı işlemleri için Entity Framework ORM (Object-Relational Mapping) kullanılmıştır.
- Proje, kullanıcıları yetkilendirmek ve kimlik doğrulama yapmak için ASP.NET'in sağladığı oturum (session) ve kimlik (authentication) mekanizmalarından yararlanmaktadır.
- Veri erişim işlemleri, bir veri erişim katmanı (data access layer) kullanılarak yapılmaktadır.

---

### Bu projede aşağıdaki işlemler gerçekleştirilebilir:

- İhale işlemleri: Yeni bir ihale oluşturma ve var olan ihaleleri listeleme ve detaylarına erişme gibi işlemler yapılabilir.
- Araç ekleme ve satış işlemleri: Kurumsal müşterilere ait araçların listelenmesi, güncellenmesi ve yeni araçların eklenmesi işlemleri gerçekleştirilebilir. Ayrıca araçların satışıyla ilgili işlemler de yapılabilir.
- Müşteriyle ilgili işlemler: Kurumsal müşterilere ait araçların yönetimi ve güncellenmesi, bireysel müşterilere ait araçların listelenmesi ve güncellenmesi gibi işlemler gerçekleştirilebilir. Müşterilere paket tanımlama ve müşterileri onaylama gibi işlemler yapılabilir. 
- Profil yönetimi: Yönetici kendi profilini görüntüleyebilir ve isterse bilgilerini güncelleyebilir.
- Kullanıcıları görüntüleme: Siteye kayıtlı olan kurumsal, bireysel ve yönetici rolünde olan kullanıcılar tablolar üzerinden görüntülenebilir.
- Kurumsal müşteriyle ilgili işlemler: Kurumsal müşterilere tanımlanan araçların tramer bilgisi, aracın tarihçesi, aracın ilan bilgisi, komisyon ve noter ücretleri gibi bilgilerin kaydı yapılabilir. Aracın hemen alım ve satış işlemi gerçekleştirilebilir.
- Bireysel müşteriyle ilgili işlemler: Bireysel müşterilere tanımlanan araçların tarihçe ve tramer bilgisi görüntülenebilir.
