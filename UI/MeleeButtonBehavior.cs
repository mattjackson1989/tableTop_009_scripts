using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeButtonBehavior : MonoBehaviour
{
    private Button ButtonMechanics;
    // Start is called before the first frame update
    void Start()
    {
        ButtonMechanics = this.GetComponent<Button>();
        ButtonMechanics.onClick.AddListener(OnClickFunction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClickFunction()
    {

        if (PlayerGameController.ActionBeingSelected)
        {
            PlayerGameController.MeleeAttackAction();
        }
        else
        {
            
        }
    }

}
