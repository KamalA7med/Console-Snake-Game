using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snack_Game
{
    public enum Direction { up=0,down=1,right=2,left=3}
    internal class Snack
    {
        public List<(int x,int y)> Snack_History;
        public Direction Movig_Direction; 
        public Snack()
        {
            Snack_History=new List<(int x,int y)> ();
            Movig_Direction = Direction.down;
        }
         bool IsValidMove(Grid grid,int x,int y)
        {
            return !grid.Array[x, y].IsSolid;
        }
        private void MoveUp()
        {
            Snack_History.Add(ValueTuple.Create(Snack_History[Snack_History.Count - 1].x - 1,
                                           Snack_History[Snack_History.Count - 1].y));
        }
        private void MoveDown()
        {
            Snack_History.Add(ValueTuple.Create(Snack_History[Snack_History.Count - 1].x + 1,
                                 Snack_History[Snack_History.Count - 1].y));
        }
        private void MoveRight()
        {
            Snack_History.Add(ValueTuple.Create(Snack_History[Snack_History.Count - 1].x,
                              Snack_History[Snack_History.Count - 1].y + 1));
        }
        private void MoveLeft()
        {
            Snack_History.Add(ValueTuple.Create(Snack_History[Snack_History.Count - 1].x,
                               Snack_History[Snack_History.Count - 1].y - 1));
        }
        private bool GetDirection(Grid grid)
        {
            switch (Movig_Direction)
            {
                case Direction.up:
                    {
                        if (IsValidMove(grid, Snack_History[Snack_History.Count - 1].x - 1, Snack_History[Snack_History.Count - 1].y))
                        {
                            MoveUp();
                            break;
                        }
                        return true;
                    }
                case Direction.down:
                    {

                        if (IsValidMove(grid, Snack_History[Snack_History.Count - 1].x + 1, Snack_History[Snack_History.Count - 1].y))
                        {
                            MoveDown();
                            break;
                        }
                        return false;
                    }
                case Direction.right:
                    {
                        if (IsValidMove(grid, Snack_History[Snack_History.Count - 1].x, Snack_History[Snack_History.Count - 1].y + 1))
                        {
                            MoveRight();
                            break;
                        }
                        return false;
                    }
                case Direction.left:
                    {
                        if (IsValidMove(grid, Snack_History[Snack_History.Count - 1].x, Snack_History[Snack_History.Count - 1].y - 1))
                        {
                            MoveLeft();
                            break;
                        }
                        return false;
                    }

            }
            return true;

        }

        public bool Move(Grid grid, Direction direction,bool isapple)
        {
            if(direction!=Movig_Direction)
            {
                Movig_Direction = direction;
            }
           if( !GetDirection(grid))
            {
                return false;
            }

            if (!isapple)
            {
                grid.Array[Snack_History[0].x, Snack_History[0].y] = new Object(' ', false);
                Snack_History.RemoveAt(0);

            }
            return true;
        }
       


        
    }
}
