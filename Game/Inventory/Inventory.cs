using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Inventory
    {
        private List<Artifact> content;
        public List<Artifact> Content
        {
            get
            {
                return content;
            }

            private set
            {
                content = value;
            }
        }

        private int maxSize;
        public int MaxSize
        {
            get
            {
                return maxSize;
            }

            private set
            {
                maxSize = value;
            }
        }

        private int currentSize;
        public int CurrentSize
        {
            get
            {
                return currentSize;
            }

            private set
            {
                currentSize = value;
            }
        }

        public Inventory(int maxSize)
        {
            MaxSize = maxSize;
            CurrentSize = 0;
            Content = new List<Artifact>();
        }

        public bool CheckType(Artifact artifact)
        {
            bool isIn = false;
            for (int i = 0; i < Content.Count(); i++)
            {
                if (artifact.GetType() == Content[i].GetType())
                {
                    isIn = true;
                }
            }

            return isIn;
        }

        public int CheckIn(Artifact artifact)
        {
            int index = -1;
            for (int i = 0; i < Content.Count(); i++)
            {
                if (artifact == Content[i])
                {
                    index = i;
                }
            }

            return index;
        }

        public void Add(Artifact artifact)
        {
            if (artifact.IsUsed)
            {
                throw new Exception("Нельзя добавить использованный артефакт в инвентарь!");
            }

            if (this.CheckIn(artifact) != -1)
            {
                throw new Exception("У персонажа уже есть этот артефакт!");
            }

            if (!this.CheckType(artifact))
            {
                if (this.CurrentSize < this.MaxSize)
                {
                    Content.Add(artifact);
                    CurrentSize++;
                }
                else
                {
                    throw new Exception("Инвентарь переполнен!");
                }
            }
            else
            {
                Content.Add(artifact);
            }
        }

        public void Remove(Artifact artifact)
        {
            bool isSuccess = false;
            if (this.CheckIn(artifact) != -1)
            {
                Content.Remove(artifact);
                isSuccess = true;

                if (!this.CheckType(artifact))
                {
                    CurrentSize--;
                }
            }

            if (!isSuccess)
            {
                throw new Exception("Такого артефакта нет в инвентаре!");
            }
        }
    }
}
