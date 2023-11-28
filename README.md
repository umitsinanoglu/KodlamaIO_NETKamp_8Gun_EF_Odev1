# KodlamaIO_NETKamp_8Gun_EF_Odev1
Araba Kiralama projemiz, Entity Framework , IEntity Repository

Bu proje, Kodlama.io .NET Kampı'nın 8. gününde verilen Entity Framework ödevini içermektedir. Projede, Entity Framework kullanılarak basit bir veritabanı yönetim sistemi örneği oluşturulmuştur.

## Proje Amacı
Bu proje, Entity Framework ile veritabanı işlemlerini öğrenmek ve uygulamak amacıyla oluşturulmuştur. Projenin temel amaçları şunlardır:

Entity Framework ile veritabanı oluşturma, erişme, güncelleme ve silme işlemlerini anlamak.
Code-First yaklaşımını kullanarak model oluşturma ve veritabanı ile ilişkilendirme.
LINQ sorgularını kullanarak veritabanından veri çekme ve işleme.

#### Proje iş gereksinimleri (güncel)
- GetCarsByBrandId , GetCarsByColorId servisleri yazıldı.
- Sisteme yeni araba eklendiğinde aşağıdaki kurallar çalışacak,
- Araba ismi minimum 2 karakter olmalıdır
- Araba günlük fiyatı 0'dan büyük olmalıdır.

// ... (CarManager'ı ve Car sınıfınızı oluşturduğumuz kısım)

`` CarManager carManager = new CarManager(new EfCarDal()); // Örnek oluşturulduğunu varsayalım

`` Random random = new Random(); ``

// Rastgele değerler oluşturma
`` int randomId = random.Next(1, 100); // 1 ile 100 arasında rastgele bir Id ``
`` int randomBrandId = random.Next(1, 10); // 1 ile 10 arasında rastgele bir BrandId ``
`` int randomColorId = random.Next(1, 10); // 1 ile 10 arasında rastgele bir ColorId ``
`` decimal randomDailyPrice = (decimal)(random.NextDouble() * (1000000 - 50000) + 50000); // 50,000 ile 1,000,000 arasında rastgele bir DailyPrice ``
`` int randomModelYear = random.Next(DateTime.Now.Year, DateTime.Now.Year + 5); // Şu anki yıldan başlayarak 5 yıl ileriye kadar rastgele bir ModelYear ``
`` string[] carNames = { "Renault Clio", "Ford Focus", "Toyota Corolla", "BMW 3 Series", "Mercedes-Benz C-Class" }; ``
`` string randomName = carNames[random.Next(0, carNames.Length)]; // Örnek araba isimlerinden rastgele bir Name ``

// Oluşturulan rastgele değerlerle Car nesnesini oluşturma ve ekleme
carManager.Add(new Car()
{
    Id = randomId,
    BrandId = randomBrandId,
    ColorId = randomColorId,
    Name = $"{randomName} {randomId}",
    DailyPrice = randomDailyPrice,
    Description = "Rastgele Açıklama",
    ModelYear = randomModelYear
});

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Id + " - " + car.Name);
}
Console.WriteLine("*******************************************");
Console.WriteLine(carManager.GetById(randomId).Name);
Console.WriteLine("*******************************************");
foreach (var car in carManager.GetAllByDailyPriceRange(9000, 990000))
{
    Console.WriteLine(car.Id + " - " + car.Name + " - " + car.DailyPrice);
}
Console.WriteLine("*******************************************");

BrandManager brandManager = new BrandManager(new EfBrandDal());
foreach (var car in carManager.GetCarsByBrandId(randomBrandId))
{
    Console.WriteLine(car.Id + " - " + car.Name + " - " + brandManager.GetById(car.BrandId).name);
}

Console.WriteLine("*******************************************");
ColorManager colorManager = new ColorManager(new EfColorDal());
foreach (var car in carManager.GetCarsByColorId(randomColorId))
{
    Console.WriteLine(car.Id + " - " + car.Name + " - " + colorManager.GetById(car.ColorId).name);
}

Console.WriteLine("*******************************************");
