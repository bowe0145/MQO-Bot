using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQOBot.Events;

namespace MQOBot.Controllers
{
    class SetupController
    {
        private static SetupController instance;

        public static SetupController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SetupController();
                }
                return instance;
            }
        }

        BotController bot = BotController.Instance;
        ConnectionController conn = ConnectionController.Instance;
        ViewController view = ViewController.Instance;

        public SetupController()
        {
            
        }
    }
}
