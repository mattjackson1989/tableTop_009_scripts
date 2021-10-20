using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Globals
{
    public static class MessagingSystem
    {
        public static GameObject MessagingPanel;
        public static Text MessageTextComponent;

        public static void ToggleMessagePanel(bool isActive)
        {
            MessagingPanel.SetActive(isActive);
        }

        public static void SetMessageText(string message)
        {
            MessagingPanel.SetActive(true);
            MessageTextComponent.text = message;
        }
    }
}
