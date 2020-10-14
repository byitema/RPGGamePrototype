using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    enum BottleSizes
    {
        Small,
        Medium,
        Big
    }

    abstract class Artifact : IMagic
    {
        protected uint power = 0;
        public uint Power
        {
            get
            {
                return power;
            }

            protected set
            {
                power = value;
            }
        }

        protected bool isUsed = false;
        public bool IsUsed
        {
            get
            {
                return isUsed;
            }

            protected set
            {
                isUsed = value;
            }
        }

        public virtual void Cast(Character character = null, uint power = 0)
        {

        }
    }
}
