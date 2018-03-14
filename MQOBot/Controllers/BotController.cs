using System.Threading.Tasks;
using MQOBot.Webclients;
using MQOBot.Databases;
using System;
using System.ComponentModel;
using MQOBot.Events;
using System.Text.RegularExpressions;
using System.Threading;

namespace MQOBot.Controllers
{
    class BotController
    {
        private static BotController instance;

        public bool isConnected = false;

        MobDatabase MobDB = new MobDatabase();
        SkillDatabase SkillDB = new SkillDatabase();

        string CharacterShort = "";
        public bool StatsNeedsUpdate = false;
        string Chat = "";
        public bool ChatNeedsUpdate = false;

        public int SkillToDo = 0;
        public int MobToFight = 0;

        public bool BottingFighting = false;
        public bool BottingSkilling = false;

        public bool isFightReady = false;
        public bool isMainReady = false;
        public bool isSkillsReady = false;

        public bool StatsActive = false;

        Random rand = new Random();

        public System.Threading.Timer _timer; // Main Bot Timer

        public static BotController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BotController();
                }
                return instance;
            }
        }

        public BotController()
        {
            MQOEvents.onFightReady += MQOEvents_onFightReady;
            MQOEvents.onWorkReady += MQOEvents_onWorkReady;
            MQOEvents.onMainReady += MQOEvents_onMainReady;
            MQOEvents.onChatReady += MQOEvents_onChatReady;
            MQOEvents.onStatReady += MQOEvents_onStatReady;
            MQOEvents.onConnected += MQOEvents_onConnected;
            MQOEvents.onDisconnected += MQOEvents_onDisconnected;

            MQOEvents.onStartWork += MQOEvents_onStartWork;
            MQOEvents.onStopWork += MQOEvents_onStopWork;
            MQOEvents.onFight += MQOEvents_onFight;
            MQOEvents.onStopFight += MQOEvents_onStopFight;

            Start();
        }

        void MQOEvents_onStopFight(object obj)
        {
            BottingFighting = false;
        }

        void MQOEvents_onFight(object obj)
        {
            BottingFighting = true;
            MobToFight = (int)obj;
        }

        void MQOEvents_onStopWork(object obj)
        {
            BottingSkilling = false;
        }

        void MQOEvents_onStartWork(object obj)
        {
            SkillToDo = (int)obj;

            BottingSkilling = true;
        }

        void MQOEvents_onDisconnected(object obj)
        {
            isConnected = false;
        }

        public void Start()
        {
            _timer = new System.Threading.Timer(Callback, null, 1000, Timeout.Infinite);
        }

        private void Callback(Object state)
        {
            //MQOEvents.TestEvent("Callback in bot");
            if (isConnected)
            {
                UpdateStats();
                UpdateChat();
                Think();
            }
            _timer.Change(1000, Timeout.Infinite);
        }

        void MQOEvents_onConnected(object obj)
        {
            MQOEvents.TestEvent("Connected");
            isConnected = true;
        }

        void MQOEvents_onMainReady(object obj)
        {
            isMainReady = (bool)obj;
        }

        void MQOEvents_onWorkReady(object obj)
        {
            isSkillsReady = (bool)obj;
        }

        private void Think()
        {
            // should have a parsing function

            if (HasChest())
            {
                OpenChests();
            }

            if (BottingFighting)
            {
                if (BottingSkilling)
                {
                    BottingSkilling = false;
                }

                if (isWorking())
                {
                    StopWork();
                }
                else
                {
                    //loadfight
                    Fight();
                }
            }

            if (BottingSkilling)
            {
                if (BottingFighting)
                {
                    BottingFighting = false;
                }

                if (GetEnemyCount() > 0)
                {
                    Attack();
                }
                else if (!isWorking())
                {
                    DoWork();
                }
            }

            if (!BottingFighting && !BottingSkilling)
            {
                if (GetEnemyCount() > 0)
                {
                    Attack();
                }
            }
        }

        private bool HasChest()
        {
            if ((int)ParseStats("Chests") > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateChat()
        {
            if (isConnected)
            {
                MQOEvents.RequestChatUpdate(true);
            }
        }

        private void UpdateStats()
        {
            if (isConnected)
            {
                MQOEvents.RequestStatUpdate(true);
            }
        }

        private void OpenChests()
        {
            MQOEvents.OpenChest(true);
        }

        private void StopWork()
        {
            MQOEvents.StopWork(true);
        }

        private void DoWork()
        {
            MQOEvents.DoWork(SkillToDo);
        }

        public void Fight()
        {
            if (GetEnemyCount() == 0)
            {
                MQOEvents.LoadFight(MobToFight);
            }
            else
            {
                Attack();
            }
        }

        private void Attack()
        {
            int derp = Int32.Parse(ParseStats("Enemy1HP").ToString());
            int derp2 = Int32.Parse(ParseStats("Enemy2HP").ToString());

            if (Int32.Parse(ParseStats("Enemy1HP").ToString()) > 0)
            {
                MQOEvents.Attack(0);
            }
            else
            {
                MQOEvents.Attack(1);
            }
        }

        public int GetEnemyCount()
        {
            if (StatsActive)
            {
                if (Int32.Parse(ParseStats("Enemy1").ToString()) == 1)
                {
                    if (Int32.Parse(ParseStats("Enemy2").ToString()) == 1)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public bool isWorking()
        {
            if (StatsActive)
            {
                if ((string)ParseStats("State") == "Working")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private double GetSID()
        {
            return rand.NextDouble();
        }

        void MQOEvents_onStatReady(object obj)
        {
            CharacterShort = (string)obj;
            if (StatsActive && isConnected)
            {
                string parsedStats = "";
                parsedStats += ParseStats("PlayerName") + ",";
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
                MQOEvents.StatUpdate(parsedStats);
            }
            //}
        }

        void MQOEvents_onChatReady(object obj)
        {
            if (Chat != (string)obj.ToString())
            {
                string Uncleaned = (string)obj.ToString();
                string Cleaned = Regex.Replace(Uncleaned, @"<[^>]*>", String.Empty);
                Cleaned = Regex.Replace(Cleaned, @"[[^>[]", "\r\n[");

                Chat = Cleaned;
                MQOEvents.ChatUpdate(Chat);
            }
        }

        public object ParseStats(string str)
        {
            if (isConnected)
            {
                string unparsed = CharacterShort;
                string[] parsed = unparsed.Split('|');

                if (parsed.Length > 5)
                {
                    StatsActive = true;
                    if (parsed[0] != "1")
                    {
                        isConnected = false;
                    }

                    if (str == "PlayerName")
                    {
                        return parsed[4];
                    }
                    else if (str == "PlayerHP")
                    {
                        return parsed[12];
                    }
                    else if (str == "PlayerMana")
                    {
                        return parsed[20];
                    }
                    else if (str == "PlayerLevel")
                    {
                        return parsed[8];
                    }
                    else if (str == "PlayerLevelPercent")
                    {
                        return parsed[79];
                    }
                    else if (str == "Gold")
                    {
                        return parsed[82];
                    }
                    else if (str == "Elements")
                    {
                        return parsed[89];
                    }
                    else if (str == "Chests")
                    {
                        int number;
                        bool result = Int32.TryParse(parsed[116].ToString(), out number);
                        if (result)
                        {
                            return number;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else if (str == "Relics")
                    {
                        return parsed[117];
                    }
                    else if (str == "Chests")
                    {
                        return parsed[116];
                    }
                    else if (str == "StatPoints")
                    {
                        return parsed[88];
                    }
                    else if (str == "Workload")
                    {
                        if (parsed[115] == "")
                        {
                            return 0;
                        }
                        else
                        {
                            return parsed[115];
                        }
                    }
                    else if (str == "Enemy1HP")
                    {
                        if (parsed[18] != "")
                        {
                            return parsed[18];
                        }
                        return 0;
                    }
                    else if (str == "Enemy2HP")
                    {
                        if (parsed[19] != "")
                        {
                            return parsed[19];
                        }
                        return 0;
                    }
                    else if (str == "Enemy1")
                    {
                        if (parsed[2] != "")
                        {
                            return parsed[2];
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else if (str == "Enemy2")
                    {
                        if (parsed[3] != "")
                        {
                            return parsed[3];
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else if (str == "State")
                    {
                        if (parsed[114] == "Working")
                        {
                            return "Working";
                        }
                        else
                        {
                            return "Idle";
                        }
                    }
                    else if (str == "Skill1Percent")
                    {
                        return parsed[80];
                    }
                    else if (str == "Skill1")
                    {
                        return parsed[90];
                    }
                    else if (str == "Skill2Percent")
                    {
                        return parsed[81];
                    }
                    else if (str == "Skill2")
                    {
                        return parsed[91];
                    }
                    else
                    {
                        MQOEvents.TestEvent("(Parse Stat)Command not found: " + str);
                        return 0;
                    }
                }
                else
                {
                    StatsActive = false;
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        void MQOEvents_onFightReady(object obj)
        {
            isFightReady = (bool)obj;
        }
    }
}