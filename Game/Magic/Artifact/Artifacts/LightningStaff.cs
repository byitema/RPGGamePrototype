using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class LightningStaff: Artifact
    {
        public LightningStaff(uint power)
        {
            Power = power;
            if (Power == 0)
            {
                IsUsed = true;
            }
        }

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

        public override void Cast(Character character = null, uint power = 0)
        {
            if (!IsUsed)
            {
                if (character != null)
                {
                    if (power > this.Power)
                    {
                        power = this.Power;
                    }

                    this.HealthPointsToSubtract = power * 5;
                    if (character.HealthPoints > this.HealthPointsToSubtract)
                    {
                        character.HealthPoints = character.HealthPoints - this.HealthPointsToSubtract;
                    }
                    else
                    {
                        character.HealthPoints = 0;
                    }

                    this.Power = this.Power - power;
                    if (this.Power == 0)
                    {
                        IsUsed = true;
                    }
                }
                else
                {
                    throw new Exception("Цель не указана!");
                }
            }
            else
            {
                throw new Exception("Посох больше не обладает мощностью!");
            }
        }
    }
}
