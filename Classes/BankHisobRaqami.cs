using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._1.Amaliy_vazifa_OOP_advanced.Classes
{
    public class BankHisobRaqami
    {
        public string Hisob_raqam { get; set; }
        private decimal balans;
        public decimal Balans
        {
            get { return balans; }
            set
            {
                if (value <= 0)
                    balans = 0;
                balans = value;

            }
        }
        public static void DepozitQoyish(ref Dictionary<string, Xaridor> xaridorDepozit)
        {
            Bank.GaTegishliHisobRaqamlar(ref xaridorDepozit);
            Console.Write("Hisob raqamingizni kiriting :");
            string xaridorHisobRaqam = Console.ReadLine();

            Console.Write("Qancha depozit qo'ymoqchisiz: ");
            decimal money = Convert.ToDecimal(Console.ReadLine());

            xaridorDepozit[xaridorHisobRaqam].Hisob_raqam.Balans += money;
            Bank.SetColor("Depozit muvaffaqiyatli qo'yildi !!!", ConsoleColor.Green);
            Console.ReadLine();
        }
        public static void PulYechibOlish(ref Dictionary<string, Xaridor> xaridorPulYechish)
        {
            Bank.GaTegishliHisobRaqamlar(ref xaridorPulYechish);

            Console.Write("Hisob raqamingizni kiriting :");
            string hisobRaqam = Console.ReadLine();

            Console.Write("Qancha Pul miqdorini olmoqchisiz: ");
            decimal money = Convert.ToDecimal(Console.ReadLine());

            while (money > xaridorPulYechish[hisobRaqam].Hisob_raqam.Balans || money < 0)
            {
                Console.Write("Siz Balansingizdan ko'p qiymat kirittingiz.\nIltimos Qayta kiriting: ");
                decimal.TryParse(Console.ReadLine(),out money);
            }
            xaridorPulYechish[hisobRaqam].Hisob_raqam.Balans -= money;
            Bank.SetColor("Pul muvaffaqiyatli Yechib olindi !!!",ConsoleColor.Green);
            Console.ReadLine();
        }
        public static void BalansniOlish(ref Dictionary<string, Xaridor> xaridorBalans)
        {
            Bank.GaTegishliHisobRaqamlar(ref xaridorBalans);

            Console.Write("Hisob raqamingizni kiriting :");
            string hisobRaqam = Console.ReadLine();

            if (xaridorBalans[hisobRaqam].Hisob_raqam.Hisob_raqam != null)
                Console.WriteLine($"Sizning balansingiz: {xaridorBalans[hisobRaqam].Hisob_raqam.Balans} UZS");
            else
                Bank.SetColor("Sizda hisob raqam mavjud emas iltimos uni Yarating !!!", color: ConsoleColor.Red);
            Console.ReadLine();
        }

    }
}