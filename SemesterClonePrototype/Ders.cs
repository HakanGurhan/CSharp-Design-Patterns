using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class Ders
{
    
    public string ad = "";
    public string Gun = "";
    public int kredi = 0;
    public string HocaAdı = "";
    public bool secmeli = false;

    public double baslangıcSaati;
    public double bitisSaati;


    public Ders(string ad, string gun, int kredi, string hoca, double baslangic, double bitis, bool secme = false)
    {
        this.ad = ad;
        this.Gun = gun;
        this.kredi = kredi;
        this.HocaAdı = hoca;
        this.baslangıcSaati = baslangic;
        this.bitisSaati = bitis;
        this.secmeli = secme;        
    }

    public override string ToString()
    {
        string tur = secmeli ? "Seçmeli" : "Zorunlu";

        return $"{ad} | {Gun} | {kredi} Kredi | {HocaAdı} | {baslangıcSaati:00}:00 - {bitisSaati:00}:00 | {tur}";
    }

}