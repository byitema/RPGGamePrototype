using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Antidote: Spell
    {
        public Antidote(CharacterWithMagic owner)
        {
            if (!owner.IsKnowSpell(this.GetType()))
            {
                throw new Exception("Персонаж " + owner.Name + " не знает данное заклинание!");
            }

            MinManaNeeded = 30;
            ManaNeeded = MinManaNeeded;

            IsMotorComponentNeeded = true;
            
            IsVerbalComponentNeeded = true;
            MagicWord = "Antikedavra!";

            Owner = owner;
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (character != null)
            {
                if (Owner.ManaPoints >= this.ManaNeeded)
                {
                    if (character.Condition == Conditions.Poisoned)
                    {
                        base.Cast(character, power);

                        character.Condition = Conditions.Healthy;
                        character.HealthPoints = character.HealthPoints;
                        Owner.ManaPoints = Owner.ManaPoints - this.ManaNeeded;
                    }
                    else
                    {
                        throw new Exception("Персонаж не отравлен!");
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
