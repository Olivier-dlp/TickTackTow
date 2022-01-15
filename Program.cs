using System;
using System.Collections.Generic;

namespace TIckTackTow
{
    class Program
    {
        static void Main(string[] args)
        {
            //Making the Console neet
            ConsoleColor[] collors=
            {
                ConsoleColor.Red, ConsoleColor.Yellow,ConsoleColor.DarkBlue,ConsoleColor.Blue,ConsoleColor.DarkCyan,ConsoleColor.Cyan,ConsoleColor.DarkMagenta,ConsoleColor.Magenta
            };
            Random r = new Random();
            Setting Set = new Setting(collors[r.Next(0,collors.Length-1)],ConsoleColor.Black,"TickTackToe",25,50);
            

            string[,] Grid = new string[5,5]
            {
                //[0,0] . [0,2] .[0,4]
                //[2,0] . [2,2] .[2,4]
                //[4,0] . [4,2] .[4,4]


                //[1,1] . [1,2] .[1,3]
                //[2,1] . [2,2] .[2,3]
                //[3,1] . [3,2] .[3,3]
                {" ",   "|",  " " ,"|",  " "},
                {"-","-","-","-","-"},
                {" ",   "|",  " " ,"|",  " "},
                {"-","-","-","-","-"},
                {" ",   "|",  " " ,"|",  " "} 

                
            };


    
            bool Yourtourn = true;
            string _x_= "X";
            string _y_ = "Y";
            string In = "";



            //Checking for errors
            programm();
            void programm()
            {
                while (true)
                {
                    try
                    {
                        while (true)
                        {

                            Print();
                            CheckWin();
                            Input();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ther was an Error: wait.");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();

                    }
                }
            }
           
           
            
            
            
            void Input()
            {
                
                if (Yourtourn)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Tourn for X: ");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Tourn for Y: ");
                }
                
                string[] Inpu = Console.ReadLine().Split(":");
                int x = Convert.ToInt32(Inpu[1]);
                int y = Convert.ToInt32(Inpu[0]);
                //--

                int x_ = 0;
                int y_ = 0;

                //cordinates(x,y)
                if (y == 1)
                {
                    switch (x)
                    {
                        case (1):
                            x_ = 0;
                            y_ = 0;
                            break;
                        case (2):
                            x_ = 0;
                            y_ = 2;
                            break;
                        case (3):
                            x_ = 0;
                            y_ = 4;
                            break;
                    }
                }
                else if (y == 2)
                {
                    switch (x)
                    {
                        case (1):
                            x_ = 2;
                            y_ = 0;
                            break;
                        case (2):
                            x_ = 2;
                            y_ = 2;
                            break;
                        case (3):
                            x_ = 2;
                            y_ = 4;
                            break;
                    }
                }
                else if (y == 3)
                {
                    switch (x)
                    {
                        case (1):
                            x_ = 4;
                            y_ = 0;
                            break;
                        case (2):
                            x_ = 4;
                            y_ = 2;
                            break;
                        case (3):
                            x_ = 4;
                            y_ = 4;
                            break;
                    }
                }
                CheckAndWrite(x_, y_);

                void CheckAndWrite(int X, int Y)
                {
                    //Check if ther is something and write
                    if (Grid[X,Y] == " ")
                    {
                        if (Yourtourn)
                        {
                            In = _x_;
                        }
                        else
                        {
                            In = _y_;
                        }
                        
                        Grid[X, Y] = In;
                        
                        Yourtourn = !Yourtourn;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Did not Work!!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Print();
                        Input();
                        //Go back
                    }
                }



                
                
            }





