using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Globals
{
    public static class PlayerGameController
    {
        public static Vector3 CurrentLocation { get; private set; }
        public static Vector3 CurrentTargetLocation { get; private set; }
        public static Vector3 DistanceFromTarget { get; set; }
        public static bool ActionBeingSelected { get; set; }
        public static bool DiceNeedsRolled { get; set; }

        private static GameObject currentSelectedTarget;
        public static GameObject CurrentSelectedTarget 
        {
            get
            {
                return currentSelectedTarget;
            }
            set
            {
                if (currentSelectedTarget!= null)
                {
                    currentSelectedTarget.GetComponent<GamePieceControl>().CurrentCubeBelowPiece.GetComponent<TileMechanics>().IsHighlighted = false;
                    if (currentSelectedTarget.GetComponent<GamePieceControl>().CurrentCubeBelowPiece.GetComponent<TileMechanics>().IsOccupied)
                    {
                        currentSelectedTarget.GetComponent<GamePieceControl>().CurrentCubeBelowPiece.GetComponent<Renderer>().material = TileMechanics.OccupiedTileMaterial;
                    }
                }

                currentSelectedTarget = value;
                if (currentSelectedTarget !=null)
                {
                    CurrentTargetLocation = currentSelectedTarget.transform.position;
                    DistanceFromTarget = new Vector3(Math.Abs(CurrentLocation.x - currentSelectedTarget.transform.position.x), 0, Math.Abs(CurrentLocation.z - currentSelectedTarget.transform.position.z));

                    currentSelectedTarget.GetComponent<GamePieceControl>().CurrentCubeBelowPiece.GetComponent<TileMechanics>().IsHighlighted = true;
                }
                
            }
        }

        public static void CheckKeyboardInputMovement()
        {
            if (ActionBeingSelected)
            {
                return;
            }
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft > 0)
            {
                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(0, 0, 1);

                if (CheckIfBadMove("Up"))
                {
                    return;
                }

                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft--;

                if (GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft <= 0)
                {
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft--;

                    if (GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft == 0)
                    {
                        GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().FinalMoveAdjustment = true;
                    }
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.CreatureStats.Speed;
                }

                PlayerUIController.ActionPointsLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft;
                PlayerUIController.MovementLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft;

            }
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft > 0)
            {

                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().transform.position += new Vector3(0, 0, -1);
                if (CheckIfBadMove("Down"))
                {
                    return;
                }
                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft--;

                if (GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft <= 0)
                {
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft--;

                    if (GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft == 0)
                    {
                        GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().FinalMoveAdjustment = true;
                    }
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.CreatureStats.Speed;

                }

                PlayerUIController.ActionPointsLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft;
                PlayerUIController.MovementLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft > 0)
            {
                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().transform.position += new Vector3(1, 0, 0);
                if (CheckIfBadMove("Right"))
                {
                    return;
                }
                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft--;

                if (GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft <= 0)
                {
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft--;

                    if (GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft == 0)
                    {
                        GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().FinalMoveAdjustment = true;
                    }
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.CreatureStats.Speed;
                }

                PlayerUIController.ActionPointsLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft;
                PlayerUIController.MovementLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft;
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft > 0)
            {
                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().transform.position += new Vector3(-1, 0, 0);
                if (CheckIfBadMove("Left"))
                {
                    return;
                }
                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft--;

                if (GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft <= 0)
                {
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft--;

                    if (GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft == 0)
                    {
                        GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().FinalMoveAdjustment = true;
                    }
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.CreatureStats.Speed;
                }

                PlayerUIController.ActionPointsLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft;
                PlayerUIController.MovementLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalSpeedLeft;
            }

        }

        private static bool CheckIfBadMove(string direction)
        {
            Vector3 fwd = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.TransformDirection(Vector3.down);
            Debug.DrawRay(GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position, GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.TransformDirection(Vector3.down) * 1000, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position, fwd, out hit, 1000))
            {
                // Reverse the direction they moved
                if (hit.collider.tag != "Tile")
                {
                    switch (direction) 
                    {
                        case "Up":
                            GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(0, 0, -1);
                            break;
                        case "Down":
                            GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(0, 0, 1);
                            break;
                        case "Left":
                            GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(1, 0, 0);
                            break;
                        case "Right":
                            GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(-1, 0, 0);
                            break;
                    }

                    return true;
                }
                else
                {
                    // It is a tile, so lets see if it is occupied
                    if (hit.collider.gameObject.GetComponent<TileMechanics>().IsOccupied == true)
                    {
                        switch (direction)
                        {
                            case "Up":
                                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(0, 0, -1);
                                break;
                            case "Down":
                                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(0, 0, 1);
                                break;
                            case "Left":
                                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(1, 0, 0);
                                break;
                            case "Right":
                                GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position += new Vector3(-1, 0, 0);
                                break;
                        }

                        return true;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckCurrentLocation()
        {
            CurrentLocation = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].transform.position;
            return false;
        }

        public static void CheckIfEscapeIsPressed()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && ActionBeingSelected)
            {
                PlayerGameController.CurrentSelectedTarget = null;
            }
        }

        public static void MeleeAttackAction()
        {
            if (CurrentSelectedTarget == null)
            {
                Debug.Log("Please select a valid target!");
                return;
            }
            if (DistanceFromTarget != null && ActionBeingSelected && CurrentSelectedTarget != null)
            {
                if (DistanceFromTarget.x <= 1 && DistanceFromTarget.z <= 1)
                {
                    Debug.Log("YOU ARE ATTACKING " + CurrentSelectedTarget.name);
                    if (DiceNeedsRolled)
                    {
                        Debug.Log("NEED TO ROLL DIC!");
                        // FORCE PLAYER TO ROLL DICE OR ALLOW TO CANCEL
                        return;
                    }
                    DiceNeedsRolled = true;
                    GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft--;

                    CalculateHitToDefense();
                    Debug.Log("YOU HAVE ATTACKED A CREATURE!");

                    CurrentSelectedTarget = null;
                    
                    PlayerUIController.ActionPointsLeftOnTurn = GameTurnMechanic.InitiativeList[GameTurnMechanic.CurrentTurnNumber].GetComponent<GamePieceControl>().MyCreatureStats.TotalActionPointsLeft;
                }
                else
                {
                    Debug.Log("YOU CANNOT HIT" + CurrentSelectedTarget.name);
                }
            }
        }

        private static void CalculateHitToDefense()
        {
            
        }
    }
}
