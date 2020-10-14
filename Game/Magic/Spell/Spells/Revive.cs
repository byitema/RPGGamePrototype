using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Revive: Spell
    {
        public Revive(CharacterWithMagic owner)
        {
            if (!owner.IsKnowSpell(this.GetType()))
            {
                throw new Exception("Персонаж " + owner.Name + " не знает данное заклинание!");
            }

            MinManaNeeded = 150;
            ManaNeeded = MinManaNeeded;

            IsMotorComponentNeeded = true;

            IsVerbalComponentNeeded = true;
            MagicWord = "Revivakedavra!";

            Owner = owner;
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (character != null)
            {
                if (Owner.ManaPoints >= this.ManaNeeded)
                {
                    if (character.Condition == Conditions.Dead)
                    {
                        base.Cast(character, power);

                        character.HealthPoints = 1;
                        Owner.ManaPoints = Owner.ManaPoints - this.ManaNeeded;
                    }
                    else
                    {
                        throw new Exception("Персонаж не мёртв!");
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
