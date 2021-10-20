using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundLabelBehavior : MonoBehaviour
{
    public Text RoundLabel;
    // Start is called before the first frame update
    void Start()
    {
        RoundLabel.text = TurnManager.Round.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        RoundLabel.text = TurnManager.Round.ToString();
    }
}
