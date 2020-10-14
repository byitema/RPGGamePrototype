using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    enum Conditions{
        Healthy,
        Weakened,
        Dead,
        Ill,
        Poisoned,
        Paralyzed,
        Unbreakable
    }

    enum Races
    {
        Elf,
        Khight,
        Wizard
    }

    enum Genders
    {
        Male,
        Female
    }

    class Character : IComparable<Character>, IComparer<Character>
    {
        protected static int NextID = 1;
        public readonly int ID;

        public readonly string Name;

        protected Conditions condition;
        public Conditions Condition
        {
            get
            {
                return condition;
            }

            set
            {
                condition = value;

                if (condition == Conditions.Paralyzed)
                {
                    this.IsAbleToSpeak = false;
                    this.IsMovingLeft = false;
                    this.isMovingRight = false;
                }
                else
                {
                    this.IsAbleToSpeak = true;
                    this.IsMovingLeft = true;
                    this.isMovingRight = true;
                }
                
                if(condition == Conditions.Dead)
                {
                    healthPoints = 0;
                }
            }
        }

        protected bool isAbleToSpeak;
        public bool IsAbleToSpeak
        {
            get
            {
                return isAbleToSpeak;
            }

            protected set
            {
                isAbleToSpeak = value;
            }
        }

        protected bool isMovingRight;
        public bool IsMovingRight
        {
            get
            {
                return isMovingRight;
            }

            set
            {
                isMovingRight = value;
                if (isMovingRight)
                {
                    IsMovingLeft = false;
                }
            }
        }
        protected bool isMovingLeft;
        public bool IsMovingLeft
        {
            get
            {
                return isMovingLeft;
            }

            set
            {
                isMovingLeft = value;
                if (isMovingLeft)
                {
                    IsMovingRight = false;
                }
            }
        }

        public readonly Races Race;
        public readonly Genders Gender;

        protected uint age;
        public uint Age
        {
            get
            {
                return age;
            }

            protected set
            {
                age = value;
            }
        }

        protected uint maxHealthPoints;
        public uint MaxHealthPoints
        {
            get
            {
                return maxHealthPoints;
            }

            protected set
            {
                maxHealthPoints = value;
            }
        }
        protected uint healthPoints;
        public uint HealthPoints
        {
            get
            {
                return healthPoints;
            }

            set
            {
                if (value <= MaxHealthPoints)
                {
                    if (this.Condition != Conditions.Unbreakable)
                    {
                        healthPoints = value;
                        if (this.Condition != Conditions.Ill && this.Condition != Conditions.Poisoned &&
                            this.Condition != Conditions.Paralyzed)
                        {
                            if (100 * healthPoints / MaxHealthPoints >= 10)
                            {
                                Condition = Conditions.Healthy;
                            }
                            else
                            {
                                Condition = Conditions.Weakened;
                            }
                        }

                        if (HealthPoints == 0)
                        {
                            Condition = Conditions.Dead;
                        }
                    }
                    else
                    {
                        if (value > healthPoints)
                        {
                            healthPoints = value;
                        }
                    }
                }
                else
                {
                    throw new Exception("Количество здоровья не может быть больше максимального!");
                }
            }
        }

        protected uint experience;
        public uint Experience
        {
            get
            {
                return experience;
            }

            set
            {
                experience = value;
            }
        }

        private Inventory bag;
        public Inventory Bag
        {
            get
            {
                return bag;
            }

            private set
            {
                bag = value;
            }
        }

        public Character(string name, Races race, Genders gender, uint age)
        {
            if (race == Races.Wizard)
            {
                if (this.GetType() == typeof(CharacterWithMagic))
                {
                    Race = race;
                }
                else
                {
                    throw new Exception("Персонаж не владеющий магией не может быть волшебником!");
                }
            }
            else
            {
                Race = race;
            }

            ID = NextID++;
            Name = name;

            MaxHealthPoints = 100;
            HealthPoints = MaxHealthPoints;
            Condition = Conditions.Healthy;

            IsAbleToSpeak = true;
            IsMovingRight = true;
            IsMovingLeft = false;
            
            Gender = gender;

            Age = age;

            Experience = 0;

            Bag = new Inventory(2);
        }

        public int CompareTo(Character other)
        {
            return this.Experience.CompareTo(other.Experience);
        }

        public int Compare(Character first, Character second)
        {
            if (first.Experience > second.Experience)
            {
                return 1;
            }
            else if (first.Experience < second.Experience)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "Race: " + Race.ToString() + ", Gender: " + Gender.ToString() +
                ", Name: " + Name + ", Health: " + (100 * HealthPoints / MaxHealthPoints).ToString() + "%, " +
                "Condition: " + Condition.ToString() + ", Experience: " + Experience.ToString();
        }

        public void UseArtifact(Artifact artifact, Character character = null, uint power = 0)
        {
            int index = this.Bag.CheckIn(artifact);
            if (index != -1)
            {
                this.Bag.Content[index].Cast(character, power);
                if (this.Bag.Content[index].IsUsed)
                {
                    this.Bag.Remove(this.Bag.Content[index]);
                }
            }
            else
            {
                throw new Exception("Нужного артефакта нет в инвентаре!");
            }
        }

        public void GiveArtifact(Artifact artifact, Character character)
        {
            int index = this.Bag.CheckIn(artifact);
            if (index != -1)
            {
                character.Bag.Add(this.Bag.Content[index]);
                this.Bag.Remove(this.Bag.Content[index]);
            }
            else
            {
                throw new Exception("Данного артефакта нет в инвентаре!");
            }
        }

        public string ShowInventory()
        {
            string info = "";
            for (int i = 0; i < Bag.Content.Count(); i++)
            {
                info = info + Bag.Content[i].ToString() + " ";
            }

            if (info == "")
            {
                return "Инвентарь пуст!";
            }

            return info;
        }

        public void Say(string str)
        {
            Console.WriteLine(this.Name + ": " + str);
        }
    }
}