            void CheckWin()
            {
                string[] _Inputs = { Grid[0, 0] + ":0|0", Grid[0, 2] + ":0|2", Grid[0, 4] + ":0|4", Grid[2, 0] + ":2|0", Grid[2, 2] + ":2|2", Grid[2, 4] + ":2|4", Grid[4, 0] + ":4|0", Grid[4, 2] + ":4|2", Grid[4, 4] + ":4|4" };
                List<string> X = new List<string>();
                List<string> Y = new List<string>();

                foreach (string s in _Inputs)
                {
                    if (s[0] == 'X')
                    {
                        string[] reformat = s.Split(':');
                        X.Add(reformat[1]);
                    }
                    else if(s[0] == 'Y')
                    {
                        string[] reformat = s.Split(':');
                        Y.Add(reformat[1]);
                    }
                }

                // this is for X
                int X_x0 = 0;
                int X_x2 = 0;
                int X_x4 = 0;

                int X_y0 = 0;
                int X_y2 = 0;
                int X_y4 = 0;

                int Xdiagonal1 = 0;
                int Xdiagonal2 = 0;

                //this is for Y
                int Y_x0 = 0;
                int Y_x2 = 0;
                int Y_x4 = 0;

                int Y_y0 = 0;
                int Y_y2 = 0;
                int Y_y4 = 0;

                int Ydiagonal1 = 0;
                int Ydiagonal2 = 0;
                //Check how many X they are
                foreach (string s in X)
                {
                    string[] X_Y = s.Split('|');

                    switch (X_Y[0])
                    {
                        case ("0"):
                            X_x0++;
                            break;
                        case ("2"):
                            X_x2++;
                            break;
                        case ("4"):
                            X_x4++;
                            break;
                    }
                    switch (X_Y[1])
                    {
                        case ("0"):
                            X_y0++;
                            break;
                        case ("2"):
                            X_y2++;
                            break;
                        case ("4"):
                            X_y4++;
                            break;
                    }

                    if ((X_Y[0] == "0" & X_Y[1] == "0") | (X_Y[0] == "2" & X_Y[1] == "2") | (X_Y[0] == "4" & X_Y[1] == "4"))
                    {

                        Xdiagonal1++;

                    }
                    if ((X_Y[0] == "0" & X_Y[1] == "4") | (X_Y[0] == "2" & X_Y[1] == "2") | (X_Y[0] == "4" & X_Y[1] == "0"))
                    {

                        Xdiagonal2++;

                    }

                }

                //Check how many Y there are
                foreach (string s in Y)
                {
                    string[] X_Y = s.Split('|');

                    switch (X_Y[0])
                    {
                        case ("0"):
                            Y_x0++;
                            break;
                        case ("2"):
                            Y_x2++;
                            break;
                        case ("4"):
                            Y_x4++;
                            break;
                    }
                    switch (X_Y[1])
                    {
                        case ("0"):
                            Y_y0++;
                            break;
                        case ("2"):
                            Y_y2++;
                            break;
                        case ("4"):
                            Y_y4++;
                            break;
                    }

                    if ((X_Y[0] == "0" & X_Y[1] == "0") | (X_Y[0] == "2" & X_Y[1] == "2") | (X_Y[0] == "4" & X_Y[1] == "4"))
                    {

                        Ydiagonal1++;

                    }
                    if ((X_Y[0] == "0" & X_Y[1] == "4") | (X_Y[0] == "2" & X_Y[1] == "2") | (X_Y[0] == "4" & X_Y[1] == "0"))
                    {

                        Ydiagonal2++;

                    }

                }
                if ((X_x0 == 3 | X_x2 == 3 | X_x4 == 3 | X_y0 == 3 | X_y2 == 3 | X_y4 == 3) | Xdiagonal1 == 3 | Xdiagonal2 == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(">>>X<<< WON!!!!");
                    
                    Finish();
                }
                else if ((Y_x0 == 3 | Y_x2 == 3 | Y_x4 == 3 | Y_y0 == 3 | Y_y2 == 3 | Y_y4 == 3) | Ydiagonal1 == 3 | Ydiagonal2 == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(">>>Y<<< WON!!!!");
                    
                    Finish();
                }

            }







            //Print the Grid
            void Print()
            {
                for (int x = 0; x < 5; x++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(Grid[x, i]);

                    }
                    Console.WriteLine();
                }
            }

            
            void Finish()
            {

                System.Threading.Thread.Sleep(1000);
                restart();

                void restart()
                {
                    Console.Write("Do you want to Play again? (Y/N): ");
                    string answer = Console.ReadLine();
                    if (answer == "Y" | answer == "y")
                    {
                        //reset grid
                        Grid = new string[5,5]{{" ",   "|",  " " ,"|",  " "},{"-","-","-","-","-"},{" ",   "|",  " " ,"|",  " "},{"-","-","-","-","-"},{" ",   "|",  " " ,"|",  " "}};
                        Console.Clear();
                        programm();
                    }
                    else if (answer == "N" | answer == "n")
                    {
                        Environment.Exit(0);   
                    }
                    else
                    {
                        Console.WriteLine("??? sry pleas repeat...");
                        Console.Clear();
                        Finish();
                    }
                }
                
            }
            
            
            
        }
    }
}
