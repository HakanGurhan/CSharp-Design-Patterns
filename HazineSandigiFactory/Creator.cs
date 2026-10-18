using System;
using System.Security.Cryptography;


public abstract class Sandik
{
    protected abstract IEsya EsyaOlustur();

    protected string RareSystem()
    {
        string[] Rare = ["Legendary", "Rare", "Epic"];
        int temp = RandomNumberGenerator.GetInt32(3);
        return Rare[temp];
    }
    public IEsya SandikAc()
    {
        IEsya temp = EsyaOlustur();

        Console.WriteLine(temp.BilgiVer() + " - Nadirlik: " + temp.Nadirlik);
        Envanter.Ekleme(temp);
        return temp;
    }
}