using System;
using System.Collections.Generic;
using System.Linq;

namespace AkilliEvSimulatoru
{
    public enum CihazTuru
    {
        Lamba,
        Klima,
        GuvenlikSistemi
    }

    public class Cihaz
    {
        public int Kimlik { get; set; }
        public string Ad { get; set; }
        public CihazTuru Tur { get; set; }
        public bool AcikMi { get; private set; }

        public Cihaz(int kimlik, string ad, CihazTuru tur)
        {
            Kimlik = kimlik;
            Ad = ad;
            Tur = tur;
            AcikMi = false;
        }

        public void Ac()
        {
            AcikMi = true;
        }

        public void Kapat()
        {
            AcikMi = false;
        }

        public void BilgileriGoster()
        {
            string durum = AcikMi ? "Açık" : "Kapalı";
            Console.WriteLine($"ID: {Kimlik} | Ad: {Ad} | Tür: {Tur} | Durum: {durum}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cihaz> cihazlar = new List<Cihaz>
            {
                new Cihaz(1, "Salon Lambası", CihazTuru.Lamba),
                new Cihaz(2, "Yatak Odası Lambası", CihazTuru.Lamba),
                new Cihaz(3, "Salon Kliması (22 °C)", CihazTuru.Klima),
                new Cihaz(4, "Ana Giriş Güvenlik Sistemi", CihazTuru.GuvenlikSistemi)
            };

            while (true)
            {
                Console.WriteLine("\n--- AKILLI EV SİMÜLATÖRÜ ---");
                Console.WriteLine("1. Cihazları Listele");
                Console.WriteLine("2. Yeni Cihaz Ekle");
                Console.WriteLine("3. Cihaz Aç");
                Console.WriteLine("4. Cihaz Kapat");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                if (secim == "0")
                {
                    break;
                }
                else if (secim == "1")
                {
                    Console.WriteLine("\n--- Cihaz Listesi ---");
                    foreach (var cihaz in cihazlar)
                    {
                        cihaz.BilgileriGoster();
                    }
                }
                else if (secim == "2")
                {
                    Console.Write("Cihaz Kimliği (Sayı): ");
                    if (!int.TryParse(Console.ReadLine(), out int kimlik))
                    {
                        Console.WriteLine("Hata: Geçerli bir sayı giriniz!");
                        continue;
                    }

                    if (cihazlar.Any(c => c.Kimlik == kimlik))
                    {
                        Console.WriteLine("Hata: Bu kimliğe sahip bir cihaz zaten mevcut!");
                        continue;
                    }

                    Console.Write("Cihaz Adı: ");
                    string ad = Console.ReadLine();

                    Console.WriteLine("Cihaz Türü Seçin (1: Lamba, 2: Klima, 3: GuvenlikSistemi): ");
                    string turSecim = Console.ReadLine();
                    CihazTuru tur;

                    if (turSecim == "1") tur = CihazTuru.Lamba;
                    else if (turSecim == "2") tur = CihazTuru.Klima;
                    else if (turSecim == "3") tur = CihazTuru.GuvenlikSistemi;
                    else
                    {
                        Console.WriteLine("Hata: Geçersiz cihaz türü seçimi!");
                        continue;
                    }

                    cihazlar.Add(new Cihaz(kimlik, ad, tur));
                    Console.WriteLine("Cihaz başarıyla eklendi (Başlangıç durumu: Kapalı).");
                }
                else if (secim == "3")
                {
                    Console.Write("Açılacak Cihazın Kimliği: ");
                    if (int.TryParse(Console.ReadLine(), out int kimlik))
                    {
                        var cihaz = cihazlar.FirstOrDefault(c => c.Kimlik == kimlik);
                        if (cihaz == null)
                        {
                            Console.WriteLine("Hata: Belirtilen kimliğe sahip cihaz bulunamadı!");
                        }
                        else
                        {
                            cihaz.Ac();
                            Console.WriteLine($"{cihaz.Ad} açıldı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hata: Geçerli bir kimlik numarası giriniz!");
                    }
                }
                else if (secim == "4")
                {
                    Console.Write("Kapatılacak Cihazın Kimliği: ");
                    if (int.TryParse(Console.ReadLine(), out int kimlik))
                    {
                        var cihaz = cihazlar.FirstOrDefault(c => c.Kimlik == kimlik);
                        if (cihaz == null)
                        {
                            Console.WriteLine("Hata: Belirtilen kimliğe sahip cihaz bulunamadı!");
                        }
                        else
                        {
                            cihaz.Kapat();
                            Console.WriteLine($"{cihaz.Ad} kapatıldı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hata: Geçerli bir kimlik numarası giriniz!");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                }
            }
        }
    }
}