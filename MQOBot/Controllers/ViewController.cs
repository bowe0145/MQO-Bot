using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQOBot.Views;
using MQOBot.Events;

namespace MQOBot.Controllers
{
    class ViewController
    {
        private static ViewController instance;

        public static ViewController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ViewController();
                }
                return instance;
            }
        }

        LoginForm LoginForm;
        CharacterSelectionForm CharForm;

        public ViewController()
        {
            MQOEvents.onOpenLogin += MQOEvents_onOpenLogin;
            MQOEvents.onOpenCharacterSelection += MQOEvents_onOpenCharacterSelection;
            MQOEvents.onConnected += MQOEvents_onConnected;

            Form1 form = Form1.Instance;
            form.ShowDialog();
        }

        void MQOEvents_onConnected(object obj)
        {
            CharForm.Close();
        }

        void MQOEvents_onOpenCharacterSelection(object obj)
        {
            // here after connection
            LoginForm.Close();

            CharForm = new CharacterSelectionForm((string)obj);

            CharForm.ShowDialog();
        }

        void MQOEvents_onOpenLogin(object obj)
        {
            LoginForm = new LoginForm();

            LoginForm.ShowDialog();
        }
    }
}
