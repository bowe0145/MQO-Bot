using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQOBot.Events;
using System.Text.RegularExpressions;

// TODO: Handle 1 or 2 characters instead of only 3

namespace MQOBot.Views
{
    public partial class CharacterSelectionForm : Form
    {
        string ResultString = "";

        string ParsedSite = "";
        string SuperParsedSite = "";

        int[] PlayerIDs = new int[3];
        int CharacterNumber = 0;

        public CharacterSelectionForm(string result)
        {
            InitializeComponent();
            ResultString = result;
            ParseSite();
            MQOEvents.TestEvent("Select a Character");
        }

        public void ParseSite()
        {
            //TODO: Get rid of tags and then find each thing like when we get the character ids
            // with the getBetween Regex and the way the chat is parsed

            RemoveHTML();
            //getCharacterAmount
            getAccountIDs();
            getAccountLevels();
            getAccountGold();
            getAccountElements();
            getAccountNames();
        }

        private void getAccountElements()
        {
            string test = AnotherGetBetween(SuperParsedSite, "Elements", "Location");
            string[] Elements = test.Split(',');

            if (CharacterNumber > 0)
            {
                lblElements1.Text = "Elements: " + Elements[0];
            }

            if (CharacterNumber > 1)
            {
                lblElements2.Text = "Elements: " + Elements[1];
            }

            if (CharacterNumber > 2)
            {
                lblElements3.Text = "Elements: " + Elements[2];
            }
        }

        private void getAccountGold()
        {
            string test = AnotherGetBetween(SuperParsedSite, "Gold", "Magic");
            string[] Gold = test.Split(',');

            if (CharacterNumber > 0)
            {
                lblGold1.Text = "Gold: " + Gold[0];
            }

            if (CharacterNumber > 1)
            {
                lblGold2.Text = "Gold: " + Gold[1];
            }

            if (CharacterNumber > 2)
            {
                lblGold3.Text = "Gold: " + Gold[2];
            }
        }

        private void getAccountLevels()
        {
            string Test2 = AnotherGetBetween(SuperParsedSite, "Level", "Gold");
            string[] Names = Test2.Split(',');

            if (CharacterNumber > 0)
            {
                lblLevel1.Text = Names[0];
                btnPlay1.Enabled = true;
            }

            if (CharacterNumber > 1)
            {
                lblLevel2.Text = Names[1];
                btnPlay2.Enabled = true;
            }

            if (CharacterNumber > 2)
            {
                lblLevel3.Text = Names[2];
                btnPlay3.Enabled = true;
            }
        }

        public void getAccountIDs()
        {
            string regexBetween = getBetweenRegex(ParsedSite, "CharSelect", ".submit");
            string[] CleanedRegex = regexBetween.Split(',');

            string[] Account = new string[3];

            for (int i = 0; i < CleanedRegex.Count() - 1; i++)
            {
                Account[i] = CleanedRegex[i].Remove(CleanedRegex[i].Length - 7).Remove(0, 10);
            }

            // Parse stuff
            int num = 0;

            if (Account[0] != null)
            {
                CharacterNumber = 1;
                PlayerIDs[0] = Int32.Parse(Account[0]);
            }

            if (Account[1] != null)
            {
                CharacterNumber = 2;
                PlayerIDs[1] = Int32.Parse(Account[1]);
            }

            if (Account[2] != null)
            {
                CharacterNumber = 3;
                PlayerIDs[2] = Int32.Parse(Account[2]);
            }
        }
        
        public void getAccountNames()
        {
            string UserName1 = "No Character";
            string UserName2 = "No Character";
            string UserName3 = "No Character";

            if (CharacterNumber > 0)
            {
                string Char1Name = getBetween(SuperParsedSite, "Characters", "Level");
                UserName1 = Char1Name;
            }

            string regexsuperclean = GetAccountNameRegex(SuperParsedSite, "submit", "Level");

            if (CharacterNumber > 1)
            {
                string[] name2Cleaned = regexsuperclean.Split(',');
                string name2 = name2Cleaned[0].Remove(name2Cleaned[0].Length - 6);
                string[] name2Done = name2Cleaned[0].Split(' ');
                UserName2 = name2Done[3];
            }

            if (CharacterNumber > 2)
            {
                string[] name3Cleaned = regexsuperclean.Split(',');
                string name3 = name3Cleaned[1].Remove(name3Cleaned[1].Length - 6);
                string[] name3Done = name3.Split(' ');
                UserName3 = name3Done[3];

            }

            lblPlayerName1.Text = UserName1;
            lblPlayerName2.Text = UserName2;
            lblPlayerName3.Text = UserName3;

            //lblPlayerName1.Text = CleanedRegex[0];

            // First name, use getBetween
            // Other  use the other 1
        }

        public void RemoveHTML()
        {
            string SuperCleanedStart = Regex.Replace(ResultString, @"<[^>]+>|&nbsp;", "").Trim();
            SuperCleanedStart = Regex.Replace(SuperCleanedStart, @"\s{2,}", " ");

            string SuperCleaned = Regex.Replace(SuperCleanedStart, "[^a-zA-Z0-9 -]", "");
            SuperCleaned = Regex.Replace(SuperCleaned, @"\s{2,}", " ");

            string Cleaned = Regex.Replace(ResultString, @"<[&>]*>", String.Empty);
            Cleaned = Regex.Replace(Cleaned, @"[[^>[]", "\r\n");
            SuperParsedSite = SuperCleaned;
            ParsedSite = Cleaned;

            txtDebug.Text = ParsedSite;
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

        public static string AnotherGetBetween(string strSource, string strStart, string strEnd)
        {
            // Unused
            //Cleaned, @"});", "Level");
            string regexPattern = "(?<=" + strStart + ")" + ".*?" + "(?=" + strEnd + ")";
            string MergedMatches = "";
            MatchCollection matches = Regex.Matches(strSource, regexPattern);

            foreach (Match match in matches)
            {
                //string tempForMatch = match.Value.ToString().Remove(0, 11).Remove(match.Length - 6, match.Length);
                MergedMatches += match.Value + ",";
            }

            if (matches.Count == 0)
            {
                MergedMatches = "No Matches";
            }

            return MergedMatches;
        }

        public static string GetAccountNameRegex(string strSource, string strStart, string strEnd)
        {
            string regexPattern = strStart + "(.*?)" + strEnd;
            string MergedMatches = "";
            MatchCollection matches = Regex.Matches(strSource, regexPattern);

            foreach (Match match in matches)
            {
                //string tempForMatch = match.Value.ToString().Remove(0, 11).Remove(match.Length - 6, match.Length);
                MergedMatches += match.Value + ",";
            }

            if (matches.Count == 0)
            {
                MergedMatches = "No Matches";
            }

            return MergedMatches;
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

        private void btnPlay1_Click(object sender, EventArgs e)
        {
            MQOEvents.TestEvent("Logging into: " + lblPlayerName1.Text);
            MQOEvents.RequestCharacterLogin(PlayerIDs[0]);
        }

        private void btnPlay2_Click(object sender, EventArgs e)
        {
            MQOEvents.TestEvent("Logging into: " + lblPlayerName2.Text + " Character ID: " + PlayerIDs[1]);
            MQOEvents.RequestCharacterLogin(PlayerIDs[1]);
        }

        private void btnPlay3_Click(object sender, EventArgs e)
        {
            MQOEvents.TestEvent("Logging into: " + lblPlayerName3.Text);
            MQOEvents.RequestCharacterLogin(PlayerIDs[2]);
        }
    }
}
