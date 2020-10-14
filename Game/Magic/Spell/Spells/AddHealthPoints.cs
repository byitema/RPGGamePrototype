using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AddHealthPoints: Spell
    {
        private uint healthPointsToHeal;
        public uint HealthPointsToHeal
        {
            get
            {
                return healthPointsToHeal;
            }

            private set
            {
                healthPointsToHeal = value;
            }
        }

        public AddHealthPoints(CharacterWithMagic owner, uint healthPointsToHeal)
        {
            if (!owner.IsKnowSpell(this.GetType()))
            {
                throw new Exception("Персонаж " + owner.Name + " не знает данное заклинание!");
            }

            MinManaNeeded = 2;

            IsMotorComponentNeeded = true;
            
            IsVerbalComponentNeeded = true;
            MagicWord = "Addakedavra!";

            HealthPointsToHeal = healthPointsToHeal;
            Owner = owner;
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (character != null)
            {
                if (character.MaxHealthPoints - character.HealthPoints > this.HealthPointsToHeal)
                {
                    this.ManaNeeded = this.MinManaNeeded * this.HealthPointsToHeal;
                    if (Owner.ManaPoints >= this.ManaNeeded)
                    {
                        base.Cast(character, power);

                        character.HealthPoints = character.HealthPoints + this.HealthPointsToHeal;
                        Owner.ManaPoints = Owner.ManaPoints - this.ManaNeeded;
                    }
                    else
                    {
                        base.Cast(character, power);
                        this.HealthPointsToHeal = this.Owner.ManaPoints / this.MinManaNeeded;
                        this.ManaNeeded = this.HealthPointsToHeal * this.MinManaNeeded;
                        character.HealthPoints = character.HealthPoints + this.HealthPointsToHeal;
                        this.Owner.ManaPoints = this.Owner.ManaPoints - this.ManaNeeded;
                    }
                }
                else
                {
                    this.ManaNeeded = this.MinManaNeeded * (character.MaxHealthPoints - character.HealthPoints);
                    if (Owner.ManaPoints >= this.ManaNeeded)
                    {
                        base.Cast(character, power);

                        character.HealthPoints = character.MaxHealthPoints;
                        this.Owner.ManaPoints = Owner.ManaPoints - this.ManaNeeded;
                    }
                    else
                    {
                        this.HealthPointsToHeal = this.Owner.ManaPoints / this.MinManaNeeded;
                        this.ManaNeeded = this.HealthPointsToHeal * this.MinManaNeeded;
                        if (character.MaxHealthPoints - character.HealthPoints > this.HealthPointsToHeal)
                        {
                            character.HealthPoints = character.HealthPoints + this.HealthPointsToHeal;
                            this.Owner.ManaPoints = this.Owner.ManaPoints - this.ManaNeeded;
                        }
                        else
                        {
                            this.ManaNeeded = this.MinManaNeeded * (character.MaxHealthPoints - character.HealthPoints);
                            character.HealthPoints = character.MaxHealthPoints;
                            this.Owner.ManaPoints = Owner.ManaPoints - this.ManaNeeded;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Цель не указана!");
            }
        }
    }
}