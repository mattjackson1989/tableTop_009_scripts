using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonBehavior : MonoBehaviour
{
    public GameObject MenuPanel;
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
        MenuPanel.gameObject.SetActive(IsPanelEnabled);
    }
}
