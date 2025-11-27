using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snack_Game
{
    internal class Object
    {
      
        public char Symbol;
        public bool IsSolid;
        public Object( char symbol,bool issloid)
        {
            
            Symbol = symbol;
            IsSolid = issloid;
        }


    }
}
