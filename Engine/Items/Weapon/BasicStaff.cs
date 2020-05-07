using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.Weapon
{
    [Serializable]
    class BasicStaff : Staff
    {
        // simple staff
        public BasicStaff() : base("item0001") 
        {
            MgcMod = 10;
            GoldValue = 10;
            PublicName = "Basic Staff";
        }
    }
}
