using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerHUDBehavior : MonoBehaviour
{
    public GameObject PlayerNameLabel;
    public GameObject PlayerActionPointLabel;
    public GameObject PlayerMovementLabel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerNameLabel.GetComponent<Text>().text = PlayerUIController.CurrentPlayersName;
        PlayerMovementLabel.GetComponent<Text>().text = PlayerUIController.MovementLeftOnTurn.ToString();
        PlayerActionPointLabel.GetComponent<Text>().text = PlayerUIController.ActionPointsLeftOnTurn.ToString();
    }
}
