using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class LearnedSpellsList
    {
        private List<Type> spells;
        public List<Type> Spells
        {
            get
            {
                return spells;
            }

            private set
            {
                spells = value;
            }
        }

        public LearnedSpellsList()
        {
            Spells = new List<Type>();
        }

        public void AddSpell(Type type)
        {
            if (!type.IsSubclassOf(typeof(Spell)))
            {
                throw new Exception(type.ToString() + "- это не заклинание!");
            }

            for (int i = 0; i < Spells.Count(); i++)
            {
                if (type == Spells[i])
                {
                    throw new Exception("Персонаж уже знает данное заклинание!");
                }
            }

            Spells.Add(type);
        }

        public void RemoveSpell(Type type)
        {
            if (!type.IsSubclassOf(typeof(Spell)))
            {
                throw new Exception(type.ToString() + " - это не заклинание!");
            }

            bool isSuccess = false;
            for (int i = 0; i < Spells.Count(); i++)
            {
                if (type == Spells[i])
                {
                    Spells.Remove(type);
                    isSuccess = true;
                    break;
                }
            }

            if (!isSuccess)
            {
                throw new Exception("Персонаж не знает данное заклинание!");
            }
        }
    }
}
