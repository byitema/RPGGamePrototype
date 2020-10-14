using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class HealthTransmitter: Artifact
    {
        public HealthTransmitter()
        {

        }

        public override void Cast(Character character = null, uint power = 0)
        {
            if (!IsUsed)
            {
                IsUsed = true;
            }
            else
            {
                throw new Exception("Артефакт уже использован!");
            }
        }
    }
}
