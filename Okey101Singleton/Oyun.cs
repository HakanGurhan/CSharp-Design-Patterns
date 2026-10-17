using System;

class Oyun
{
    private readonly TasHavuzu havuz;
    private readonly Oyuncu[] oyuncular;

    private static bool again = false;

    public Oyun()
    {
        havuz = TasHavuzu.GetInstance();

        oyuncular = new Oyuncu[]
        {
            new Oyuncu("Ahmet"),
            new Oyuncu("Mehmet"),
            new Oyuncu("Ayşe"),
            new Oyuncu("Zeynep")
        };
    }

    private void Dagıtım()
    {
        for (int i = 0; i < 21; i++)
        {
            foreach (Oyuncu x in oyuncular)
            {
                x.TasAl(havuz.TasCek()!);
            }
        }

        oyuncular[0].TasAl(havuz.TasCek()!);
    }

    public void Baslat()
    {
        if (again)
        {
            Console.WriteLine("Oyun zaten başladı.");
            return;
        }

        Dagıtım();

        foreach (Oyuncu x in oyuncular)
        {
            x.EliGoster();
        }

        Console.WriteLine("Havuzda Kalan Taş: " + havuz.KalanTasSayisi());

        again = true;
    }
}