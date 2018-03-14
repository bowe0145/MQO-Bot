using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQOBot.Webclients;
using MQOBot.Controllers;
using MQOBot.Events;
using System.Net;
using System.Collections.Specialized;

//http://stackoverflow.com/questions/2798610/login-to-website-and-use-cookie-to-get-source-for-another-page


namespace MQOBot.Controllers
{
    class ConnectionController
    {
        private static ConnectionController instance;

        Random rand = new Random();

        // Bot Clients
        WebClientEx MainWebClient = new WebClientEx();
        WebClientEx ChatWebClient = new WebClientEx();
        WebClientEx StatsWebClient = new WebClientEx();
        WebClientEx FightWebClient = new WebClientEx();
        WebClientEx SkillWebClient = new WebClientEx();
        // Run on another thread

        // Form Client
        WebClientEx LoginWebClient = new WebClientEx();

        public static ConnectionController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionController();
                }
                return instance;
            }
        }

        public ConnectionController()
        {
            // Bot Events
            MQOEvents.onRequestChatUpdate += MQOEvents_onRequestChatUpdate;
            MQOEvents.onRequestStatUpdate += MQOEvents_onRequestStatUpdate;
            MQOEvents.onOpenChest += MQOEvents_onOpenChest;
            MQOEvents.onDoWork += MQOEvents_onDoWork;
            MQOEvents.onStopWork += MQOEvents_onStopWork;
            MQOEvents.onLoadFight += MQOEvents_onLoadFight;
            MQOEvents.onAttack += MQOEvents_onAttack;

            // Form Events
            MQOEvents.onSendMessage += MQOEvents_onSendMessage;
            MQOEvents.onRequestLogin += MQOEvents_onRequestLogin;
            MQOEvents.onRequestCharacterLogin += MQOEvents_onRequestCharacterLogin;

            // Bot Connection events
            MainWebClient.DownloadStringCompleted += MainWebClient_DownloadStringCompleted;
            ChatWebClient.DownloadStringCompleted += ChatWebClient_DownloadStringCompleted;
            StatsWebClient.DownloadStringCompleted += StatsWebClient_DownloadStringCompleted;
        }

        void MQOEvents_onRequestCharacterLogin(object obj)
        {
            if (!LoginWebClient.IsBusy)
            {
                MQOEvents.TestEvent("Attempting to login...");
                var values = new NameValueCollection
                {
                    { "CharId", (string)obj.ToString() },
                };

                // Upload the values
                string tempUri = "http://midenquest.com/Game.aspx";
                LoginWebClient.UploadValues(tempUri, values);

                MQOEvents.Connected(true);
            }
            else
            {
                MQOEvents.TestEvent("Login Client is busy");
            }
        }

        void MQOEvents_onRequestLogin(object obj)
        {
            MQOEvents.TestEvent("Loggin requested");
            if (!LoginWebClient.IsBusy)
            {
                string[] parsed = obj.ToString().Split(',');

                var values = new NameValueCollection
                {
                    { "User", parsed[0]},
                    { "Pass", parsed[1]},
                };
                
                // Upload values
                string tempStringUri = "http://midenquest.com/UserLogin.aspx";
                LoginWebClient.UploadValues(tempStringUri, values);

                // Get Character Page
                string charPage = LoginWebClient.DownloadString("http://midenquest.com/UserCharacterSelection.aspx");

                SetCookies();

                MQOEvents.OpenCharacterSelection(charPage);
            }
            else
            {
                MQOEvents.TestEvent("Busy");
            }
        }

        void SetCookies()
        {
            // Cookies!
            MainWebClient.CookieContainer = LoginWebClient.CookieContainer;
            ChatWebClient.CookieContainer = LoginWebClient.CookieContainer;
            StatsWebClient.CookieContainer = LoginWebClient.CookieContainer;
            FightWebClient.CookieContainer = LoginWebClient.CookieContainer;
            SkillWebClient.CookieContainer = LoginWebClient.CookieContainer;
            LoginWebClient.CookieContainer = LoginWebClient.CookieContainer;
        }

        void MQOEvents_onSendMessage(object obj)
        {
            if (!LoginWebClient.IsBusy)
            {
                string Message = (string)obj;
                Uri tempUri = new Uri("http://midenquest.com/sendMessage.aspx?ch=1&Message=" + Message + "&sid=" + GetSID().ToString());
            }
        }

        // goes from the form with 

        void StatsWebClient_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            MQOEvents.StatReady(e.Result);
        }

        void ChatWebClient_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            MQOEvents.ChatReady(e.Result);
        }

        void MainWebClient_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            MQOEvents.MainReady(true);
        }

        void MQOEvents_onAttack(object obj)
        {
            if (!FightWebClient.IsBusy)
            {
                Uri tempUri = new Uri("http://midenquest.com/useSkill.aspx?id=1&ta=" + obj.ToString());
                FightWebClient.DownloadString(tempUri);
            }
        }

        void MQOEvents_onLoadFight(object obj)
        {
            if (!FightWebClient.IsBusy)
            {
                Uri tempUri = new Uri("http://midenquest.com/loadFight.aspx?id=" + obj.ToString() + "&sid=" + GetSID().ToString());
                FightWebClient.DownloadString(tempUri);
                MQOEvents.TestEvent("Loading Monster ID: " + obj.ToString());
            }
        }

        void MQOEvents_onStopWork(object obj)
        {
            if (!SkillWebClient.IsBusy)
            {
                Uri tempUri = new Uri("http://midenquest.com/useWork.aspx?stop=4&null=&sid=" + GetSID().ToString());
                SkillWebClient.DownloadString(tempUri);
            }
        }

        void MQOEvents_onDoWork(object obj)
        {
            if (!SkillWebClient.IsBusy)
            {
                MQOEvents.TestEvent("Doing work");
                Uri tempUri = new Uri("http://midenquest.com/useWork.aspx?start=" + obj.ToString() + "&null=");
                SkillWebClient.DownloadString(tempUri);
            }
        }

        void MQOEvents_onOpenChest(object obj)
        {
            if (!MainWebClient.IsBusy)
            {
                Uri tempUri = new Uri("http://midenquest.com/getCharacterSheet.aspx?open=1");
                MainWebClient.DownloadString(tempUri);
            }
        }

        void MQOEvents_onRequestChatUpdate(object obj)
        {
            //when its done throw the chat update event
            if (!ChatWebClient.IsBusy)
            {
                Uri temp = new Uri("http://midenquest.com/getChatLog.aspx");
                ChatWebClient.DownloadStringAsync(temp);
            }
        }

        void MQOEvents_onRequestStatUpdate(object obj)
        {
            if (!ChatWebClient.IsBusy)
            {
                Uri temp = new Uri("http://midenquest.com/getCharactersShort.aspx?null=&sid=" + GetSID().ToString());
                StatsWebClient.DownloadStringAsync(temp);
            }
        }

        public double GetSID()
        {
            return rand.NextDouble();
        }

        public void SetHeaders()
        {
            LoginWebClient.Headers.Add("Host", "www.midenquest.com");
            LoginWebClient.Headers.Add("Content-Type", "text/html");
            //FormWebClientnt.Headers.Add("X-Requested-By", "XHR");
            //FormWebClientnt.Headers.Add("X-Request-Id", "0");
            LoginWebClient.BaseAddress = "http://www.midenquest.com/Game.aspx";
            LoginWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.90 Safari/537.36");
            LoginWebClient.Headers.Add("Referer", "http://www.midenquest.com/Game.aspx");
            LoginWebClient.Headers.Add("Accept", "*/*");
            LoginWebClient.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            LoginWebClient.Headers.Add("Accept-Language", "en-GB, en-US;q=0.8,en;q=0.6");
        }
    }
}
