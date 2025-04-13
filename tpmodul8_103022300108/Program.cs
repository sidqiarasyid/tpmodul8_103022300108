// See https://aka.ms/new-console-template for more information
using tpmodul8_103022300108;

class Program 
{    
    static void Main()
    {
        CovidConfig config = new CovidConfig();
        double suhu;
        int hari;

        Console.WriteLine("Ganti satuan suhu yang sedang digunakan?, saat ini menggunakan satuan " + config.satuan_suhu + "(yes/no)");
        string ganti = Console.ReadLine();
        if (ganti == "yes")
        {
            config.UbahSatuan();
            Console.WriteLine("Satuan yang sekarang digunakan adalah " + config.satuan_suhu);
            Console.WriteLine();
        }


        config = new CovidConfig();

        Console.Write("Berapa suhu badan anda saat ini dalam " + config.satuan_suhu + "? ");
        suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
        hari = Convert.ToInt32(Console.ReadLine());

        bool suhuNormal = false;

        Console.WriteLine("Suhu anda: " + suhu + " " + config.satuan_suhu);

        if (config.satuan_suhu == "celcius")
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        else if (config.satuan_suhu == "fahrenheit")
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;

        if (suhuNormal && hari < config.batas_hari_deman)
            Console.WriteLine(config.pesan_diterima);
        else
            Console.WriteLine(config.pesan_ditolak);
    }
}
