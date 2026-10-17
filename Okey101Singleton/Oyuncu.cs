using System;
using System.Collections.Generic;

public class Oyuncu
{
    public string ad;

    private readonly List<Tas> el = new List<Tas>();

    public Oyuncu(string ad)
    {
        this.ad = ad;
    }

    public void TasAl(Tas tas)
    {
        el.Add(tas);
    }

    public int EldeTasSayısı()
    {
        return el.Count;
    }

    public void EliGoster()
    {
        Console.WriteLine(ad);
        Console.WriteLine("-----------------");

        foreach (Tas x in el)
        {
            Console.WriteLine(x);
        }

        Console.WriteLine("-----------------");
        Console.WriteLine("Toplam Taş: " + el.Count);
        Console.WriteLine("-----------------");
    }
}