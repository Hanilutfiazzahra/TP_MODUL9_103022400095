using System;

class Program
{
    static void Main()
    {

        CovidConfig config = CovidConfig.LoadConfig();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu anda terakhir memiliki gejala demam?");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;

        if (config.satuan_suhu == "celcius")
        {
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        }
        else
        {
            suhuValid = suhu >= 97.7 && suhu <= 99.5;
        }

        bool hariValid = hari < config.batas_hari_demam;

        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        config.UbahSatuan();
        Console.WriteLine($"Satuan sekarang: {config.satuan_suhu}");
    }
}