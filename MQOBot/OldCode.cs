using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQOBot
{
    class OldCode
    {
        private void GetPage(string url, string[] param, bool sid = true)
        {
            //Uri derp = new Uri(url);

            //WebRequest temp1 = WebRequest.Create("derp");
            //temp1.Method = "GET";

            //txtLog.Text = MainWebClient.CookieContainer.GetCookieHeader(derp);

            //string fullURL = "";
            //fullURL = url + "?";
            //string ParamString = "";
            //for (int i = 0; i < param.Length; i++)
            //{
            //    string[] tempSpliting = param[i].Split('=');
            //    //string tempEncoded = Uri.EscapeDataString(tempSpliting[1]);
            //    string tempEncoded = tempSpliting[1];
            //    ParamString += tempSpliting[0] + "=" + tempEncoded;
            //    if (i < param.Length - 1)
            //    {
            //        ParamString += "&";
            //    }
            //}
            //if (sid == true) //hds3f143
            //{
            //    ParamString += "&sid=" + GetSID().ToString();
            //}

            //Log(MainWebClient.UploadString(fullURL, ParamString));
            //Log("Message Sent: " + fullURL.ToString());
            //Log(fullURL.ToString());
            //Log(MainWebClient.Headers.ToString());
            //UpdateChat();

//            using System;
//using System.IO;
//using System.Net;
//using System.Windows.Forms;
//using MQOBot.Webclients;
//using MQOBot.Databases;
//using MQOBot.Controllers;
//using System.Text.RegularExpressions;
//using System.Text;
//using System.Runtime.InteropServices;
//using System.Drawing;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using System.Threading;

////TODO: 
//// Add Login form so you can pick your character
//// Add connected check
//// Add chat colours
//// Add chat notifications

////Client
//// with cookies
//// update function
//// respective DB
////  

//namespace MQOBot
//{
//    public partial class Form1 : Form
//    {
//        WebClientEx MainWebClient = new WebClientEx();
//        WebClientEx ChatWebClient = new WebClientEx();
//        WebClientEx StatsWebClient = new WebClientEx();
//        WebClientEx FightWebClient = new WebClientEx();
//        WebClientEx SkillWebClient = new WebClientEx();

//        System.Threading.Timer _timer;

//        Random rand = new Random();

//        MobDatabase MobDB = new MobDatabase();
//        SkillDatabase SkillDB = new SkillDatabase();

//        string CharacterShort = "";
//        public bool StatsNeedsUpdate = false;
//        string Chat = "";
//        public bool ChatNeedsUpdate = false;
//        public int isitworking = 9;

//        public int SkillToDo = 0;
//        public int MobToFight = 0;

//        public bool BottingFighting = false;
//        public bool BottingSkilling = false;

//        public bool isConnected = false;

//        public Form1()
//        {
//            InitializeComponent();
//            SkillDB.SetComboItems(comboSkill);
//            MobDB.SetComboItems(comboFight);
//        }

//        private void Think()
//        {
//            string[] Parsed = CharacterShort.Split('|');

//            if (Int32.Parse(Parsed[116]) > 0)
//            {
//                OpenChests();
//            }
            
//            if (BottingFighting)
//            {
//                if (BottingSkilling)
//                {
//                    BottingSkilling = false;
//                }

//                if (Parsed[114] == "Working")
//                {
//                    StopWork();
//                }
//                else
//                {
//                    Fight();
//                }
//            }

//            if (BottingSkilling)
//            {
//                if (GetEnemyCount() > 0)
//                {
//                    Attack();
//                }
//                else
//                {
//                    DoWork();
//                }
//            }

//            if (!BottingFighting && !BottingSkilling)
//            {
//                if (Parsed[114] == "Working")
//                {
//                    StopWork();
//                }
                
//                if (GetEnemyCount() > 0)
//                {
//                    Attack();
//                }
//            }
//        }

//        private void DoWork()
//        {
//            string[] Parsed = CharacterShort.Split('|');

//            if (Parsed[114] != "Working")
//            {
//                StartWork(SkillToDo);
//            }
//        }

//        private void Fight()
//        {
//            if (GetEnemyCount() == 0)
//            {
//                LoadFight(MobToFight);
//            }
//            else
//            {
//                Attack();
//            }
//        }

//        private void Attack()
//        {
//            string[] Parsed = CharacterShort.Split('|');

//            if (Int32.Parse(Parsed[18]) > 0)
//            {
//                LoadPage("http://midenquest.com/useSkill.aspx?id=1&ta=0");
//            }
//            else
//            {
//                LoadPage("http://midenquest.com/useSkill.aspx?id=1&ta=1");
//            }
//        }

//        private int GetEnemyCount()
//        {
//            string[] Parsed = CharacterShort.Split('|');

//            if (Int32.Parse(Parsed[2]) == 1)
//            {
//                if (Int32.Parse(Parsed[3]) == 1)
//                {
//                    return 2;
//                }
//                else
//                {
//                    return 1;
//                }
//            }
//            else
//            {
//                return 0;
//            }
//        }

//        private void OpenChests()
//        {
//            LoadPage("http://midenquest.com/getCharacterSheet.aspx?open=1");
//        }

//        private void Callback(Object state)
//        {
//            //UpdateStats();
//            //UpdateChat();
//            if (MainWebClient.CookieContainer.Count > 0)
//            {
//                ChatWebClient.CookieContainer = MainWebClient.CookieContainer;
//                StatsWebClient.CookieContainer = MainWebClient.CookieContainer;
//                FightWebClient.CookieContainer = MainWebClient.CookieContainer;
//                StatsWebClient.CookieContainer = MainWebClient.CookieContainer;

//                UpdateCharacterShortString();
//                UpdateChatString();
//                Think();
//            }
//            _timer.Change(1000, Timeout.Infinite);
//        }

//        public void Start()
//        {
//            if (MainWebClient.CookieContainer.Count > 0)
//            {
//                ChatWebClient.CookieContainer = MainWebClient.CookieContainer;
//                StatsWebClient.CookieContainer = MainWebClient.CookieContainer;

//                UpdateCharacterShortString();
//                UpdateChatString();
//            }
//            timer1.Start();
//            //await PutTaskDelay(2500);
//            _timer = new System.Threading.Timer(Callback, null, 1000, Timeout.Infinite);
//        }


//        private void Login()
//        {   
//            // Post to UserLogin.aspx
//            // Move to /UserCharacterSelection.aspx
//            // Get /UserCharacterSelection.aspx
//            // Post to /Game.aspx
//            string username = txtUserName.Text;
//            string password = txtPassword.Text;

//            string URI = "http://midenquest.com/UserLogin.aspx";
//            string Params = "User=" + username + "&Pass=" + password;
//            LoadPage(URI);
//            //PostPage(URI, Params);
//            //Log(MainWebClient.ResponseHeaders.ToString());
//            // Enter Character
//            URI = "http://midenquest.com/Game.aspx";
//            Params = "CharId=1194";
//            //1420
//            //1194
//            //LoadPage("http://midenquest.com/UserCharacterSelection.aspx");
//            //ParseCharacterScreen(MainWebClient.DownloadString("http://midenquest.com/UserCharacterSelection.aspx"));
//            //PostPage(URI, Params);

//            Log("Connected");
//            //Start();
//        }

//        public static string getBetween(string strSource, string strStart, string strEnd)
//        {
//            int Start, End;
//            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
//            {
//                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
//                End = strSource.IndexOf(strEnd, Start);
//                return strSource.Substring(Start, End - Start);
//            }
//            else
//            {
//                return "";
//            }
//        }

//        public static string getBetweenRegex(string strSource, string strStart, string strEnd)
//        {
//            string regexPattern = strStart + "(.*)" + strEnd;
//            string MergedMatches = "";
//            MatchCollection matches = Regex.Matches(strSource, regexPattern);
            
//            foreach (Match match in matches)
//            {
//                MergedMatches += match.Value + ",";
//            }

//            if (matches.Count == 0)
//            {
//                MergedMatches = "No Matches";
//            }

//            return MergedMatches;
//        }

//        private void UpdateCharacterShortString()
//        {
//            if (!StatsWebClient.IsBusy)
//            {
//                string tempStats = StatsWebClient.DownloadString("http://midenquest.com/getCharactersShort.aspx?null=&sid=" + GetSID().ToString());
//                if (tempStats == CharacterShort)
//                {
//                    this.StatsNeedsUpdate = false;
//                }
//                else
//                {
//                    this.StatsNeedsUpdate = true;
//                    this.CharacterShort = tempStats;
//                }
//            }
//        }

//        private void UpdateChatString()
//        {
//            if (!ChatWebClient.IsBusy)
//            {
//                string tempChat = ChatWebClient.DownloadString("http://midenquest.com/getChatLog.aspx");
//                if (tempChat == Chat)
//                {
//                    this.ChatNeedsUpdate = false;
//                }
//                else
//                {
//                    this.ChatNeedsUpdate = true;
//                    this.Chat = tempChat;
//                }
//            }
//        }

//        private void UpdateStats()
//        {
//            string DownloadString = this.CharacterShort;
//            string[] Parsed = DownloadString.Split('|');
//            lblPlayerName.Text = Parsed[4];
//            ProgressHP.Value = RemoveDecimals(Parsed[12]);
//            ProgressMana.Value = RemoveDecimals(Parsed[20]);
//            ProgressLevel.Value = RemoveDecimals(Parsed[79]);
//            lblLevel.Text = "Level: " + Parsed[8];
//            ProgressSkill1.Value = RemoveDecimals(Parsed[80]);
//            lblSkill1.Text = GetSkillValues(Parsed[80], Parsed[90]);
//            ProgressSkill2.Value = RemoveDecimals(Parsed[81]);
//            lblSkill2.Text = GetSkillValues(Parsed[81], Parsed[91]);
//            lblGold.Text = "Gold: " + Parsed[82];
//            lblElements.Text = "Elements: " + Parsed[89];
//            lblChests.Text = "Chests: " + Parsed[116];
//            lblRelics.Text = "Relics: " + Parsed[117];
//            lblStatPoints.Text = "Stat Points: " + Parsed[88];
//            lblWorkload.Text = "Workload: " + Parsed[115];
//            // State
//            if (Parsed[114] == "Working")
//            {
//                lblPlayerName.Text += " is Tradeskilling";
//                lblWorkload.Text = "Workload: " + Parsed[115];
//            }
//            else if (Parsed[2].Length > 0)
//            {
//                if (Int32.Parse(Parsed[2]) > 0)
//                {
//                    lblPlayerName.Text += " is Fighting";
//                }
//                lblWorkload.Text = "Workload: Fighting";
//            }
//            else
//            {
//                lblPlayerName.Text += " is Idle";
//                lblWorkload.Text = "Workload: Not Working";
//            }
//        }

//        private void ParseCharacterScreen(string str)
//        {
//            string Uncleaned = str;
//            string Cleaned = Regex.Replace(Uncleaned, @"<[^>]*>", String.Empty);
//            Cleaned = Regex.Replace(Cleaned, @"[[^>[]", "\r\n[");
//            string regexbetween = getBetweenRegex(Cleaned, "CharSelect", ".submit");
//            string[] CleanedRegex = regexbetween.Split(',');

//            string Char1 = CleanedRegex[0].Remove(CleanedRegex[0].Length - 7).Remove(0, 10);
//            string Char2 = CleanedRegex[1].Remove(CleanedRegex[1].Length - 7).Remove(0, 10);
            
//            string gotbetween = getBetween(Cleaned, "CharSelect", ".submit();");
//            //gotbetween = the first one
//            Log(Char1 + " , " + Char2);
//        }

//        private void UpdateChat()
//        {
//            string Uncleaned = this.Chat;
//            string Cleaned = Regex.Replace(Uncleaned, @"<[^>]*>", String.Empty);
//            Cleaned = Regex.Replace(Cleaned, @"[[^>[]", "\r\n[");

//            txtChat.Text = Cleaned.Substring(2, Cleaned.Length - 2);
//        }

//        public string GetSkillValues(string SkillXP, string SkillName)
//        {
//            if (SkillXP == "")
//            {
//                return "";
//            }
//            else
//            {
//                string[] splitString = SkillXP.Split('%');
//                string SkillNameString = SkillName;
//                string SkillLevelString = splitString[1].Substring(1, splitString[1].Length - 1);
//                return SkillNameString + " " + SkillLevelString;
//            }
//        }

//        public int RemoveDecimals(string removing)
//        {
//            string[] tempForTesting = removing.Split('%');
//            if (tempForTesting[0].Length > 0)
//            {
//                tempForTesting[0].Remove(tempForTesting[0].Length - 1);
//            }
//            decimal value;
//            if (Decimal.TryParse(tempForTesting[0], out value))
//            {
//                string[] temp = tempForTesting[0].Split('.');
//                temp[0].Replace(" ", "");
//                return Int32.Parse(temp[0]);
//            }
//            else
//            {
//                return 0;
//            }
//        }

//        private void LoadFight(int MobID)
//        {
//            if (!FightWebClient.IsBusy)
//            {
//                FightWebClient.DownloadString("http://midenquest.com/loadFight.aspx?id=" + MobID.ToString());
//            }
//        }
        
//        private void StartWork(int WorkID)
//        {
//            if (!SkillWebClient.IsBusy)
//            {
//                SkillWebClient.DownloadString("http://midenquest.com/useWork.aspx?start=" + WorkID + "&null=");
//            }
//        }

//        private void StopWork()
//        {
//            if (!SkillWebClient.IsBusy)
//            {
//                SkillWebClient.DownloadString("http://midenquest.com/useWork.aspx?stop=4&null=&sid=" + GetSID());
//            }
//        }

//        private void LoadPage(string url)
//        {
//            if (!MainWebClient.IsBusy)
//            {
//                MainWebClient.DownloadString(url);
//            }
//        }

//        private void PostPage(string url, string param)
//        {
//            if (!MainWebClient.IsBusy)
//            {
//                MainWebClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
//                MainWebClient.UploadString(url, param);
//            }
//        }

//        private double GetSID()
//        {
//            return rand.NextDouble();
//        }

//        public void Log(string Message)
//        {
//            txtLog.AppendText(Message + "\r\n");
//        }

//        public void SetHeaders()
//        {
//            MainWebClient.Headers.Add("Host", "www.midenquest.com");
//            MainWebClient.Headers.Add("Content-Type", "text/html");
//            //MainWebClient.Headers.Add("X-Requested-By", "XHR");
//            //MainWebClient.Headers.Add("X-Request-Id", "0");
//            MainWebClient.BaseAddress = "http://www.midenquest.com/Game.aspx";
//            MainWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.90 Safari/537.36");
//            MainWebClient.Headers.Add("Referer", "http://www.midenquest.com/Game.aspx");
//            MainWebClient.Headers.Add("Accept", "*/*");
//            MainWebClient.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
//            MainWebClient.Headers.Add("Accept-Language", "en-GB, en-US;q=0.8,en;q=0.6");
//        }

//        private void SelectedIndexChanged(object sender, EventArgs e)
//        {
//            ComboBox cb = (ComboBox)sender;

//            if (cb.Name == "comboSkill")
//            {
//                string SkillName = cb.Text;

//                SkillToDo = SkillDB.FindSkill(SkillName);

//                if (SkillToDo == 0)
//                {
//                    btnStartSkill.Enabled = false;
//                }
//                else
//                {
//                    btnStartSkill.Enabled = true;
//                }
//            }
//            else
//            {
//                string MobName = cb.Text;

//                MobToFight = MobDB.FindMob(MobName);

//                if (MobToFight == 0)
//                {
//                    btnStartFight.Enabled = false;
//                }
//                else
//                {
//                    btnStartFight.Enabled = true;
//                }
//            }
//        }

//        private void btnSendChat_Click(object sender, EventArgs e)
//        {
//            if (!ChatWebClient.IsBusy)
//            {
//                string tempString = txtChatToSend.Text;
//                string tempderp = MainWebClient.DownloadString("http://midenquest.com/sendMessage.aspx?ch=1&Message=" + tempString + "&sid=" + GetSID().ToString()).ToString();
//                txtChatToSend.Text = "";
//            }
//        }

//        private void btnStartSkill_Click(object sender, EventArgs e)
//        {
//            BottingSkilling = true;
//        }

//        private void btnStopSkill_Click(object sender, EventArgs e)
//        {
//            BottingSkilling = false;

//        }

//        private void btnStartFight_Click(object sender, EventArgs e)
//        {
//            BottingFighting = true;
//        }

//        private void btnStopFight_Click(object sender, EventArgs e)
//        {
//            BottingFighting = false;
//        }

//        private void btnLogin_Click(object sender, EventArgs e)
//        {
//            SetHeaders();
//            Login();
//        }

//        private void btnLogout_Click(object sender, EventArgs e)
//        {
//            string Uri = "http://midenquest.com/UserLogin.aspx";
//            LoadPage(Uri);

//            Log("Disconnected");
//        }

//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            if (this.ChatNeedsUpdate)
//            {
//                UpdateChat();
//            }

//            if (this.StatsNeedsUpdate)
//            {
//                UpdateStats();
//            }
//        }
//    }
//}
//// id = User
//// id = Pass
//// id = btnConnect1420

////CharId = 1194
////Content Type: application/x-www-form-urlencoded
        }
    }
}
