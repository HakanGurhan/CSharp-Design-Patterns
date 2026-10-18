
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static readonly string[] Gunler =
    {
        "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma"
    };

    static DonemPlani sablon = new DonemPlani();
    static List<DonemPlani> ogrenciler = new List<DonemPlani>();
    static DonemPlani? seciliPlan = null;

    static void Main(string[] args)
    {
        // Hazır dönem şablonu
        sablon.OgrenciAdi = "Bilgisayar Mühendisliği - Güz Dönemi";

        sablon.DersEkle(new Ders(
            "Programlama Dili 3", "Pazartesi", 5,
            "Tahir Sağ", 9, 11));

        sablon.DersEkle(new Ders(
            "Veri Haberleşmesi", "Salı", 5,
            "Gül Nihal Güğül", 11, 13));

        sablon.DersEkle(new Ders(
            "Mikroişlemciler", "Çarşamba", 5,
            "Adem Gölcük", 13, 15));

        bool dongu = true;

        while (dongu)
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("      SEMESTER CLONE");
            Console.WriteLine("=================================");
            Console.WriteLine("1- Şablona Ders Ekle");
            Console.WriteLine("2- Şablonu Göster");
            Console.WriteLine("3- Yeni Öğrenci Oluştur (Clone)");
            Console.WriteLine("4- Öğrenci Seç");
            Console.WriteLine("5- Öğrenciye Ders Ekle");
            Console.WriteLine("6- Öğrenciden Ders Sil");
            Console.WriteLine("7- Haftalık Programı Göster");
            Console.WriteLine("8- Öğrencileri Listele");
            Console.WriteLine("0- Çıkış");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Seçili Öğrenci: " +
                (seciliPlan == null ? "Yok" : seciliPlan.OgrenciAdi));

            int secim = SayiOku("Seçiminiz: ", 0, 8);

            switch (secim)
            {
                case 1:
                    Console.WriteLine("\nŞablona ders ekleniyor...");
                    DersEkleKontrollu(sablon, DersOlustur());
                    break;

                case 2:
                    ProgramGoster(sablon);
                    break;

                case 3:
                    {
                        string ad = MetinOku("Öğrenci Adı: ");

                        // Prototype: Hazır şablondan Deep Copy
                        DonemPlani yeni = sablon.Clone();
                        yeni.OgrenciAdi = ad;

                        ogrenciler.Add(yeni);
                        seciliPlan = yeni;

                        Console.WriteLine(
                            $"{ad} için dönem programı klonlandı.");
                        Console.WriteLine(
                            $"Aktarılan ders sayısı: {yeni.dersler.Count}");
                        break;
                    }

                case 4:
                    OgrenciSec();
                    break;

                case 5:
                    if (seciliPlan == null)
                    {
                        Console.WriteLine("Önce bir öğrenci seçin.");
                        break;
                    }

                    DersEkleKontrollu(seciliPlan, DersOlustur());
                    break;

                case 6:
                    if (seciliPlan == null)
                    {
                        Console.WriteLine("Önce bir öğrenci seçin.");
                        break;
                    }

                    DersSil(seciliPlan);
                    break;

                case 7:
                    if (seciliPlan == null)
                    {
                        Console.WriteLine("Önce bir öğrenci seçin.");
                        break;
                    }

                    ProgramGoster(seciliPlan);
                    break;

                case 8:
                    OgrencileriListele();
                    break;

                case 0:
                    dongu = false;
                    Console.WriteLine("Program kapatıldı.");
                    break;
            }
        }
    }

    // Güvenli sayısal giriş
    static int SayiOku(string mesaj, int min, int max)
    {
        while (true)
        {
            Console.Write(mesaj);

            if (int.TryParse(Console.ReadLine(), out int sayi)
                && sayi >= min && sayi <= max)
            {
                return sayi;
            }

            Console.WriteLine(
                $"Geçerli bir sayı girin ({min}-{max}).");
        }
    }

    static string MetinOku(string mesaj)
    {
        while (true)
        {
            Console.Write(mesaj);
            string metin = (Console.ReadLine() ?? "").Trim();

            if (!string.IsNullOrWhiteSpace(metin))
                return metin;

            Console.WriteLine("Bu alan boş bırakılamaz.");
        }
    }

    // Yeni ders bilgilerini al
    static Ders DersOlustur()
    {
        string ad = MetinOku("Ders Adı: ");

        Console.WriteLine("\nGün Seçiniz:");
        for (int i = 0; i < Gunler.Length; i++)
        {
            Console.WriteLine($"{i + 1}- {Gunler[i]}");
        }

        int gunNo = SayiOku("Gün: ", 1, 5);
        string gun = Gunler[gunNo - 1];

        int kredi = SayiOku("Kredi: ", 1, 30);
        string hoca = MetinOku("Öğretim Üyesi: ");

        int baslangic = SayiOku("Başlangıç Saati (0-23): ", 0, 23);
        int bitis = SayiOku("Bitiş Saati: ", baslangic + 1, 24);

        Console.WriteLine("1- Seçmeli");
        Console.WriteLine("2- Zorunlu");
        bool secmeli = SayiOku("Ders Türü: ", 1, 2) == 1;

        return new Ders(
            ad, gun, kredi, hoca, baslangic, bitis, secmeli);
    }

    // Aynı gün ve çakışan saatleri engelle
    static void DersEkleKontrollu(DonemPlani plan, Ders yeni)
    {
        foreach (Ders mevcut in plan.dersler)
        {
            bool ayniGun = mevcut.Gun == yeni.Gun;

            bool saatCakisiyor =
                yeni.baslangıcSaati < mevcut.bitisSaati &&
                yeni.bitisSaati > mevcut.baslangıcSaati;

            if (ayniGun && saatCakisiyor)
            {
                Console.WriteLine("\nDERS ÇAKIŞMASI!");
                Console.WriteLine("Mevcut ders: " + mevcut);
                Console.WriteLine("Yeni ders eklenemedi.");
                return;
            }
        }

        plan.DersEkle(yeni);
        Console.WriteLine("Ders başarıyla eklendi.");
    }

    // Öğrenci listesinden seçim yap
    static void OgrenciSec()
    {
        if (ogrenciler.Count == 0)
        {
            Console.WriteLine("Henüz öğrenci oluşturulmadı.");
            return;
        }

        OgrencileriListele();

        int secim = SayiOku(
            "Öğrenci Numarası (liste sırası): ",
            1, ogrenciler.Count);

        seciliPlan = ogrenciler[secim - 1];

        Console.WriteLine(
            "Seçilen öğrenci: " + seciliPlan.OgrenciAdi);
    }

    static void OgrencileriListele()
    {
        if (ogrenciler.Count == 0)
        {
            Console.WriteLine("Öğrenci listesi boş.");
            return;
        }

        Console.WriteLine("\n--- ÖĞRENCİLER ---");

        for (int i = 0; i < ogrenciler.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}- {ogrenciler[i].OgrenciAdi} " +
                $"({ogrenciler[i].dersler.Count} ders)");
        }
    }

    // Seçilen öğrenciden ders sil
    static void DersSil(DonemPlani plan)
    {
        if (plan.dersler.Count == 0)
        {
            Console.WriteLine("Silinecek ders yok.");
            return;
        }

        Console.WriteLine("\n--- DERSLER ---");

        for (int i = 0; i < plan.dersler.Count; i++)
        {
            Console.WriteLine($"{i + 1}- {plan.dersler[i]}");
        }

        int secim = SayiOku(
            "Silinecek Ders Numarası: ",
            1, plan.dersler.Count);

        Ders silinecek = plan.dersler[secim - 1];

        plan.DersSilme(silinecek);

        Console.WriteLine("Ders silindi: " + silinecek.ad);
    }

    // Haftalık programı gün ve saate göre göster
    static void ProgramGoster(DonemPlani plan)
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("PROGRAM: " + plan.OgrenciAdi);
        Console.WriteLine("=================================");

        foreach (string gun in Gunler)
        {
            Console.WriteLine($"\n--- {gun.ToUpperInvariant()} ---");

            var gununDersleri = plan.dersler
                .Where(d => d.Gun == gun)
                .OrderBy(d => d.baslangıcSaati)
                .ToList();

            if (gununDersleri.Count == 0)
            {
                Console.WriteLine("Ders yok.");
                continue;
            }

            foreach (Ders ders in gununDersleri)
            {
                Console.WriteLine(ders);
            }
        }

        Console.WriteLine("\nToplam Ders: " + plan.dersler.Count);
        Console.WriteLine("Toplam Kredi: " +
            plan.dersler.Sum(d => d.kredi));
    }
}
