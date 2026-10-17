using System;
using System.Collections.Generic;

class TasHavuzu
{
    private static readonly TasHavuzu deste = new TasHavuzu();

    private readonly List<Tas> taslar = new List<Tas>();

    private TasHavuzu()
    {
        string[] renkler = { "Kırmızı", "Sarı", "Mavi", "Siyah" };
        int[] numara = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < numara.Length; j++)
            {
                taslar.Add(new Tas(renkler[i], numara[j]));
                taslar.Add(new Tas(renkler[i], numara[j]));
            }
        }

        taslar.Add(new Tas("", 0, true));
        taslar.Add(new Tas("", 0, true));

        Karıstır();
    }

    public static TasHavuzu GetInstance()
    {
        return deste;
    }

    public int KalanTasSayisi()
    {
        return taslar.Count;
    }

    public Tas? TasCek()
    {
        if (taslar.Count > 0)
        {
            Tas ret = taslar[taslar.Count - 1];
            taslar.RemoveAt(taslar.Count - 1);
            return ret;
        }

        Console.WriteLine("Masada Taş Kalmadı");
        return null;
    }

    private void Karıstır()
    {
        int i = taslar.Count - 1;

        while (i > 0)
        {
            int j = Random.Shared.Next(i + 1);

            Tas temp = taslar[i];
            taslar[i] = taslar[j];
            taslar[j] = temp;

            i--;
        }
    }
}