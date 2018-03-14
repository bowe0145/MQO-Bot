using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQOBot.Events
{
    class MQOEvents
    {
        public delegate void BotEvent(object obj);
        public delegate void FormEvent(object obj);
        public delegate void ConnectionEvent(object obj);

        public static event BotEvent onRequestChatUpdate;
        public static event BotEvent onRequestStatUpdate;
        public static event BotEvent onChatUpdate;
        public static event BotEvent onStatUpdate;
        public static event BotEvent onAttack;
        public static event BotEvent onFight;
        public static event BotEvent onStopFight;
        public static event BotEvent onOpenChest;
        public static event BotEvent onStartWork;
        public static event BotEvent onStopWork;
        public static event BotEvent onDoWork;
        public static event BotEvent onLoadFight;

        public static void RequestChatUpdate(object obj)
	    {
		    if (onRequestChatUpdate != null)
		    {
			    onRequestChatUpdate(obj);
		    }
	    }

        public static void RequestStatUpdate(object obj)
        {
            if (onRequestStatUpdate != null)
            {
                onRequestStatUpdate(obj);
            }
        }

        public static void ChatUpdate(object obj)
        {
            if (onChatUpdate != null)
            {
                onChatUpdate(obj);
            }
        }

        public static void StatUpdate(object obj)
        {
            if (onStatUpdate != null)
            {
                onStatUpdate(obj);
            }
        }

        public static void Attack(object obj)
        {
            if (onAttack != null)
            {
                onAttack(obj);
            }
        }

        public static void Fight(object obj)
        {
            if (onFight != null)
            {
                onFight(obj);
            }
        }

        public static void StopFight(object obj)
        {
            if (onStopFight != null)
            {
                onStopFight(obj);
            }
        }

        public static void OpenChest(object obj)
        {
            if (onOpenChest != null)
            {
                onOpenChest(obj);
            }
        }

        public static void StartWork(object obj)
        {
            if (onStartWork != null)
            {
                onStartWork(obj);
            }
        }

        public static void StopWork(object obj)
        {
            if (onStopWork != null)
            {
                onStopWork(obj);
            }
        }

        public static void DoWork(object obj)
        {
            if (onDoWork != null)
            {
                onDoWork(obj);
            }
        }

        public static void LoadFight(object obj)
        {
            if (onLoadFight != null)
            {
                onLoadFight(obj);
            }
        }

        public static event FormEvent onGetCookie;
        public static event FormEvent onOpenLogin;
        public static event FormEvent onOpenCharacterSelection;
        public static event FormEvent onRequestCharacterSelection;
        public static event FormEvent onRequestLogin;
        public static event FormEvent onRequestCharacterLogin;
        public static event FormEvent onSendMessage;
        public static event FormEvent onTestEvent;
        
        public static void TestEvent(object obj)
        {
            if (onTestEvent != null)
            {
                onTestEvent(obj);
            }
        }

        public static void GetCookie(object obj)
        {
            if (onGetCookie != null)
            {
                onGetCookie(obj);
            }
        }

        public static void OpenLogin(object obj)
        {
            if (onOpenLogin != null)
            {
                onOpenLogin(obj);
            }
        }

        public static void OpenCharacterSelection(object obj)
        {
            if (onOpenCharacterSelection != null)
            {
                onOpenCharacterSelection(obj);
            }
        }

        public static void RequestCharacterSelection(object obj)
        {
            if (onRequestCharacterSelection != null)
            {
                onRequestCharacterSelection(obj);
            }
        }

        public static void RequestLogin(object obj)
        {
            if (onRequestLogin != null)
            {
                onRequestLogin(obj);
            }
        }

        public static void RequestCharacterLogin(object obj)
        {
            if (onRequestCharacterLogin != null)
            {
                onRequestCharacterLogin(obj);
            }
        }

        public static void SendMessage(object obj)
        {
            if (onSendMessage != null)
            {
                onSendMessage(obj);
            }
        }

        public static event ConnectionEvent onFightReady;
        public static event ConnectionEvent onWorkReady;
        public static event ConnectionEvent onChatReady;
        public static event ConnectionEvent onStatReady;
        public static event ConnectionEvent onMainReady;
        public static event ConnectionEvent onConnected;
        public static event ConnectionEvent onDisconnected;

        public static void FightReady(object obj)
        {
            if (onFightReady != null)
            {
                onFightReady(obj);
            }
        }

        public static void WorkReady(object obj)
        {
            if (onWorkReady != null)
            {
                onWorkReady(obj);
            }
        }

        public static void ChatReady(object obj)
        {
            if (onChatReady != null)
            {
                onChatReady(obj);
            }
        }

        public static void StatReady(object obj)
        {
            if (onStatReady != null)
            {
                onStatReady(obj);
            }
        }

        public static void MainReady(object obj)
        {
            if (onMainReady != null)
            {
                onMainReady(obj);
            }
        }

        public static void Connected(object obj)
        {
            if (onConnected != null)
            {
                onConnected(obj);
            }
        }

        public static void Disconnected(object obj)
        {
            if (onDisconnected != null)
            {
                onDisconnected(obj);
            }
        }
    }
}