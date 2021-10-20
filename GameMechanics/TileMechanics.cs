using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMechanics : MonoBehaviour
{
    public bool IsOccupied = false;
    
    private bool isHighlighted;
    public bool IsHighlighted
    {
        get
        {
            return isHighlighted;
        }
        set
        {
            isHighlighted = value;

            if (isHighlighted)
            {
                GetComponent<Renderer>().material = HighlightedTileMaterial;
            }
            else
            {
                GetComponent<Renderer>().material = NormalTileMaterial;
            }
        }
    }

    public static Material OccupiedTileMaterial;
    public static Material HighlightedTileMaterial;
    public static Material NormalTileMaterial;

    // Start is called before the first frame update
    void Start()
    {
        OccupiedTileMaterial = Resources.Load("square_texture_yellow", typeof(Material)) as Material;
        HighlightedTileMaterial = Resources.Load("square_texture_blue", typeof(Material)) as Material;
        NormalTileMaterial = Resources.Load<Material>("square_texture_1");

        //GetComponent<Renderer>().material = NormalTileMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerGameController.ActionBeingSelected)
        {
            if (IsOccupied)
            {
                GetComponent<Renderer>().material = OccupiedTileMaterial;
            }
            else
            {
                if (!isHighlighted)
                {
                    GetComponent<Renderer>().material = NormalTileMaterial;
                }
                
            }
        }
    }
    void OnMouseEnter()
    {
        if (PlayerGameController.ActionBeingSelected)
        {
            GetComponent<Renderer>().material = HighlightedTileMaterial;
        }
    }

    private void OnMouseDown()
    {
    }

    private void OnMouseExit()
    {
        if (PlayerGameController.ActionBeingSelected && !isHighlighted)
        {
            if (IsOccupied)
            {
                GetComponent<Renderer>().material = OccupiedTileMaterial;
            }
            else
            {
                GetComponent<Renderer>().material = NormalTileMaterial;
            }
        }
    }
}
