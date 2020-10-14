using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Decoction: Artifact
    {
        public Decoction()
        {

        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (!IsUsed)
            {
                if (character != null)
                {
                    if (character.Condition == Conditions.Poisoned)
                    {
                        character.Condition = Conditions.Healthy;
                        character.HealthPoints = character.HealthPoints;
                        IsUsed = true;
                    }
                    else
                    {
                        throw new Exception("Персонаж не отравлен!");
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
