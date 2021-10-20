using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target_panel_behavior : MonoBehaviour
{
    public GameObject TargetLabel;
    public GameObject TargettedDefenseLabel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerGameController.ActionBeingSelected)
        {
            if (PlayerGameController.CurrentSelectedTarget != null)
            {
                TargettedDefenseLabel.GetComponent<Text>().text= PlayerGameController.CurrentSelectedTarget.GetComponent<GenericCreature>().CreatureStats.Defense.ToString();
                TargetLabel.GetComponent<Text>().text = PlayerGameController.CurrentSelectedTarget.name;
            }
            else
            {
                TargettedDefenseLabel.GetComponent<Text>().text = "-";
                TargetLabel.GetComponent<Text>().text = "None";
            }
        }
    }
}
