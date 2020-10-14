using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Heal: Spell
    {
        public Heal(CharacterWithMagic owner)
        {
            if (!owner.IsKnowSpell(this.GetType()))
            {
                throw new Exception("Персонаж " + owner.Name + " не знает данное заклинание!");
            }

            MinManaNeeded = 20;
            ManaNeeded = MinManaNeeded;

            IsMotorComponentNeeded = true;

            IsVerbalComponentNeeded = true;
            MagicWord = "Healakedavra!";

            Owner = owner;
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (character != null)
            {
                if (Owner.ManaPoints >= this.ManaNeeded)
                {
                    if (character.Condition == Conditions.Ill)
                    {
                        base.Cast(character, power);

                        character.Condition = Conditions.Healthy;
                        character.HealthPoints = character.HealthPoints;
                        Owner.ManaPoints = Owner.ManaPoints - this.ManaNeeded;
                    }
                    else
                    {
                        throw new Exception("Персонаж не болен!");
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
