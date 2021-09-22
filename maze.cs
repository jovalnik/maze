using System;
using System.Collections.Generic;

namespace MazeGenRec
{
    class Program
    {
        const int size = 20;
        static char[,] maze = new char[size * 2 + 2, size * 2 + 2];
        static (int, int) currentCell = (4, 4);
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            //vvvv fyll labyrinten med väggar & obesökta kammare
            //  omge lab med tecken som är annat än ' ' & '#', exvis '!'
            

            for (int i = 0; i < (size * 2) + 2; i++)
            {
                for (int j = 0; j < (size * 2) + 2; j++)
                {
                    if (i != 0 && j != 0 && i != size * 2 + 1 && j != size * 2 + 1 && i != 1 && j != 1 && i != size * 2  && j != size * 2 )
                    {
                        maze[i, j] = '#';
                    }
                    else
                    {
                        maze[i, j] = '!';
                    }

                }
            }
            for (int l = 0; l < size*2+2; l++)
            {
                for (int m = 0; m < size*2+2; m++)
                {
                    Console.Write(maze[l, m]);
                    if (m == size * 2 + 1)
                    {
                        Console.WriteLine("");
                    }
                }
            }
            Generate(currentCell);
            string mothing=Console.ReadLine();
            for (int l = 0; l < size * 2 + 2; l++)
            {
                for (int m = 0; m < size * 2 + 2; m++)
                {
                    if (maze[l, m] == '#')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(maze[l, m]);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(maze[l, m]);
                    }
                    if (m == size * 2 + 1)
                    {
                        Console.WriteLine("");
                    }
                }
            }
		Console.ReadLine();
        }

        static void Generate ( (int,int) current)
        {
		//https://en.wikipedia.org/wiki/Maze_generation_algorithm#Randomized_depth-first_search


            //maze[current.Item1, current.Item2] = ' ';
            while  
                ( 
                maze[current.Item1 + 2, current.Item2] == '#' ||
                maze[current.Item1 - 2, current.Item2] == '#'  || 
                maze[current.Item1 , current.Item2 + 2] == '#'  || 
                maze[current.Item1 , current.Item2 -2 ] == '#' 
                )
            {
                maze[current.Item1, current.Item2] = ' ';
                int val = rnd.Next(1, 5);
                switch (val)
                {
                    case 1:
                        if (maze[current.Item1 + 2, current.Item2] == '#' && maze[current.Item1 + 1, current.Item2 +1] != ' ' && maze[current.Item1 + 1, current.Item2 -1] != ' ')
                        {
                            maze[current.Item1 + 1, current.Item2] = ' ';
                            current.Item1 = current.Item1 + 2;
                            Generate(current);
                        }
                        break;
                    case 2:
                        if (maze[current.Item1  - 2, current.Item2] == '#' && maze[current.Item1 - 1, current.Item2 +1] != ' ' && maze[current.Item1 - 1, current.Item2 -1] != ' ')
                        {
                            maze[current.Item1 - 1, current.Item2] = ' ';
                            current.Item1 = current.Item1 - 2;
                            Generate(current);
                        }
                        break;
                    case 3:
                        if (maze[current.Item1  , current.Item2 + 2] == '#' && maze[current.Item1 + 1, current.Item2 +1] != ' ' && maze[current.Item1 - 1, current.Item2 -1] != ' ')
                        {
                            maze[current.Item1  , current.Item2 + 1] = ' ';
                            current.Item2 = current.Item2 + 2;
                            Generate(current);
                        }
                        break;
                    case 4:
                        if (maze[current.Item1 , current.Item2 -2] == '#' && maze[current.Item1 + 1, current.Item2 -1] != ' ' && maze[current.Item1 - 1, current.Item2 -1] != ' ')
                        {
                            maze[current.Item1 , current.Item2 -1] = ' ';
                            current.Item2 = current.Item2 - 2;
                            Generate(current);
                        }
                        break;


                }

            }
        }
    }
}

