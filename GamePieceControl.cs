using Assets.Scripts.Globals;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GamePieceControl : MonoBehaviour
{
    public static bool PROCESSING_TURN;
    public static bool isGrabbingPiece;
    public static int playersTryingToMove;

    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 startPos;

    public GameObject CurrentCubeBelowPiece;
    public GameObject PreviousCubeBelowPiece;

    public bool IsSelected = false;

    public GenericCreature MyCreatureStats;

    Color oldColor;

    public bool FinalMoveAdjustment { get; set; }

    void Start()
    {
        isGrabbingPiece = false;
        startPos = transform.position;
        MyCreatureStats = GetComponent<GenericCreature>();
        PROCESSING_TURN = false;
        playersTryingToMove = 0;
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (PlayerGameController.ActionBeingSelected)
        {
            PlayerGameController.CurrentSelectedTarget = gameObject;
        }
    }

    private void OnMouseUp()
    {

    }

    void Update()
    {
        if (GetComponent<GenericCreature>().CreatureStats.ActionPoint > 0 && MyCreatureStats.IsTurnActive)
        {
            PieceOutOfBounds();
        }
    }

    public Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // Update is called once per frame
    void OnMouseDrag()
    {
    }

    void PieceOutOfBounds()
    {
        if (gameObject.transform.position.y < 0  && !isGrabbingPiece)
        {
            gameObject.transform.position = startPos;
        }

    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.down);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 1000))
        {
            // For debugging
            if (CurrentCubeBelowPiece != hit.collider.gameObject)
            {
                Debug.Log("Moved to new tile: " + hit.collider.gameObject);
            }
            PreviousCubeBelowPiece = CurrentCubeBelowPiece;

            if (PreviousCubeBelowPiece)
            {
                PreviousCubeBelowPiece.GetComponent<TileMechanics>().IsOccupied = false;
            }

            CurrentCubeBelowPiece = hit.collider.gameObject;
            CurrentCubeBelowPiece.GetComponent<TileMechanics>().IsOccupied = true;
        }
        else
        {
            if (MyCreatureStats.IsTurnActive || FinalMoveAdjustment == true) //TODO: can end turn on invalid square on last move because
            {
                Debug.Log("Invalid Move! Try moving a different location.");
                if (FinalMoveAdjustment == true)
                {
                    FinalMoveAdjustment = false;
                }

                float yLocation = transform.position.y;
                transform.position = new Vector3(CurrentCubeBelowPiece.transform.position.x, yLocation, CurrentCubeBelowPiece.transform.position.z);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            
        }
    }
}
