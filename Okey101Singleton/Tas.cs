using System;

public class Tas
{
    private string Renk = string.Empty;
    private int Number;
    private bool SahteOkey = false;

    public Tas(string Renk, int Number, bool SahteOkey = false)
    {
        if (!SahteOkey)
        {
            this.Renk = Renk;
            this.Number = Number;
        }
        else
        {
            this.SahteOkey = true;
        }
    }

    public override string ToString()
    {
        if (SahteOkey)
        {
            return "Sahte Okey";
        }

        return Renk + " " + Number;
    }
}