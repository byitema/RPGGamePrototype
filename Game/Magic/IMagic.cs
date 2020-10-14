using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IMagic
    {
        void Cast(Character character = null, uint power = 0);
    }
}
