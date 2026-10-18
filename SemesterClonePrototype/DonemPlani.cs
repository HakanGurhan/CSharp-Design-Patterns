
using System;
using System.Collections.Generic;

public class DonemPlani : IPlanPrototype
{
    public string OgrenciAdi = "";
    public List<Ders> dersler = new List<Ders>();

    // Prototype - Deep Copy
    public DonemPlani Clone()
    {
        DonemPlani yeni = new DonemPlani();

        yeni.OgrenciAdi = this.OgrenciAdi;

        foreach (Ders x in dersler)
        {
            Ders kopya = new Ders(
                x.ad,
                x.Gun,
                x.kredi,
                x.HocaAdı,
                x.baslangıcSaati,
                x.bitisSaati,
                x.secmeli
            );

            yeni.DersEkle(kopya);
        }

        return yeni;
    }

    public void DersEkle(Ders ders)
    {
        dersler.Add(ders);
    }

    public void DersSilme(Ders ders)
    {
        dersler.Remove(ders);
    }

    public void DersleriGoster()
    {
        foreach (Ders x in dersler)
        {
            Console.WriteLine(x);
        }
    }
}
