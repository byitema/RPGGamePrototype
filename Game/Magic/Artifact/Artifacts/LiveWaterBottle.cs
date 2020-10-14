using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class LiveWaterBottle: Artifact
    { 
        private BottleSizes bottleSize;
        public BottleSizes BottleSize
        {
            get
            {
                return bottleSize;
            }

            private set
            {
                bottleSize = value;
            }
        }

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

        public LiveWaterBottle(BottleSizes size)
        {
            BottleSize = size;
            if (BottleSize == BottleSizes.Small)
            {
                HealthPointsToHeal = 10;
            }
            else if (BottleSize == BottleSizes.Medium)
            {
                HealthPointsToHeal = 25;
            }
            else
            {
                HealthPointsToHeal = 50;
            }
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (!IsUsed)
            {
                if (character != null)
                {
                    if (character.MaxHealthPoints - character.HealthPoints > this.HealthPointsToHeal)
                    {
                        character.HealthPoints = character.HealthPoints + this.HealthPointsToHeal;
                    }
                    else
                    {
                        character.HealthPoints = character.MaxHealthPoints;
                    }
                    IsUsed = true;
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
