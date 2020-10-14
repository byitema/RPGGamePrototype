using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    class Armor: Spell
    {
        public Armor(CharacterWithMagic owner)
        {
            if (!owner.IsKnowSpell(this.GetType()))
            {
                throw new Exception("Персонаж " + owner.Name + " не знает данное заклинание!");
            }

            MinManaNeeded = 50;

            IsMotorComponentNeeded = true;

            IsVerbalComponentNeeded = true;
            MagicWord = "Armakedavra!";

            Owner = owner;
        }

        private uint time;
        public uint Time
        {
            get
            {
                return time;
            }

            private set
            {
                time = value;
            }
        }

        public override void Cast(Character character = null, uint power = 0)
        {
            Power = power;
            this.Time = Power*100;
            this.ManaNeeded = Power * this.MinManaNeeded;
            if (character != null)
            {
                if (Owner.ManaPoints >= this.ManaNeeded)
                {
                    if (character.Condition != Conditions.Dead)
                    {
                        if (character.Condition != Conditions.Unbreakable)
                        {
                            base.Cast(character, power);

                            Conditions currentCondition = character.Condition;
                            character.Condition = Conditions.Unbreakable;
                            Owner.ManaPoints = Owner.ManaPoints - this.ManaNeeded;
                            Thread thread = new Thread(new ThreadStart(delegate ()
                            {
                                Thread.Sleep((int)Time);
                                character.Condition = currentCondition;
                            }));
                            thread.Start();
                        }
                        else
                        {
                            throw new Exception("Персонаж уже неуязвимый!");
                        }
                    }
                    else
                    {
                        throw new Exception("Персонаж уже мёртв!");
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
