using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("""
        ===== DUNGEON LOOT SYSTEM =====

        1 - Silah Sandığı Aç
        2 - İksir Sandığı Aç
        3 - Mücevher Sandığı Aç
        4 - Envanterimi Göster
        5 - Çıkış
    
        """);

        bool dongu = true;
        while (dongu)
        {
            Console.Write("Seçiminiz: ");
            int x = Convert.ToInt32(Console.ReadLine());

            switch (x)
            {

                case 1:
                    Sandik sandik1 = new SilahSandigi();
                    sandik1.SandikAc();
                    Console.WriteLine();
                    break;
                case 2:
                    Sandik sandik2 = new IksirSandigi();
                    sandik2.SandikAc();
                    Console.WriteLine();
                    break;
                case 3:
                    Sandik sandik3 = new MucevherSandigi();
                    sandik3.SandikAc();
                    Console.WriteLine();
                    break;
                case 4:
                    Envanter.EnvanterGoster();
                    Console.WriteLine();
                    break;
                case 5:
                    dongu = false;
                    break;
                default:
                    Console.WriteLine("Lütfen 1-5 arası geçerli değer giriniz.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}