using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MQOBot.Webclients;
using MQOBot.Databases;
using MQOBot.Controllers;
using System.Text.RegularExpressions;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;
using MQOBot.Events;

//TODO: 
// Add chat colours
// Add chat notifications

namespace MQOBot
{
    public partial class Form1 : Form
    {
        private static Form1 instance;

        MobDatabase MobDB = new MobDatabase();
        SkillDatabase SkillDB = new SkillDatabase();

        public int SkillToDo = 0;
        public int MobToFight = 0;

        delegate void SetTextCallback(string text);

        public static Form1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Form1();
                }
                return instance;
            }
        }

        public Form1()
        {
            InitializeComponent();
            SkillDB.SetComboItems(comboSkill);
            MobDB.SetComboItems(comboFight);
            MQOEvents.onTestEvent += MQOEvents_onTestEvent;

            MQOEvents.onChatUpdate += MQOEvents_onChatUpdate;
            MQOEvents.onStatUpdate += MQOEvents_onStatUpdate;
        }

        // TODO: 
        // set hp label
        // set mana label
        // set ability 1 label
        // set ability 2 label
        // set elements
        // set chests
        // set relics
        // set stat points
        // set workload

        // set hp bar
        // set mana bar
        // set level bar
        // set ability 1 bar
        // set ability 2 bar

        // remove top line of chat (extra space)


        void MQOEvents_onStatUpdate(object obj)
        {
            /*  parsedStats += ParseStats("PlayerName") + ",";
                parsedStats += ParseStats("PlayerHP") + ",";
                parsedStats += ParseStats("PlayerMana") + ",";
                parsedStats += ParseStats("PlayerLevel") + ",";
                parsedStats += ParseStats("Gold") + ",";
                parsedStats += ParseStats("Elements") + ",";
                parsedStats += ParseStats("Chests") + ",";
                parsedStats += ParseStats("Relics") + ",";
                parsedStats += ParseStats("StatPoints") + ",";
                parsedStats += ParseStats("Workload") + ",";
                parsedStats += ParseStats("PlayerLevelPercent") + ",";
                parsedStats += ParseStats("Skill1Percent") + ",";
                parsedStats += ParseStats("Skill1") + ",";
                parsedStats += ParseStats("Skill2Percent") + ",";
                parsedStats += ParseStats("Skill2");
             * */
            string[] parsed = obj.ToString().Split(',');
            if (parsed.Length > 10)
            {
                SetPlayerName(parsed[0]);
                SetHPBar(parsed[1]);
                SetManaBar(parsed[2]);
                SetPlayerLevel(parsed[3]);
                SetGold(parsed[4]);
                SetElements(parsed[5]);
                SetChests(parsed[6]);
                SetRelics(parsed[7]);
                SetStatPoints(parsed[8]);
                SetWorkload(parsed[9]);
                SetLevelBar(parsed[10]);
                SetSkill1Bar(parsed[11]);
                SetSkill1Text(parsed[11] + "," + parsed[12]);
                SetSkill2Bar(parsed[13]);
                SetSkill2Text(parsed[13] + "," + parsed[14]);
            }
            else
            {
                //Log("Not over 6, Length: " + parsed.Length.ToString() + " parsed: " + parsed[0]);
            }
        }

        private void SetSkill2Text(string str)
        {
            if (this.lblSkill2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSkill2Text);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                string[] temp = str.Split(',');

                this.lblSkill2.Text = GetSkillValues(temp[0], temp[1]);
            }
        }

        private void SetSkill1Text(string str)
        {
            if (this.lblSkill1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSkill1Text);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                string[] temp = str.Split(',');

                this.lblSkill1.Text = GetSkillValues(temp[0], temp[1]);
            }
        }

        private void SetSkill2Bar(string str)
        {
            if (this.ProgressSkill2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSkill2Bar);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.ProgressSkill2.Value = RemoveDecimals(str);
            }
        }

        private void SetSkill1Bar(string str)
        {
            if (this.ProgressSkill1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetSkill1Bar);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.ProgressSkill1.Value = RemoveDecimals(str);
            }
        }

        private void SetLevelBar(string str)
        {
            if (this.ProgressLevel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLevelBar);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.ProgressLevel.Value = RemoveDecimals(str);
            }
        }

        private void SetManaBar(string str)
        {
            if (this.ProgressMana.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetManaBar);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.ProgressMana.Value = RemoveDecimals(str);
            }
        }

        private void SetHPBar(string str)
        {
            if (this.ProgressHP.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetHPBar);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.ProgressHP.Value = RemoveDecimals(str);
            }
        }

        private void SetPlayerHPText(string str)
        {
            if (this.lblHP.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetPlayerHPText);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblHP.Text = "HP: " + str.ToString();
            }
        }

        private void SetPlayerManaText(string str)
        {
            if (this.lblMana.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetPlayerManaText);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblMana.Text = "Mana: " + str.ToString();
            }
        }

        private void SetStatPoints(string str)
        {
            if (this.lblStatPoints.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatPoints);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblStatPoints.Text = "Stat Points: " + str.ToString();
            }
        }

        private void SetWorkload(string str)
        {
            if (this.lblWorkload.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetWorkload);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                if (str.ToString() == "")
                {
                    str = "0";
                }
                this.lblWorkload.Text = "Workload: " + str.ToString();
            }
        }

        private void SetRelics(string str)
        {
            if (this.lblRelics.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetRelics);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblRelics.Text = "Relics: " + str.ToString();
            }
        }

        private void SetChests(string str)
        {
            if (this.lblChests.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetChests);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblChests.Text = "Chests: " + str.ToString();
            }
        }

        private void SetElements(string str)
        {
            if (this.lblElements.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetElements);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblElements.Text = "Elements: " + str.ToString();
            }
        }

        private void SetPlayerLevel(string str)
        {
            if (this.lblLevel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetPlayerLevel);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblLevel.Text = "Level: " + str.ToString();
            }
        }

        private void SetPlayerName(string str)
        {
            if (this.lblPlayerName.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetPlayerName);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblPlayerName.Text = str;
            }
        }

        void SetGold(string str)
        {
            if (this.lblGold.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetGold);
                this.Invoke(d, new object[] { str.ToString() });
            }
            else
            {
                this.lblGold.Text = "Gold: " + str;
            }
        }

        void MQOEvents_onChatUpdate(object obj)
        {
            if (this.txtChat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(MQOEvents_onChatUpdate);
                this.Invoke(d, new object[] { obj.ToString() });
            }
            else
            {
                int index = obj.ToString().IndexOf(System.Environment.NewLine);
                string newText = obj.ToString().Substring(index + System.Environment.NewLine.Length);
                this.txtChat.Text = newText;
            }
            //instance.txtChat.Text = (string)obj.ToString();
        }

        void MQOEvents_onTestEvent(object obj)
        {
            Log((string)obj);
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        public static string getBetweenRegex(string strSource, string strStart, string strEnd)
        {
            string regexPattern = strStart + "(.*)" + strEnd;
            string MergedMatches = "";
            MatchCollection matches = Regex.Matches(strSource, regexPattern);

            foreach (Match match in matches)
            {
                MergedMatches += match.Value + ",";
            }

            if (matches.Count == 0)
            {
                MergedMatches = "No Matches";
            }

            return MergedMatches;
        }

        //private void UpdateStats()
        //{
        //    string DownloadString = "|";
        //    string[] Parsed = DownloadString.Split('|');
        //    lblPlayerName.Text = Parsed[4];
        //    ProgressHP.Value = RemoveDecimals(Parsed[12]);
        //    ProgressMana.Value = RemoveDecimals(Parsed[20]);
        //    ProgressLevel.Value = RemoveDecimals(Parsed[79]);
        //    lblLevel.Text = "Level: " + Parsed[8];
        //    ProgressSkill1.Value = RemoveDecimals(Parsed[80]);
        //    lblSkill1.Text = GetSkillValues(Parsed[80], Parsed[90]);
        //    ProgressSkill2.Value = RemoveDecimals(Parsed[81]);
        //    lblSkill2.Text = GetSkillValues(Parsed[81], Parsed[91]);
        //    lblGold.Text = "Gold: " + Parsed[82];
        //    lblElements.Text = "Elements: " + Parsed[89];
        //    lblChests.Text = "Chests: " + Parsed[116];
        //    lblRelics.Text = "Relics: " + Parsed[117];
        //    lblStatPoints.Text = "Stat Points: " + Parsed[88];
        //    lblWorkload.Text = "Workload: " + Parsed[115];
        //    // State
        //    if (Parsed[114] == "Working")
        //    {
        //        lblPlayerName.Text += " is Tradeskilling";
        //        lblWorkload.Text = "Workload: " + Parsed[115];
        //    }
        //    else if (Parsed[2].Length > 0)
        //    {
        //        if (Int32.Parse(Parsed[2]) > 0)
        //        {
        //            lblPlayerName.Text += " is Fighting";
        //        }
        //        lblWorkload.Text = "Workload: Fighting";
        //    }
        //    else
        //    {
        //        lblPlayerName.Text += " is Idle";
        //        lblWorkload.Text = "Workload: Not Working";
        //    }
        //}

        public string GetSkillValues(string SkillXP, string SkillName)
        {
            if (SkillXP == "")
            {
                return "";
            }
            else
            {
                string[] splitString = SkillXP.Split('%');
                string SkillNameString = SkillName;
                string SkillLevelString = "";
                if (splitString.Length > 2)
                {
                    SkillLevelString = splitString[1].Substring(1, splitString[1].Length - 1);
                }
                else if (splitString.Length > 1)
                {
                    SkillLevelString = splitString[1];
                }

                return SkillNameString + " " + SkillLevelString;
            }
        }

        public int RemoveDecimals(string removing)
        {
            string[] tempForTesting = removing.Split('%');
            if (tempForTesting[0].Length > 0)
            {
                tempForTesting[0].Remove(tempForTesting[0].Length - 1);
            }
            decimal value;
            if (Decimal.TryParse(tempForTesting[0], out value))
            {
                string[] temp = tempForTesting[0].Split('.');
                temp[0].Replace(" ", "");
                return Int32.Parse(temp[0]);
            }
            else
            {
                return 0;
            }
        }

        public void Log(string Message)
        {
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Log);
                this.Invoke(d, new object[] { Message.ToString() });
            }
            else
            {
                txtLog.AppendText(Message + "\r\n");
            }
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.Name == "comboSkill")
            {
                string SkillName = cb.Text;

                SkillToDo = SkillDB.FindSkill(SkillName);

                if (SkillToDo == 0)
                {
                    btnStartSkill.Enabled = false;
                }
                else
                {
                    btnStartSkill.Enabled = true;
                }
            }
            else
            {
                string MobName = cb.Text;

                MobToFight = MobDB.FindMob(MobName);

                if (MobToFight == 0)
                {
                    btnStartFight.Enabled = false;
                }
                else
                {
                    btnStartFight.Enabled = true;
                }
            }
        }

        private void btnSendChat_Click(object sender, EventArgs e)
        {
            string tempString = txtChatToSend.Text;
            MQOEvents.SendMessage(tempString);
            txtChatToSend.Text = "";
        }

        private void btnStartSkill_Click(object sender, EventArgs e)
        {
            MQOEvents.StartWork(SkillToDo);
        }

        private void btnStopSkill_Click(object sender, EventArgs e)
        {
            MQOEvents.StopWork(true);

        }

        private void btnStartFight_Click(object sender, EventArgs e)
        {
            MQOEvents.Fight(MobToFight);
        }

        private void btnStopFight_Click(object sender, EventArgs e)
        {
            MQOEvents.StopFight(true);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MQOEvents.OpenLogin(true);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MQOEvents.Disconnected(true);

            Log("Disconnected");
        }
    }
}
// id = User
// id = Pass
// id = btnConnect1420

//CharId = 1194
//Content Type: application/x-www-form-urlencoded