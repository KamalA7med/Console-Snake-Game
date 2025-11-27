using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snack_Game
{
    internal class Apple:Object
    {
        public int Reward;
        public Apple(int reward,char Sym,bool issolid):base(Sym,issolid) 
        {
            Reward = reward;
        }
        
    }
}
