using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonBehavior : MonoBehaviour
{
    public GameObject ActionPanel;
    private bool IsPanelEnabled;
    private Button ButtonMechanics;
    // Start is called before the first frame update
    void Start()
    {
        ButtonMechanics = this.GetComponent<Button>();
        ButtonMechanics.onClick.AddListener(OnClickFunction);
        IsPanelEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClickFunction()
    {
        IsPanelEnabled = !IsPanelEnabled;
        ActionPanel.gameObject.SetActive(IsPanelEnabled);

        if (ActionPanel.gameObject.activeSelf)
        {
            PlayerGameController.ActionBeingSelected = true;
            PlayerGameController.DiceNeedsRolled = true;
        }
        else
        {
            PlayerGameController.CurrentSelectedTarget = null;
            PlayerGameController.ActionBeingSelected = false;
        }
    }
}
