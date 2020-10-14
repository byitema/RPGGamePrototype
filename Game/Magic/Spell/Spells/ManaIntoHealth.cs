using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ManaIntoHealth: Spell
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

        private HealthTransmitter transmitter;
        public HealthTransmitter Transmitter
        {
            get
            {
                return transmitter;
            }

            private set
            {
                transmitter = value;
            }
        }

        public ManaIntoHealth(CharacterWithMagic owner, HealthTransmitter transmitter)
        {
            if (!owner.IsKnowSpell(this.GetType()))
            {
                throw new Exception("Персонаж " + owner.Name + " не знает данное заклинание!");
            }

            MinManaNeeded = 2;

            IsMotorComponentNeeded = true;

            IsVerbalComponentNeeded = true;
            MagicWord = "Manakedavra!";

            Transmitter = transmitter;
            Owner = owner;
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (character != null)
            {
                try
                {
                    this.Owner.UseArtifact(Transmitter);
                }
                catch (Exception ex)
                {
                    throw new Exception("Заклинание не может быть выполнено! " + ex.Message);
                }
                this.HealthPointsToHeal = character.MaxHealthPoints - character.HealthPoints;
                this.ManaNeeded = this.MinManaNeeded * this.HealthPointsToHeal;
                if (this.Owner.ManaPoints >= this.ManaNeeded)
                {
                    base.Cast(character, power);

                    character.HealthPoints = character.MaxHealthPoints;
                    this.Owner.ManaPoints = this.Owner.ManaPoints - this.ManaNeeded;
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
                throw new Exception("Цель не указана!");
            }
        }
    }
}