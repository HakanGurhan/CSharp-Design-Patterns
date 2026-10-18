using System;

class Envanter
{
    private static readonly List<IEsya> Env = new List<IEsya>();

    public static void Ekleme(IEsya temp)
    {
        Env.Add(temp);
        Console.WriteLine("Ürün envantere eklendi");
    }


    public static void EnvanterGoster()
    {
        foreach(IEsya x in Env){
            Console.WriteLine(x.BilgiVer() + " - Nadirlik: " + x.Nadirlik);
            
        }
        
    }
}