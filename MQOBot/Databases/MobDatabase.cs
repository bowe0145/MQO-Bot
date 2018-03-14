using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQOBot.Databases
{
    class MobDatabase
    {
        public Dictionary<int, string> MobList;

        public MobDatabase()
        {
            MobList = new Dictionary<int, string>();
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            MobList.Add(2, "Worm");
            MobList.Add(4, "Goblin");
            MobList.Add(5, "Pink Core");
            MobList.Add(6, "Spider");
            MobList.Add(7, "Baby Dragon");
            MobList.Add(8, "Tiger");
            MobList.Add(9, "Evil Sage");
            MobList.Add(10, "Green Core");
            MobList.Add(11, "Skeleton Warrior");
            MobList.Add(12, "Goblin Warrior");
            MobList.Add(13, "Forest Dragon");
            MobList.Add(14, "Giant Worm");
            MobList.Add(15, "Evil Spider");
            MobList.Add(16, "Skeleton Mage");
            MobList.Add(17, "Verooja's Novice");
            MobList.Add(18, "Dark Acolyte");
            MobList.Add(19, "Mandragora");
            MobList.Add(20, "Iron Golem");
            MobList.Add(22, "Magma Dragon");
            MobList.Add(23, "Burning Ice Elemental");
            MobList.Add(41, "Naga");
            MobList.Add(44, "Water Snake");
        }

        public int FindMob(string name)
        {
            int MobID = 0;
            foreach (var mob in MobList)
            {
                if (name == mob.Value)
                {
                    MobID = mob.Key;
                }
            }
            return MobID;
        }

        public void SetComboItems(ComboBox box)
        {
            foreach (var skill in MobList)
            {
                box.Items.Add(skill.Value);
            }
        }
    }
}
