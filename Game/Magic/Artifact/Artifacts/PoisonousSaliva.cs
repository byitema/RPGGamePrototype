using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class PoisonousSaliva: Artifact
    {

        private uint healthPointsToSubtract;
        public uint HealthPointsToSubtract
        {
            get
            {
                return healthPointsToSubtract;
            }

            private set
            {
                healthPointsToSubtract = value;
            }
        }

        public PoisonousSaliva(uint power)
        {
            this.Power = power;
            this.HealthPointsToSubtract = 5 * Power;
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (!IsUsed)
            {
                if (character != null)
                {
                    if (character.Condition == Conditions.Weakened || character.Condition == Conditions.Healthy)
                    {
                        character.Condition = Conditions.Poisoned;
                        if (character.HealthPoints > this.HealthPointsToSubtract)
                        {
                            character.HealthPoints = character.HealthPoints - this.HealthPointsToSubtract;
                        }
                        else
                        {
                            character.HealthPoints = 0;
                        }
                    }
                    else
                    {
                        throw new Exception("Персонаж не здоров или не ослаблен!");
                    }
                }
                else
                {
                    throw new Exception("Цель не указана!");
                }
            }
            else
            {
                throw new Exception("Артефакт уже использован!");
            }
        }
    }
}
