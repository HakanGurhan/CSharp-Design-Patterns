using System;
using System.Security.Cryptography;

public class SilahSandigi : Sandik
{       
    protected override IEsya EsyaOlustur()
    {
        string nadir = RareSystem();
        if(nadir == "Legendary")
        {
            return new Yay();
        }
        else if(nadir == "Epic")
        {
            return new Balta();
        }

        return new Kılıc();
                
    }
}

public class IksirSandigi : Sandik
{   
    protected override IEsya EsyaOlustur()
    {
        string nadir = RareSystem();
        if(nadir == "Legendary")
        {
            return new Hızlılık();
        }
        else if(nadir == "Epic")
        {
            return new Zehir();
        }

        return new Koruma();
                
    }
}

public class MucevherSandigi : Sandik
{   
    protected override IEsya EsyaOlustur()
    {
        string nadir = RareSystem();
        if(nadir == "Legendary")
        {
            return new Elmas();
        }
        else if(nadir == "Epic")
        {
            return new Altın();
        }

        return new Gumus();
                
    }
}