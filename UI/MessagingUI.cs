using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagingUI : MonoBehaviour
{
    public Text MessagingTextComp;
    // Start is called before the first frame update
    void Start()
    {
        MessagingSystem.MessagingPanel = this.gameObject;
        MessagingSystem.MessageTextComponent = MessagingTextComp;
        MessagingSystem.MessageTextComponent.text = "Debugging Text";
        MessagingSystem.MessagingPanel.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
