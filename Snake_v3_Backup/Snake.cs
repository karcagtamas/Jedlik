using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake_v3
{
    class Snake
    {
        List<Element> SnakeL = new List<Element>();
        List<Foodys> FoodyL = new List<Foodys>();
        ConsoleColor[] Colors = { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.Green, ConsoleColor.Cyan };
        int steps = 10;
        int Speed = 100;
        int Direction = 1;
        int point = 0;
        int Times = 0;
        int LastDirection = 1;
        bool Dead = false;
        int FoodyNum = 30;
        string Name;

        public int Point { get => point; set => point = value; }
        public int Steps { get => steps; set => steps = value; }

        public Snake(int speed, string name)
        {
            this.Speed = speed;
            this.Name = name;
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                Element E = new Element();
                if (i == 0)
                {
                    E.C = 'O';
                    E.Cc = ConsoleColor.White;
                    E.X = Console.WindowWidth / 2;
                    E.Y = Console.WindowHeight / 2;
                }
                else
                {
                    E.C = '│';
                    E.X = Console.WindowWidth / 2;
                    E.Y = Console.WindowHeight / 2 + i;
                    E.Cc = ConsoleColor.White;
                }
                SnakeL.Add(E);
            }
            if (Console.WindowWidth == Console.LargestWindowWidth) FoodyNum = 50;
            else if (Console.WindowWidth == Console.LargestWindowWidth * 7 / 10) FoodyNum = 30;
            else FoodyNum = 15;
            this.Wall();
            this.DrawSnake();
            this.FoodyMaker();
            this.FoodyDraw();
            this.Moving();
            this.DeathScreen();
        }

        protected void Wall()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 1);
            Console.Write('┌');
            for (int i = 0; i < Console.WindowWidth - 4; i++)
            {
                Console.Write('─');
            }
            Console.WriteLine('┐');
            for (int i = 2; i <= Console.WindowHeight - 4; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write('│');
                Console.SetCursorPosition(Console.WindowWidth - 2, i);
                Console.Write('│');
            }
            Console.SetCursorPosition(1, Console.WindowHeight - 3);
            Console.Write('└');
            for (int i = 0; i < Console.WindowWidth - 4; i++)
            {
                Console.Write('─');
            }
            Console.Write('┘');
        }

        protected void DrawSnake()
        {
            foreach (var i in SnakeL)
            {
                Console.SetCursorPosition(i.X, i.Y);
                Console.ForegroundColor = i.Cc;
                Console.Write(i.C);
            }
        }

        protected bool IsOut()
        {
            if (SnakeL[0].Y == 1 || SnakeL[0].Y == Console.WindowHeight - 3 || SnakeL[0].X == 1 || SnakeL[0].X == Console.WindowWidth - 2) return true;
            return false;
        }

        protected bool IsBitItself()
        {
            bool f = false;
            for (int i = 1; i < SnakeL.Count; i++)
            {
                if (SnakeL[0].X == SnakeL[i].X && SnakeL[0].Y == SnakeL[i].Y) f = true;
            }
            return f;
        }

        protected void Moving()
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine(this.Name);
            ConsoleKey Ck;
            do
            {
                while (!Console.KeyAvailable && !Dead)
                {
                    Console.Title = "Pontok: " + this.Point + " " + "Lépések: " + this.Steps + " " + "Sebesség: " + this.Speed;
                    this.Stepping();
                }
                Ck = Console.ReadKey(true).Key;
                if (!Dead)
                {
                    if (Ck == ConsoleKey.UpArrow || Ck == ConsoleKey.W) if (this.LastDirection != 3) Direction = 1;
                    if (Ck == ConsoleKey.RightArrow || Ck == ConsoleKey.D) if (this.LastDirection != 4) Direction = 2;
                    if (Ck == ConsoleKey.DownArrow || Ck == ConsoleKey.S) if (this.LastDirection != 1) Direction = 3;
                    if (Ck == ConsoleKey.LeftArrow || Ck == ConsoleKey.A) if (this.LastDirection != 2) Direction = 4;
                }
                else
                {
                    Dead = false;
                    Ck = ConsoleKey.Escape;
                }
            } while (Ck != ConsoleKey.Escape);
        }

        protected void Stepping()
        {
            Thread.Sleep(Speed);
            if (IsBitItself() || IsOut()) this.Death();
            this.IsEaten();
            if (SnakeL.Count % 5 == 0 && SnakeL.Count >= 20 && Times == this.SnakeL.Count / 5 - 4)
            {
                this.Speed -= 2;
                Times++;
            }
            Console.SetCursorPosition(SnakeL[SnakeL.Count - 1].X, SnakeL[SnakeL.Count - 1].Y);
            Console.Write(" ");
            SnakeL.RemoveAt(SnakeL.Count - 1);

            char C = Character();
            Element E = new Element();
            switch (this.Direction)
            {
                case 1: E.X = SnakeL[0].X; E.Y = SnakeL[0].Y - 1; this.LastDirection = this.Direction; break;
                case 2: E.X = SnakeL[0].X + 1; E.Y = SnakeL[0].Y; this.LastDirection = this.Direction; break;
                case 3: E.X = SnakeL[0].X; E.Y = SnakeL[0].Y + 1; this.LastDirection = this.Direction; break;
                case 4: E.X = SnakeL[0].X - 1; E.Y = SnakeL[0].Y; this.LastDirection = this.Direction; break;
            }
            this.Steps++;
            E.C = 'O';
            E.Cc = SnakeL[0].Cc;
            SnakeL.Insert(0, E);
            SnakeL[1].C = C;
            this.DrawSnake();
        }

        protected char Character()
        {
            if ((this.Direction == 1 && this.LastDirection == 1) || (this.Direction == 3 && this.LastDirection == 3)) return '|';
            if ((this.Direction == 2 && this.LastDirection == 2) || (this.Direction == 4 && this.LastDirection == 4)) return '─';
            if ((this.Direction == 2 && this.LastDirection == 1) || (this.Direction == 3 && this.LastDirection == 4)) return '┌';
            if ((this.Direction == 4 && this.LastDirection == 1) || (this.Direction == 3 && this.LastDirection == 2)) return '┐';
            if ((this.Direction == 1 && this.LastDirection == 4) || (this.Direction == 2 && this.LastDirection == 3)) return '└';
            if ((this.Direction == 1 && this.LastDirection == 2) || (this.Direction == 4 && this.LastDirection == 3)) return '┘';
            return 'O';
        }

        protected void Death()
        {
            Dead = true;
        }

        protected void FoodyMaker()
        {
            for (int i = 0; i < FoodyNum; i++)
            {
                Random r = new Random();
                int x;
                int y;
                do
                {
                    x = r.Next(3, Console.WindowWidth - 3);
                    y = r.Next(3, Console.WindowHeight - 3);
                } while (IsContain(x, y));
                Foodys F = new Foodys(x, y, Colors[r.Next(0, Colors.Length)]);
                FoodyL.Add(F);
            }
        }

        protected bool IsContain(int x, int y)
        {
            bool f = false;
            foreach (var i in FoodyL)
            {
                if (i.X == x && i.Y == y) f = true;
            }
            return f;
        }

        protected void FoodyDraw()
        {
            foreach (var i in FoodyL)
            {
                Console.SetCursorPosition(i.X, i.Y);
                Console.ForegroundColor = i.Cc;
                Console.Write('*');
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected void IsEaten()
        {
            for (int i = 0; i < FoodyL.Count; i++)
            {
                if (FoodyL[i].X == SnakeL[0].X && FoodyL[i].Y == SnakeL[0].Y)
                {
                    Point += FoodyL[i].Point;
                    switch (FoodyL[i].Cc)
                    {
                        case ConsoleColor.Blue:
                            Speed += 5;
                            break;
                        case ConsoleColor.Green:
                            break;
                        case ConsoleColor.Cyan:
                            Death();
                            break;
                        case ConsoleColor.Red:
                            Speed -= 5;
                            break;
                        case ConsoleColor.Magenta:
                            break;
                        case ConsoleColor.Yellow:
                            break;
                        case ConsoleColor.White:
                            break;
                    }
                    for (int j = 0; j < FoodyL[i].Point; j++)
                    {
                        Element E = new Element();
                        E.X = SnakeL[SnakeL.Count - 1].X;
                        E.Y = SnakeL[SnakeL.Count - 1].Y;
                        E.C = '|';
                        E.Cc = ConsoleColor.White;
                        SnakeL.Add(E);
                    }
                    FoodyL.RemoveAt(0);
                    Random r = new Random();
                    int x;
                    int y;
                    do
                    {
                        x = r.Next(3, Console.WindowWidth - 3);
                        y = r.Next(3, Console.WindowHeight - 3);
                    } while (IsContain(x, y));
                    Foodys F = new Foodys(x, y, Colors[r.Next(0, Colors.Length)]);
                    FoodyL.Add(F);
                    Console.SetCursorPosition(FoodyL[FoodyL.Count - 1].X, FoodyL[FoodyL.Count - 1].Y);
                    Console.ForegroundColor = FoodyL[FoodyL.Count - 1].Cc;
                    Console.Write('*');
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
            }
        }

        protected void DeathScreen()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - "Sajnálom! Meghaltál! :/".Length / 2, 10);
            Console.WriteLine("Sajnálom! Meghaltál! :/ ");
            Console.SetCursorPosition((Console.WindowWidth / 2) - "Nyomj ENTERT a tovább lépéshez!".Length / 2, 15);
            Console.WriteLine("Nyomj ENTERT a tovább lépéshez!");
            Console.ReadKey();

        }
    }
}
