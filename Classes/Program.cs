using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snack_Game
{
    internal class Program
    {
        public static  (Snack, Grid, char, char, char, int) GetSetiing()
            {
            Snack snack = new Snack();
            snack.Snack_History.Add(ValueTuple.Create(1, 1));
            Grid grid = new Grid(20, 40);
            return (snack, grid, '■', 'A', 'X', 150);
        }
        static void Main(string[] args)
        {
            (Snack snack, Grid grid, char SnackSym, char Apple_Sym, char BorderSym, int delay) setting=GetSetiing();
                Game game = new Game(setting.snack, setting.grid, setting.SnackSym, setting.Apple_Sym, setting.BorderSym,setting.delay);
            game.Start();
           
            
           
        }
    }
}
