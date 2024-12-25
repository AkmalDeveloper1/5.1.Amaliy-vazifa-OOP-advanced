using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1.Amaliy_vazifa_OOP_advanced.Classes
{
    public static class Bank
    {
        public static ref Dictionary<string, Xaridor> MijozHisobOchish(ref Dictionary<string, Xaridor> xaridors)
        {

            Guid guid = Guid.NewGuid();
            Xaridor xaridor = new Xaridor();

            Console.Write("Ismni kiriting: ");
            xaridor.FirstName = Console.ReadLine();

            Console.Write("Familyangizni kiriting: ");
            xaridor.LastName = Console.ReadLine();

            xaridor.Hisob_raqam = new BankHisobRaqami();
            xaridor.Hisob_raqam.Hisob_raqam = Convert.ToString(guid);

            Console.Write("Qancha depozit qo'ymoqchisiz: ");
            xaridor.Hisob_raqam.Balans = Convert.ToDecimal(Console.ReadLine());

            xaridors.Add(xaridor.Hisob_raqam.Hisob_raqam, xaridor);
            SetColor($"Sizning hisob raqamingiz: {xaridor.Hisob_raqam.Hisob_raqam} ");
            return ref xaridors;
        }
        public static void MijozHisobYopish(ref Dictionary<string, Xaridor> xaridorRemove)
        {
            GaTegishliHisobRaqamlar(ref xaridorRemove);
            Console.Write("Hisob raqamingizni kiriting :");
            string removeHisobRaqam = Console.ReadLine();
            if (xaridorRemove[removeHisobRaqam].Hisob_raqam.Balans == 0)
            {
                xaridorRemove.Remove(removeHisobRaqam);
                SetColor("Hisob O'chirildi !!!", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine($"Hisobingizda {xaridorRemove[removeHisobRaqam].Hisob_raqam.Balans} UZS miqodorida pul mavjud");
                Console.WriteLine("Iltimos Pulingizni olib so'ng yana qayta urinib ko'ring !!!");
                BankHisobRaqami.PulYechibOlish(ref xaridorRemove);
            }
        }

        public static void HisoblarOrtasidaPulOtqazish(ref Dictionary<string, Xaridor> pulOtqazish)
        {
            int count = 1;
            foreach (var eachXaridor in pulOtqazish)
            {
                Console.WriteLine($"{count++}. Ism: {eachXaridor.Value.FirstName}\nFamilya: {eachXaridor.Value.LastName}\nBalansingiz:{eachXaridor.Value.Hisob_raqam.Balans}");
                SetColor($"Hisob raqami: {eachXaridor.Value.Hisob_raqam.Hisob_raqam}");
            }
            Console.Write("Pulni qaysi hisob raqamdan jo'natmoqchisiz: ");
            string hisobRaqam_1 = Console.ReadLine();

            Console.Write("Qancha jo'natmoqchisiz: ");
            decimal jonatish = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Pulni qaysi hisob raqamga qabul qilmoqchisiz: ");
            string hisobRaqam_2 = Console.ReadLine();

            if (pulOtqazish[hisobRaqam_1].Hisob_raqam.Balans != 0)
            {
                if (pulOtqazish[hisobRaqam_1].Hisob_raqam.Balans >= jonatish)
                {
                    pulOtqazish[hisobRaqam_1].Hisob_raqam.Balans -= jonatish;
                    pulOtqazish[hisobRaqam_2].Hisob_raqam.Balans += jonatish;
                    SetColor("Mablag' muvaffaqiyatli o'tqazildi !!!",ConsoleColor.Green);
                }
                else
                    SetColor("Balansingizda mablag' yetarli emas !!!", ConsoleColor.Red);
            }
            else
                SetColor("Balansingizda mablag' mavjud emas !!!", ConsoleColor.Red);
        }
        public static void GaTegishliHisobRaqamlar(ref Dictionary<string, Xaridor> gaTegishli)
        {
            Console.Write("Familyangizni kiriting: ");
            string lastName = Console.ReadLine();
            Console.WriteLine($"{lastName} ga tegishli hisob raqamlar:");
            bool isThere = false;
            foreach (var person in gaTegishli)
            {
                if (person.Value.LastName == lastName)
                {
                    Console.WriteLine($"Ism: {person.Value.FirstName}\nFamilya: {person.Value.LastName}\nBalansingiz:{person.Value.Hisob_raqam.Balans}");
                    SetColor($"Hisob raqami: {person.Value.Hisob_raqam.Hisob_raqam}");
                    isThere = true;
                }
            }
            if (!isThere)
            {
                SetColor("Sizda hisob Raqam mavjud emas iltimos avval hisob raqam oching !!!", ConsoleColor.Red);
                MijozHisobOchish(ref gaTegishli);
            }
        }
        public static void SetColor(string message, ConsoleColor color = ConsoleColor.Yellow)
        {
            ConsoleColor color1 = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = color1;
        }
    }
}