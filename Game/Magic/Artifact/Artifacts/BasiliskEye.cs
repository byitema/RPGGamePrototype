﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BasiliskEye: Artifact
    {
        public BasiliskEye()
        {

        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (!IsUsed)
            {
                if (character != null)
                {
                    if (character.Condition != Conditions.Dead)
                    {
                        if (character.Condition != Conditions.Paralyzed)
                        {
                            character.Condition = Conditions.Paralyzed;
                            IsUsed = true;
                        }
                        else
                        {
                            throw new Exception("Персонаж уже парализован!");
                        }
                    }
                    else
                    {
                        throw new Exception("Персонаж мёртв!");
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
