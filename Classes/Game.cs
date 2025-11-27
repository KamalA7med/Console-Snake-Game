using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Snack_Game
{
    internal class Game
    {
       public  Snack snack;
       public Grid grid;
        private char Snack_Symbol;
       private char Apple_Symbol;
        private int FrameDelayMili;
        
        public Game(Snack snack, Grid grid,char SnackSymbol,char Apple_Symbol,char Border_Symbol,int framedelay)
        {
            this.snack = snack;
            this.grid = grid;
            this.Snack_Symbol = SnackSymbol;
            this.Apple_Symbol = Apple_Symbol;
            FrameDelayMili = framedelay;
            Make_Borders(Border_Symbol);
            Generte_Apple();
        }

        private void Make_Borders(char Border_Symbol)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    if (i == 0 || i == grid.Length - 1 || j == 0 || j == grid.Width - 1)
                    {
                        grid.Array[i, j] = new Object(Border_Symbol, true);
                    }
                    else
                    {
                        grid.Array[i, j] = new Object(' ', false);
                    }
                }
            }

        }
        private void Fill_Snack_Cells()
        {
            //'■'
            foreach (var cell in snack.Snack_History)
            {
                grid.Array[cell.x, cell.y] = new Object(Snack_Symbol, true);
            }
        }
        private void Generte_Apple()
        {
            Random random = new Random();
            (int x, int y) Apple_Postion;
            Apple_Postion.x = 0;
            Apple_Postion.y = 0;
            while ( grid.Array[Apple_Postion.x, Apple_Postion.y].IsSolid == true)   
            {
                Apple_Postion.x = random.Next(1, grid.Length - 2);
                Apple_Postion.y = random.Next(1, grid.Width - 2); 
            }
            grid.Array[Apple_Postion.x, Apple_Postion.y]=new Object(Apple_Symbol, false);
        }
        private void Draw_Grid()
        {
            Fill_Snack_Cells();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    Console.Write(grid.Array[i, j].Symbol);
                }
                Console.WriteLine();
            }
        }
        private bool isapple(int  x, int y)
        {
            return grid.Array[x, y].Symbol == Apple_Symbol;
        }
        private Direction GetMovementDirection(ConsoleKey key)
        {
            Direction dir=snack.Movig_Direction;
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    {
                        if (dir == Direction.left)
                        {
                            if (snack.Snack_History.Count == 1)
                            {
                                dir = Direction.right;
                            }
                            else
                            {
                                break;
                            }

                        }
                        dir = Direction.right;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        if (dir == Direction.right)
                        {
                            if (snack.Snack_History.Count == 1)
                            {
                                dir = Direction.left;
                            }
                            else
                            {
                                break;
                            }

                        }
                        dir = Direction.left;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        if (dir == Direction.down)
                        {
                            if (snack.Snack_History.Count == 1)
                            {
                                dir = Direction.up;
                            }
                            else
                            {
                                break;
                            }

                        }
                        dir = Direction.up;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (dir == Direction.up)
                        {
                            if( snack.Snack_History.Count == 1)
                            {
                                dir = Direction.down;
                            }
                            else
                            {
                                break;
                            }

                        }
                            dir = Direction.down;
                        break;
                    }
            }
            return dir;
        }
        private bool IsObstcale(int x,int y)
        {
            return (grid.Array[x, y].IsSolid);
        }
       
        private void GetNextMove(Direction dir,out bool Is_Next_Move_An_Apple,out bool IsObst)
        {
            IsObst = false;
            Is_Next_Move_An_Apple = false;
            switch (dir)
            {
                case Direction.left:
                    {
                        Is_Next_Move_An_Apple = isapple(snack.Snack_History[snack.Snack_History.Count - 1].x,
                            snack.Snack_History[snack.Snack_History.Count - 1].y - 1);
                        IsObst = IsObstcale(snack.Snack_History[snack.Snack_History.Count - 1].x,
                           snack.Snack_History[snack.Snack_History.Count - 1].y - 1);
                        break;
                    }
                case Direction.right:
                    {
                        Is_Next_Move_An_Apple = isapple(snack.Snack_History[snack.Snack_History.Count - 1].x,
                            snack.Snack_History[snack.Snack_History.Count - 1].y + 1);
                        IsObst = IsObstcale(snack.Snack_History[snack.Snack_History.Count - 1].x,
                           snack.Snack_History[snack.Snack_History.Count - 1].y + 1);
                        break;
                    }
                case Direction.up:
                    {
                        Is_Next_Move_An_Apple = isapple(snack.Snack_History[snack.Snack_History.Count - 1].x - 1,
                            snack.Snack_History[snack.Snack_History.Count - 1].y);
                     IsObst = IsObstcale(snack.Snack_History[snack.Snack_History.Count - 1].x - 1,
                            snack.Snack_History[snack.Snack_History.Count - 1].y);
                        break;
                    }
                case Direction.down:
                    {
                        Is_Next_Move_An_Apple = isapple(snack.Snack_History[snack.Snack_History.Count - 1].x + 1,
                            snack.Snack_History[snack.Snack_History.Count - 1].y);
                        IsObst = IsObstcale(snack.Snack_History[snack.Snack_History.Count - 1].x + 1,
                           snack.Snack_History[snack.Snack_History.Count - 1].y);
                        break;
                    }
            }
        }
        public void Start()
        {
            int Score = 0;
            bool Is_Next_Move_An_Apple = false;
            while (true)
            {
                
                if (Is_Next_Move_An_Apple){
                    Generte_Apple();
                    Is_Next_Move_An_Apple = false;
                }
                Console.Clear();
                Console.WriteLine("------------------------");
                Console.WriteLine($"   Your Score : {Score}");
                Console.WriteLine("------------------------");
                Draw_Grid();
                Direction dir=snack.Movig_Direction;
                DateTime time = DateTime.Now; 
                while ((DateTime.Now - time).Milliseconds < FrameDelayMili)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey().Key;      
                        dir=GetMovementDirection(key);
                        break;
                    }
                }
                bool IsObst = false;
               GetNextMove(dir,out Is_Next_Move_An_Apple,out IsObst);
                if(Is_Next_Move_An_Apple)
                {
                    Score = Score + 1;
                }
                if(IsObst)
                {

                    Console.WriteLine("------------------------");
                    Console.WriteLine("        You Lose");
                    Console.WriteLine("------------------------");
                    break;
                   
                }
                snack.Move(grid, dir, Is_Next_Move_An_Apple);
            }
        }
    }
}
