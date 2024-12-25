using System.Runtime.InteropServices;
using _5._1.Amaliy_vazifa_OOP_advanced.Classes;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Xaridor Hush kelibsiz !!!");
        Dictionary<string, Xaridor> xaridors = new Dictionary<string, Xaridor>();
        int chooseAction;
        while (true)
        {
            chooseAction = ChooseAction(ref xaridors);
            Console.ReadLine();
            Console.Clear();
            if (chooseAction == 5) break;
        }
    }
    private static int ChooseAction(ref Dictionary<string, Xaridor> xaridors)
    {

        Console.WriteLine("\t1-Yangi Hisob ochish.\n\t2-Mavjud Hisobni yopish.\n\t3-Hisoblar o'rtasida pul o'tqazish.\n\t4-Shaxsiy karta bo'yicha amallar.\n\t5-Tugatish");
        Console.Write("Qanday amal bajarishni hohlaysiz(tartib raqam kiritng) :");
        int.TryParse(Console.ReadLine(), out int numberOfChoose);

        switch (numberOfChoose)
        {
            case 1: Bank.MijozHisobOchish(ref xaridors); break;
            case 2: Bank.MijozHisobYopish(ref xaridors); break;
            case 3: Bank.HisoblarOrtasidaPulOtqazish(ref xaridors);break;
            case 4: Amallar(ref xaridors); break;
            case 5:
                Bank.SetColor("\tKuningiz hayirli o'tsin !!!", ConsoleColor.Green);
                break;
            default: Console.WriteLine("Qayta kiriting"); break;
        }
        return numberOfChoose;
    }
    private static void Amallar(ref Dictionary<string, Xaridor> amallar)
    {
        while (true)
        {
            Console.WriteLine("\t1-Depozit qo'yish.\n\t2-Pul yechib olish.\n\t3-Balansni olish.\n\t4-Tugatish.");
            Console.Write("Qanday amal bajarishni hohlaysiz(tartib raqam kiritng) :");
            int.TryParse(Console.ReadLine(), out int numberOfChoose);
            switch (numberOfChoose)
            {
                case 1: BankHisobRaqami.DepozitQoyish(ref amallar); break;
                case 2: BankHisobRaqami.PulYechibOlish(ref amallar); break;
                case 3: BankHisobRaqami.BalansniOlish(ref amallar); break;
                case 4:; break;
                default: Bank.SetColor("Qayta kiriting !!!", ConsoleColor.Red); break;
            }
            Console.Clear();
            if (numberOfChoose == 4) break;
        }
    }
}