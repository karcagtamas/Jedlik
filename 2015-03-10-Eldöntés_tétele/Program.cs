using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//eldöntés tételének mondatszerűleírását füzetbe
//Edraw programmal megrajzolni ezt
//füzetbe is folyamatábrával
namespace eldöntés_tétele
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            char[] karakterek = new char[10];
            //a-->97
            //z-->122
            //0-->48
            //9-->57
            //A-->65
            //Z-->90
            for (int i = 0; i < karakterek.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                karakterek[i] = (char)r.Next(97, 123);
                Console.WriteLine("karakterek[{0}]={1}",i, karakterek[i]);
            }
            bool tartalmaz = false;
            int index = 0;
            do
            {
                if (karakterek[index] == 'a')
                {
                    tartalmaz = true;
                }
                index++;
            } while (index<karakterek.Length-1 && !tartalmaz);
            if (tartalmaz)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Igen");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nem");
            }
            //Console.WriteLine(tartalmaz ? "Igen" : "Nem");
            Console.ReadKey();
        }
    }
}
