using System;

public class Kılıc : IEsya
{
    public string BilgiVer()
    {
        return "Demir Kılıç - Hasar Gücü - 35";
    }
    
    public string Nadirlik => "Rare";
}

public class Balta : IEsya
{
    public string BilgiVer()
    {
        return "Demir Balta - Hasar Gücü - 45";
    }

    public string Nadirlik => "Epic";
}

public class Yay : IEsya
{
    public string BilgiVer()
    {
        return "Elf Yayı - Hasar Gücü - 50";
    }

    public string Nadirlik => "Legendary";
}



public class Elmas : IEsya
{
    public string BilgiVer()
    {
        return "Elmas - İyileştirme Gücü - 35";
    }

    public string Nadirlik => "Legendary";
}
public class Altın : IEsya
{
    public string BilgiVer()
    {
        return "Altın - İyileştirme Gücü - 25";
    }
    public string Nadirlik => "Epic";
}
public class Gumus : IEsya
{
    public string BilgiVer()
    {
        return "Gümüş - İyileştirme Gücü - 15";
    }

    public string Nadirlik => "Rare";
}

public class Hızlılık : IEsya
{
    public string BilgiVer()
    {
        return "Hızlandırma İksiri - Hız Artış Oranı - 10";
    }
    public string Nadirlik => "Legendary";
}

public class Zehir : IEsya
{
    public string BilgiVer()
    {
        return "Zehirli İksir - Hasar Gücü - 55";
    }

    public string Nadirlik => "Epic";
}

public class Koruma : IEsya
{
    public string BilgiVer()
    {
        return "Koruma İksiri - Geçerlilik Süresi - 100 saniye";
    }

    public string Nadirlik => "Rare";
}