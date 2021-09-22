using System;


namespace Labyrint_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Char[,] labyrint= new char[8, 8];
            //Char[] labyrint2 = new char[7];
            int x = 0;
            int y = 0;
            int gubbe_x = 1;
            int gubbe_y = 1;
            char printme = ' ';

            for (int o = 0; o < 7; o++)
            {
                for (int p = 0; p < 7; p++)
                {
                    Console.SetCursorPosition(p, o);

                    labyrint[p, o] = ' ';
             
                }
                 
            }


            for (int i=0 ; i < 7 ; i++ )
            {
                labyrint[i, 0] = '#';
            }
            
            for (int j = 1; j < 7; j++)
            {
                labyrint[0, j] = '#';
            }

            for (int k = 0; k < 7; k++)
            {
                labyrint[k, 6] = '#';
            }
            for (int l = 1; l < 7; l++)
            {
                labyrint[6, l] = '#';
            }

            labyrint[2, 2] = '#';
            labyrint[2, 3] = '#';
            labyrint[2, 4] = '#';
            labyrint[3, 4] = '#';
            labyrint[4, 4] = '#';
            labyrint[4, 2] = '#';
            labyrint[5, 2] = '#';



            while (true)
            {
                for (int n = 0; n < 7; n++)
                {
                    for (int m = 0; m < 7; m++)
                    {
                        Console.SetCursorPosition(m, n);
                  //      if ((m != gubbe_x || n != gubbe_y) && (Math.Abs(m  - gubbe_x ) < 3) && Math.Abs(n - gubbe_y ) < 3) // lyktan lyser upp två närmsta rutorna
                        if ((m != gubbe_x || n != gubbe_y) && (Math.Abs(m  - gubbe_x ) < 6) && Math.Abs(n - gubbe_y ) < 6) // lyktan lyser upp fem närmsta rutorna
                        {
                            printme = labyrint[m, n];
                            Console.Write(printme);
                        }
                        
                    }
                   
                }
                Console.SetCursorPosition(gubbe_y, gubbe_x);
                Console.Write('☺');

                Console.SetCursorPosition(gubbe_y, 8);
                Console.Write(gubbe_y);
                Console.SetCursorPosition(gubbe_y+1, 8);
                Console.Write(gubbe_x);
                Console.ForegroundColor = ConsoleColor.Black;
                int input = Console.Read();
                char c = Convert.ToChar(input);
                int temptal = gubbe_x - 1;
                int temptal2 = gubbe_y - 1;
                int temptal3 = gubbe_x + 1;
                int temptal4 = gubbe_y + 1;

                if (c == 'k' && labyrint[ gubbe_y,temptal] != '#')
                {
                    gubbe_x--;

                }
                else if (c == 'j' && labyrint[gubbe_y,temptal3] != '#')
                {
                    gubbe_x++;
                }
                else if (c == 'l' && labyrint[temptal4, gubbe_x] != '#')
                {
                    gubbe_y++;
                }
                else if (c == 'h' && labyrint[temptal2, gubbe_x] != '#')
                {
                    gubbe_y--;
                }
		else 
		{
			
                Console.SetCursorPosition(gubbe_y, gubbe_x);
                Console.Write('X');
		Console.ReadLine();
		}
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

            }


        }
    }
}
