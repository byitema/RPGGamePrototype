using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class CharacterWithMagic: Character
    {
        private uint maxManaPoints;
        public uint MaxManaPoints
        {
            get
            {
                return maxManaPoints;
            }

            private set
            {
                maxManaPoints = value;
            }
        }
        private uint manaPoints;
        public uint ManaPoints
        {
            get
            {
                return manaPoints;
            }

            set
            {
                if (value <= MaxManaPoints)
                {
                    manaPoints = value;
                }
                else
                {
                    throw new Exception("Количество маны не может быть больше максимального!");
                }
            }
        }

        private LearnedSpellsList learnedSpells;
        public LearnedSpellsList LearnedSpells
        {
            get
            {
                return learnedSpells;
            }

            private set
            {
                learnedSpells = value;
            }
        }

        public CharacterWithMagic(string name, Races race, Genders gender, uint age): base(name, race, gender, age)
        {
            MaxManaPoints = 250;
            ManaPoints = MaxManaPoints;

            LearnedSpells = new LearnedSpellsList();
        }

        public override string ToString()
        {
            return base.ToString() + ", Mana: " + (100 * ManaPoints / MaxManaPoints).ToString() + "%";
        }

        public bool IsKnowSpell(Type type)
        {
            if (!type.IsSubclassOf(typeof(Spell)))
            {
                throw new Exception(type.ToString() + "- это не заклинание!");
            }

            for (int i = 0; i < LearnedSpells.Spells.Count(); i++)
            {
                if (type == LearnedSpells.Spells[i])
                {
                    return true;
                }
            }

            return false;
        }

        public void UseSpell(Spell spell, Character character = null, uint power = 0)
        {
            if (this == spell.Owner)
            {
                spell.Cast(character, power);
            }
            else
            {
                throw new Exception("Данное заклинание не принадлежит этому персонажу!");
            }
        }

        public string ShowLearnedSpells()
        {
            string info = "";
            for (int i = 0; i < LearnedSpells.Spells.Count(); i++)
            {
                info = info + LearnedSpells.Spells[i].ToString() + " ";
            }

            if (info == "")
            {
                return "Список выученных заклинаний пуст!";
            }

            return info;
        }
    }
}