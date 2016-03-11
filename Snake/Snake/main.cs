using System;
using System.Collections.Generic;
using System.Threading;

namespace MainSnake
{
    public class Obiekt
    {
        public int x;
        public int y;

        public Obiekt()
        {
            x = 0;
            y = 0;
        }
        public Obiekt(int x, int y)
        {
            this.x=x; 
            this.y=y;
        }
        public void RysujObiekt(char symbol)
        {
            Console.SetCursorPosition(x - 1, y);
            Console.Write(symbol);
        }
    }
    class Snake
    {
        public List<Obiekt> snake_list = new List<Obiekt>();
        public int kierunek;
        Obiekt first = new Obiekt();
        Obiekt last = new Obiekt();
        public Obiekt hidden = new Obiekt();

        public Snake(int start_x, int start_y)
        {
            first.x = start_x;
            first.y = start_y;
            last.x = start_x - 1;
            last.y = start_y;
            hidden.x = start_x - 2;
            hidden.y = start_y;

            snake_list.Add(first);
            snake_list.Add(last);
            snake_list.Add(hidden);

            kierunek = 1;
        }
        public void Rysuj()
        {
            for (int i = 0; i < snake_list.Count; i++)
            {
                snake_list[i].RysujObiekt('o');
            }
            hidden.RysujObiekt(' ');
        }
        public void Sterowanie()
        {
            int k = kierunek;
            if (Console.KeyAvailable) // since .NET 2.0
            {
                ConsoleKeyInfo c = Console.ReadKey();
                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        kierunek = 0;
                        //Console.WriteLine("Wcisnieto strzalke w gore");
                        break;
                    case ConsoleKey.RightArrow:
                        kierunek = 1;
                        //Console.WriteLine("Wcisnieto strzalke w prawo");
                        break;
                    case ConsoleKey.DownArrow:
                        kierunek = 2;
                        //Console.WriteLine("Wcisnieto strzalke w dol");
                        break;
                    case ConsoleKey.LeftArrow:
                        kierunek = 3;
                        //Console.WriteLine("Wcisnieto strzalke w lewo");
                        break;
                }
                if (kierunek - k == 2 || k - kierunek == 2)
                    kierunek=k;
                while (Console.KeyAvailable) { Console.ReadKey(true); } //-----czyścimy bufor klawiatury
            }
        }
        public void Przesun()
        {
            int dlugosc = snake_list.Count;

            for (int i = dlugosc - 1; i > 0; i--)
            {
                snake_list[i].x = snake_list[i - 1].x;
                snake_list[i].y = snake_list[i - 1].y;
            }
            switch (kierunek)       //przesuniecie glowy
            {
                case 0:
                    first.y--;
                    break;
                case 1:
                    first.x++;
                    break;
                case 2:
                    first.y++;
                    break;
                case 3:
                    first.x--;
                    break;
            }
            first = snake_list[0];
            last = snake_list[dlugosc - 2];
            hidden = snake_list[dlugosc - 1];

            //Console.SetCursorPosition(0, 0);
            //Console.WriteLine("dlugosc: {0}", dlugosc);
            //Console.WriteLine("1koord: {0}, {1}", first.x, first.y);
            //Console.WriteLine("2koord: {0}, {1}", last.x, last.y);
        }
        public bool CzyKoliduje(int w, int h)
        {
            if (first.x <= 1 || first.x >= w)
                return true;
            if (first.y <= 0 || first.y >= h)
                return true;
            for (int i = 1; i < snake_list.Count; i++)
                if (first.x == snake_list[i].x && first.y == snake_list[i].y)
                    return true;
            return false;
        }
        public bool SprawdzCoin(Coin c)
        {
            if (c.coin.x == first.x && c.coin.y == first.y)
            {
                return true;
            }
            return false;
        }
        public int Wydluz(List<Coin> zdobyte)
        {
            Obiekt nowy = new Obiekt();
            if (hidden.x == zdobyte[0].coin.x && hidden.y == zdobyte[0].coin.y)
            {
                zdobyte.RemoveAt(0);
                if (last.x == hidden.x + 1)
                {
                    nowy.x = hidden.x - 1;
                    nowy.y = hidden.y;
                }
                else if (last.x == hidden.x - 1)
                {
                    nowy.x = hidden.x + 1;
                    nowy.y = hidden.y;
                }
                else if (last.y == hidden.y + 1)
                {
                    nowy.x = hidden.x;
                    nowy.y = hidden.y - 1;
                }
                else if (last.y == hidden.y - 1)
                {
                    nowy.x = hidden.x;
                    nowy.y = hidden.y + 1;
                }
                snake_list.Add(nowy);
                hidden = snake_list[snake_list.Count - 1];
                
                
                //Console.SetCursorPosition(0, 0);
                //Console.Write("Dlugosc: {0}", snake_list.Count);
            }
            return snake_list.Count-1;  //-1 bo jest 1 ukryty

        }
    }
    class Map
    {
        int width;
        int height;

        public Map(int i_w, int i_h)
        {
            width = i_w;
            height = i_h;
        }

        public void Rysuj()
        {
            int szer_boku = 25;
            //----pierwsza linijka----
            Console.SetCursorPosition(0, 0);
            Console.Write('╔');
            for (int i=0; i<width-1; i++)
                Console.Write('═');
            Console.Write('╦');
            for (int i = 0; i < szer_boku-1; i++)
                Console.Write('═');
            Console.Write('╗');

            //------kolejne linijki--------
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i+1);
                Console.Write('║');
                Console.SetCursorPosition(width, i + 1);
                Console.Write('║');
                Console.SetCursorPosition(width + szer_boku, i + 1);
                Console.Write('║');
            }

            //----ostatnia linijka ------
            Console.SetCursorPosition(0, height);
            Console.Write('╚');
            for (int i = 0; i < width - 1; i++)
                Console.Write('═');
            Console.Write('╩');
            for (int i = 0; i < szer_boku-1; i++)
                Console.Write('═');
            Console.Write('╝');


            
            /*
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width+20; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write((char)201);
                    }
                    else if (i == 0 && j == width)
                    {
                        Console.SetCursorPosition(x - 1, y);
                        Console.Write((char)203);
                    }
                }*/

        }


    }
    class Coin
    {
        public Obiekt coin = new Obiekt();
        Random losuj = new Random();
        int w;
        int h;

        public Coin()
        {
            coin.x = 0;
            coin.y = 0;
        }
        public Coin(int w, int h)
        {
            this.w = w;
            this.h = h;
        }
        public void Losuj(Snake snake)
        {
            bool wylosowano = false;

            while (!wylosowano)
            {
                
                coin.x = losuj.Next(2, w);
                coin.y = losuj.Next(1, h);

                for (int i = 0; i < snake.snake_list.Count; i++)
                    if (coin.x == snake.snake_list[i].x && coin.y == snake.snake_list[i].y)
                        wylosowano = false;
                wylosowano = true;
            }   
        }
        public void Rysuj()
        {
            coin.RysujObiekt('$');
        }
    }
    class Menu
    {
        int width;
        int height;

        public Menu(int w, int h)
        {
            width = w;
            height = h;
        }
        void RysujRamke()
        {
            int szer_boku = 25;
            Console.SetCursorPosition(0, 0);
            Console.Write('╔');
            for (int i = 0; i < width +szer_boku-1; i++)
                Console.Write('═');
            Console.Write('╗');

            //------kolejne linijki--------
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write('║');
                Console.SetCursorPosition(width + szer_boku, i + 1);
                Console.Write('║');
            }

            //----ostatnia linijka ------
            Console.SetCursorPosition(0, height);
            Console.Write('╚');
            for (int i = 0; i < width + szer_boku-1; i++)
                Console.Write('═');
            Console.Write('╝');

        }
        public int Wybor()
        {
            int size;
            int podswietlona = 0;
            bool wybrano=false;
            string[] tab_menu = new string[] {
                "   New game   ", 
                "    Scores    ", 
                "     Exit     "} ;
            size = tab_menu.Length;
            Console.Clear();
            RysujRamke();
            while (!wybrano)
            {
                for (int i = 0; i < size; i++)
                {
                    if (podswietlona == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    
                    Console.SetCursorPosition((width + 25) / 2 - tab_menu[i].Length / 2, height / 2 + i);
                    Console.Write(tab_menu[i]);

                    if (podswietlona == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                ConsoleKeyInfo c = Console.ReadKey();
                switch (c.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(podswietlona>0) podswietlona--;
                        //Console.WriteLine("Wcisnieto strzalke w gore");
                        break;
                    case ConsoleKey.DownArrow:
                        if (podswietlona < size-1) podswietlona++;
                        //Console.WriteLine("Wcisnieto strzalke w dol");
                        break;
                    case ConsoleKey.Enter:
                        wybrano = true;
                        break;
                }
            }
            return podswietlona;
        }
    }
    class Program
    {
        //zmienne globalne - wymiary planszy aktywnej
        static int Width = 50;
        static int Height = 23;

        static void Game()
        {
            int opoznienie = 200;
            bool rungame = true;
            Snake player1 = new Snake(Width / 2, Height / 2);
            Map mapa = new Map(Width, Height);
            Coin coin = new Coin(Width, Height);
            Coin zdobyty = new Coin();
            List<Coin> zdobyte = new List<Coin>();
            int dlugosc_weza=2;

            Console.Clear();
            player1.Rysuj();
            mapa.Rysuj();
            coin.Losuj(player1);
            
            coin.Rysuj();

            while (rungame)
            {
                player1.Sterowanie();
                player1.Przesun();

                if (player1.SprawdzCoin(coin))  //jeśli wejdzie w coina to losuje nowy
                {
                    zdobyty.coin.x = coin.coin.x;
                    zdobyty.coin.y = coin.coin.y;
                    zdobyte.Add(zdobyty);
                    coin.Losuj(player1);
                }

                if (zdobyte.Count > 0)    //jesli jakiś coin zostal zdobyty, a waz nie wydluzony to wydluza weza
                {
                    dlugosc_weza = player1.Wydluz(zdobyte);   //zwraca dlugosc weza typu int
                    Console.SetCursorPosition(Width + 4, 2);
                    Console.Write("Długość: {0}", dlugosc_weza);
                }

                if (player1.CzyKoliduje(Width, Height))     //---jesli sie zderzy przerywa gre
                    rungame = false;

                coin.Rysuj();
                player1.Rysuj();
                
                
                
                //Console.ReadKey();

                Thread.Sleep(opoznienie);
            }
        }
        

        static void Main(string[] args)
        {
            int menu_choice;
            bool exit=false;
            Menu menu = new Menu(Width, Height);
            while (!exit)
            {
                menu_choice = menu.Wybor();
                switch (menu_choice)
                {
                    case 0:
                        Game();
                        break;
                    case 1:
                        Console.Write("Niezaimplementowano");
                        Console.ReadLine();
                        break;
                    case 2:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
            Environment.Exit(0);

        }
    }
}