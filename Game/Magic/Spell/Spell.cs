using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    abstract class Spell: IMagic
    {
        protected uint minManaNeeded;
        public uint MinManaNeeded
        {
            get
            {
                return minManaNeeded;
            }

            protected set
            {
                minManaNeeded = value;
            }
        }

        protected uint manaNeeded;
        public uint ManaNeeded
        {
            get
            {
                return manaNeeded;
            }

            protected set
            {
                manaNeeded = value;
            }
        }

        protected bool isVerbalComponentNeeded;
        public bool IsVerbalComponentNeeded
        {
            get
            {
                return isVerbalComponentNeeded;
            }

            protected set
            {
                isVerbalComponentNeeded = value;
            }
        }
        protected bool isMotorComponentNeeded;
        public bool IsMotorComponentNeeded
        {
            get
            {
                return isMotorComponentNeeded;
            }

            protected set
            {
                isMotorComponentNeeded = value;
            }
        }

        protected CharacterWithMagic owner;
        public CharacterWithMagic Owner
        {
            get
            {
                return owner;
            }

            protected set
            {
                owner = value;
            }
        }

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

        protected string magicWord = "";
        public string MagicWord
        {
            get
            {
                return magicWord;
            }

            protected set
            {
                magicWord = value;
            }
        }

        protected bool[] moves = new bool[] {false, true};
        public bool[] Moves
        {
            get
            {
                return moves;
            }

            protected set
            {
                moves = value;
            }
        }

        public virtual void Cast(Character character = null, uint power = 0)
        {
            this.say();
            this.move();
        }

        protected void say()
        {
            if (IsVerbalComponentNeeded)
            {
                Owner.Say(MagicWord);
            }
        }

        protected void move()
        {
            if (IsMotorComponentNeeded)
            {
                if (Owner.IsMovingLeft)
                {
                    foreach (bool movement in Moves)
                    {
                        Owner.IsMovingLeft = movement;
                    }
                }
                else
                {
                    foreach (bool movement in Moves)
                    {
                        Owner.IsMovingRight = movement;
                    }
                }
            }
        }
    }
}
