using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DeadWaterBottle: Artifact
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

        private uint manaPointsToAdd;
        public uint ManaPointsToAdd
        {
            get
            {
                return manaPointsToAdd;
            }

            private set
            {
                manaPointsToAdd = value;
            }
        }

        public DeadWaterBottle(BottleSizes size)
        {
            BottleSize = size;
            if (BottleSize == BottleSizes.Small)
            {
                ManaPointsToAdd = 10;
            }
            else if (BottleSize == BottleSizes.Medium)
            {
                ManaPointsToAdd = 25;
            }
            else
            {
                ManaPointsToAdd = 50;
            }
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (!IsUsed)
            {
                if (character != null)
                {
                    CharacterWithMagic characterWithMagic = (CharacterWithMagic)character;
                    if (characterWithMagic.MaxManaPoints - characterWithMagic.ManaPoints > this.ManaPointsToAdd)
                    {
                        characterWithMagic.ManaPoints = characterWithMagic.ManaPoints + this.ManaPointsToAdd;
                    }
                    else
                    {
                        characterWithMagic.ManaPoints = characterWithMagic.MaxManaPoints;
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
