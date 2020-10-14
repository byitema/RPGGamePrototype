using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DieOff: Spell
    {
        public DieOff(CharacterWithMagic owner)
        {
            if (!owner.IsKnowSpell(this.GetType()))
            {
                throw new Exception("Персонаж " + owner.Name + " не знает данное заклинание!");
            }

            MinManaNeeded = 85;
            ManaNeeded = MinManaNeeded;

            IsMotorComponentNeeded = true;

            IsVerbalComponentNeeded = true;
            MagicWord = "Diekedavra!";

            Owner = owner;
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (character != null)
            {
                if (Owner.ManaPoints >= this.ManaNeeded)
                {
                    if (character.Condition == Conditions.Paralyzed)
                    {
                        base.Cast(character, power);

                        character.Condition = Conditions.Weakened;
                        character.HealthPoints = 1;
                        Owner.ManaPoints = Owner.ManaPoints - this.ManaNeeded;
                    }
                    else
                    {
                        throw new Exception("Персонаж не парализован!");
                    }
                }
                else
                {
                    throw new Exception("Недостаточно маны!");
                }
            }
            else
            {
                throw new Exception("Цель не указана!");
            }
        }
    }
}
