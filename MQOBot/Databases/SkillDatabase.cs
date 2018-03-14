using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQOBot.Databases
{
    class SkillDatabase
    {
        public Dictionary<int, string> SkillList;

        public SkillDatabase()
        {
            SkillList = new Dictionary<int, string>();
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            SkillList.Add(1, "Scouting");
            SkillList.Add(2, "Selling");
            SkillList.Add(3, "Mining");
            SkillList.Add(4, "Gathering");
            SkillList.Add(5, "Logging");
            SkillList.Add(6, "Fishing");
        }

        public int FindSkill(string name)
        {
            int SkillID = 0;
            foreach (var skill in SkillList)
            {
                if (name == skill.Value)
                {
                    SkillID = skill.Key;
                }
            }
            return SkillID;
        }

        public void SetComboItems(ComboBox box)
        {
            foreach(var skill in SkillList)
            {
                box.Items.Add(skill.Value);
            }
        }
    }
}
