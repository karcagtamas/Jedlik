using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake_v3
{
    class Game
    {
        List<Profile> Profiles = new List<Profile>();
        byte ActiveProfile = 0;
        public Game()
        {
            this.StarterSettings();
            Console.Title = "Snake Version 3 by Kalcag";
            Console.WindowHeight = Console.LargestWindowHeight * 7 / 10;
            Console.WindowWidth = Console.LargestWindowWidth * 7 / 10;
            Console.SetWindowPosition(0,0);
            Menu MainMenu = new Menu((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások","Profil Kiválasztása","Profil Létrehozása","Profil Törlése", "Rangsor", "Súgó", "Bezárás" });
            int answer = 1;
            Console.SetCursorPosition(0, 0);
            Console.Write(Profiles[ActiveProfile].Name);
            while (answer > -1)
            {
                answer = MainMenu.Update();
                switch (answer)
                {
                    case 0: this.Start(); MainMenu = new Menu((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások", "Profil Kiválasztása", "Profil Létrehozása","Profil Törlése", "Rangsor", "Súgó", "Bezárás" }); Console.SetCursorPosition(0, 0); Console.Write(Profiles[ActiveProfile].Name); break;
                    case 1: this.Settings(); MainMenu = new Menu((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások", "Profil Kiválasztása", "Profil Létrehozása", "Profil Törlése", "Rangsor", "Súgó", "Bezárás" }); Console.SetCursorPosition(0, 0); Console.Write(Profiles[ActiveProfile].Name); break;
                    case 2: this.ChooseProfile(); MainMenu = new Menu((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások", "Profil Kiválasztása", "Profil Létrehozása", "Profil Törlése", "Rangsor", "Súgó", "Bezárás" }); Console.SetCursorPosition(0, 0); Console.Write(Profiles[ActiveProfile].Name); break;
                    case 3: this.CreateProfile(); MainMenu = new Menu((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások", "Profil Kiválasztása", "Profil Létrehozása", "Profil Törlése", "Rangsor", "Súgó", "Bezárás" }); Console.SetCursorPosition(0, 0); Console.Write(Profiles[ActiveProfile].Name); break;
                    case 4: this.DeleteProfile(); MainMenu = new Menu((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások", "Profil Kiválasztása", "Profil Létrehozása", "Profil Törlése", "Rangsor", "Súgó", "Bezárás" }); Console.SetCursorPosition(0, 0); Console.Write(Profiles[ActiveProfile].Name); break;
                    case 5: this.Statistic(); MainMenu = new Menu((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások", "Profil Kiválasztása", "Profil Létrehozása", "Profil Törlése", "Rangsor", "Súgó", "Bezárás" }); Console.SetCursorPosition(0, 0); Console.Write(Profiles[ActiveProfile].Name); break;
                    case 6: this.Help(); MainMenu = new Menu((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2, new List<string> { "Inditás", "Beállítások", "Profil Kiválasztása", "Profil Létrehozása", "Profil Törlése", "Rangsor", "Súgó", "Bezárás" }); Console.SetCursorPosition(0, 0); Console.Write(Profiles[ActiveProfile].Name); break;
                    case 7: Environment.Exit(0);  break;
                }
            }
        }
        private void StarterSettings()
        {
            if (!Directory.Exists(@"C:\ProgramData\SnakeV3"))
            {
                Directory.CreateDirectory(@"C:\ProgramData\SnakeV3");
                Directory.CreateDirectory(@"C:\ProgramData\SnakeV3\Profiles");
                Directory.CreateDirectory(@"C:\ProgramData\SnakeV3\Profiles\Default");
                string[] s = { "Name:Default", "Id:0" };
                File.AppendAllLines(@"C:\ProgramData\SnakeV3\Profiles\Default\Data.txt", s, Encoding.UTF8);
                string[] s1 = { "0;0" };
                File.AppendAllLines(@"C:\ProgramData\SnakeV3\Profiles\Default\Scores.txt", s1, Encoding.UTF8);
            }

            string[] S = Directory.GetDirectories(@"C:\ProgramData\SnakeV3\Profiles");
            for (int i = 0; i < S.Length; i++)
            {
                Profile p = new Profile();
                string[] f = Directory.GetFiles(@S[i]);
                string[] d1 = File.ReadAllLines(@f[0]);
                p.Name = d1[0].Split(':')[1];
                p.Id = byte.Parse(d1[1].Split(':')[1]);
                string[] d2 = File.ReadAllLines(f[1]);
                for (int j = 0; j < d2.Length; j++)
                {
                    p.Scores.Add(int.Parse(d2[j].Split(';')[0]));
                    p.Steps.Add(int.Parse(d2[j].Split(';')[1]));
                }
                Profiles.Add(p);
            }
        }
        private void Start()
        {
            Menu StartMenu = new Menu((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2 - 2, new List<string> { "Nehéz", "Közepes", "Könnyű", "Vissza" });
            int answer = 1;
            bool f = true;
            while (answer > -1 && f)
            {
                answer = StartMenu.Update();
                switch (answer)
                {
                    case 0: Snake S1 = new Snake(70, Profiles[ActiveProfile].Name); this.Save(S1); Console.Title = "Snake Version 3 by Kalcag"; StartMenu = new Menu((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2 - 2, new List<string> { "Nehéz", "Közepes", "Könnyű", "Vissza" }); break;
                    case 1: Snake S2 = new Snake(90, Profiles[ActiveProfile].Name); this.Save(S2); Console.Title = "Snake Version 3 by Kalcag"; StartMenu = new Menu((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2 - 2, new List<string> { "Nehéz", "Közepes", "Könnyű", "Vissza" }); break;
                    case 2: Snake S3 = new Snake(110, Profiles[ActiveProfile].Name); this.Save(S3); Console.Title = "Snake Version 3 by Kalcag"; StartMenu = new Menu((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2 - 2, new List<string> { "Nehéz", "Közepes", "Könnyű", "Vissza" }); break;
                    case 3: f = false; break;
                }
            }
        }
        private void Settings()
        {
            Menu SettingsMenu = new Menu((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2 - 2, new List<string> {"Nagy","Közepes","Kicsi","Vissza"});
            int answer = 1;
            bool f = true;
            while (answer > -1 && f)
            {
                answer = SettingsMenu.Update();
                switch (answer)
                {
                    case 0: Console.WindowHeight = Console.LargestWindowHeight; Console.WindowWidth = Console.LargestWindowWidth; SettingsMenu = new Menu((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2 - 2, new List<string> { "Nagy", "Közepes", "Kicsi", "Vissza" }); break;
                    case 1: Console.WindowHeight = Console.LargestWindowHeight * 7 / 10; Console.WindowWidth = Console.LargestWindowWidth * 7 / 10; SettingsMenu = new Menu((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2 - 2, new List<string> { "Nagy", "Közepes", "Kicsi", "Vissza" }); break;
                    case 2: Console.WindowHeight = Console.LargestWindowHeight * 4 / 10; Console.WindowWidth = Console.LargestWindowWidth * 4 / 10; SettingsMenu = new Menu((Console.WindowWidth / 2) - 4, Console.WindowHeight / 2 - 2, new List<string> { "Nagy", "Közepes", "Kicsi", "Vissza" });  break;
                    case 3:  f = false; break;
                }
            }
        }
        private void CreateProfile()
        {
            Profile p = new Profile();
            Console.Clear();
            Console.WriteLine("Adja meg a felhasználó nevet: ");
            p.Scores.Add(0);
            p.Steps.Add(0);
            p.Id = (byte)Profiles.Count;
            p.Name = Console.ReadLine();
            Profiles.Add(p);
            while(Directory.Exists(@"C:\ProgramData\SnakeV3\Profiles\" + p.Name))
            {
                Console.WriteLine("Ez a felhasználó már létezik!");
                Console.WriteLine("Adjon meg egy másik felhasználó nevet:");
                p.Name = Console.ReadLine();
            }
            Directory.CreateDirectory(@"C:\ProgramData\SnakeV3\Profiles\" + p.Name);
            string[] s = { "Name:" + p.Name, "Id:" + (Profiles.Count - 1).ToString()};
            File.AppendAllLines(@"C:\ProgramData\SnakeV3\Profiles\" + p.Name +  @"\Data.txt", s, Encoding.UTF8);
            string[] s1 = { "0;0" };
            File.AppendAllLines(@"C:\ProgramData\SnakeV3\Profiles\" + p.Name + @"\Scores.txt", s1, Encoding.UTF8);

            Console.WriteLine("A profil elkészült...Nyomjon ENTERT");
            Console.ReadKey();
        }
        private void ChooseProfile()
        {
            List<string> Names = new List<string>();
            foreach (var i in Profiles)
            {
                Names.Add(i.Name);
            }
            Names.Add("Vissza");
            
            Menu ProfileMenu = new Menu((Console.WindowWidth / 2) - 6, Console.WindowHeight / 2 - 2, Names);
            int answer = 1;
            bool f = true;
            while (answer > -1 && f)
            {
                answer = ProfileMenu.Update();
                if (answer != Names.Count - 1) ActiveProfile = (byte)answer;
                else f = false;
            }
        }
        private void DeleteProfile()
        {
            List<string> Names = new List<string>();
            foreach (var i in Profiles)
            {
                Names.Add(i.Name);
            }
            Names.Add("Vissza");

            Menu ProfileMenu = new Menu((Console.WindowWidth / 2) - 6, Console.WindowHeight / 2 - 2, Names);
            int answer = 1;
            bool f = true;
            while (answer > -1 && f)
            {
                answer = ProfileMenu.Update();
                if (answer != Names.Count - 1)
                {
                    ActiveProfile = 0;
                    if (Profiles[answer].Name != "Default")
                    {
                        File.Delete(@"C:\ProgramData\SnakeV3\Profiles\" + Profiles[answer].Name + @"\Data.txt");
                        File.Delete(@"C:\ProgramData\SnakeV3\Profiles\" + Profiles[answer].Name + @"\Scores.txt");
                        Directory.Delete(@"C:\ProgramData\SnakeV3\Profiles\" + Profiles[answer].Name);
                        Profiles.RemoveAt(answer);
                        for (int i = 0; i < Profiles.Count; i++)
                        {
                            Profiles[i].Id = (byte)i;
                            File.Delete(@"C:\ProgramData\SnakeV3\Profiles\" + Profiles[i].Name + @"\Data.txt");
                            File.AppendAllLines(@"C:\ProgramData\SnakeV3\Profiles\" + Profiles[i].Name + @"\Data.txt", new List<string>{"Name:" + Profiles[i].Name, "Id:" + Profiles[i].Id});
                        }
                        Names.RemoveRange(0, Names.Count);
                        foreach (var i in Profiles)
                        {
                            Names.Add(i.Name);
                        }
                        Names.Add("Vissza");
                        ProfileMenu = new Menu((Console.WindowWidth / 2) - 6, Console.WindowHeight / 2 - 2, Names);
                    }
                }
                else f = false;
            }
        }
        private void Statistic()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            List<string> Names = new List<string>();
            List<int> Steps = new List<int>();
            List<int> Points = new List<int>();
            Console.Clear();
            foreach (var i in Profiles)
            {
                Names.Add(i.Name);
                Points.Add(i.MaxScore());
                Steps.Add(i.MaxStep());
            }
            int db = 1;
            for (int i = Points.Max() ; i > 0; i--)
            {
                for (int j = 0; j < Points.Count; j++)
                {
                    if (Points[j] == i)
                    {
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 20, db);
                        Console.WriteLine(db + ". " + Names[j]);
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 5, db);
                        Console.WriteLine("Pontok: " + Points[j]);
                        Console.SetCursorPosition((Console.WindowWidth / 2) + 10, db);
                        Console.WriteLine("Lépések: " + Steps[j]);
                        db++;
                    }
                }
            }
            Console.SetCursorPosition((Console.WindowWidth / 2) - "Nyomj ENTERT a tovább lépéshez...".Length / 2, db + 10);
            Console.WriteLine("Nyomj ENTERT a tovább lépéshez...");
            Console.ReadKey();
        }
        private void Help()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Csemeggék:");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Magenta");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(": 3 pontot ér");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Sárga");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(": 5 pontot ér");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Zöld");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(": 1 pontot ér");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Vörös");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(": 1 pontot ér és gyorsulsz tőle");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Kék");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(": 1 pontot ér és lassulsz tőle");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Cián");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(": Azonnali halált okoz");

            Console.WriteLine();
            Console.WriteLine("Ne felejtsd el kiválasztani a profilt a megfelelő menüben, mert oda fogja a rekordokat számolni.");
            Console.WriteLine();
            Console.WriteLine("Ha még nem létezik profilod, van lehetőséged létrehozni magadnak egyet.");
            Console.WriteLine();
            Console.WriteLine("A beállítások menü alatt van lehetőséged beállítani a képernyő méretet (kicsi, közepes, nagy).");
            Console.WriteLine("Alapértelmezett méret a közepes!");
            Console.WriteLine();
            Console.WriteLine("A játékot három nehézségi fokban van lehetőséged játszani (könnyű, közepes, nehéz).");
            Console.WriteLine();
            Console.WriteLine("Folytatás várható a közel jövőben....");
            Console.WriteLine();
            Console.WriteLine("Karcag - 2018.02.06.");

            Console.SetCursorPosition(Console.WindowWidth / 2 - "Mady by Karcag Tamás...".Length / 2, 25);
            Console.WriteLine("Mady by Karcag Tamás...");
            Console.SetCursorPosition(Console.WindowWidth / 2 - "Nyomj ENTERT a tovább lépéshez...".Length / 2, 30);
            Console.WriteLine("Nyomj ENTERT a tovább lépéshez...");
            Console.ReadKey();
        }

        private void Save(Snake S)
        {
            string[] s1 = { S.Point + ";" + S.Steps };
            File.AppendAllLines(@"C:\ProgramData\SnakeV3\Profiles\" + Profiles[ActiveProfile].Name + @"\Scores.txt", s1, Encoding.UTF8);
            Profiles[ActiveProfile].Scores.Add(S.Point);
            Profiles[ActiveProfile].Steps.Add(S.Steps);
        }
    }
}
