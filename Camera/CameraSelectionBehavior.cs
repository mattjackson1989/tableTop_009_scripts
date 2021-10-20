using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelectionBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfClickedByMouse();
    }

    void CheckIfClickedByMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // TODO: eventually make something that will make it known that this is different but they are in fact grabable board pieces - problem is that you can select multiple pieces as the active piece
                if (hit.transform.gameObject.tag == "BoardPiece")
                {
                    PlayerSelectionGlobalMechanics.isPieceSelected = true;

                    if (PlayerSelectionGlobalMechanics.CurrentSelectedPiece)
                    {
                        Behaviour oldHalo = (Behaviour)PlayerSelectionGlobalMechanics.CurrentSelectedPiece.transform.gameObject.GetComponent("Halo");
                        oldHalo.enabled = false;

                        PlayerSelectionGlobalMechanics.CurrentSelectedPiece.GetComponent<GamePieceControl>().IsSelected = false;
                    }

                    PlayerSelectionGlobalMechanics.CurrentSelectedPiece = hit.transform.gameObject;
                    Behaviour  newHalo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                    newHalo.enabled = true;

                    PlayerSelectionGlobalMechanics.CurrentSelectedPiece.GetComponent<GamePieceControl>().IsSelected = true;
                }
                else
                {
                    PlayerSelectionGlobalMechanics.isPieceSelected = false;
                    Behaviour halo = (Behaviour)PlayerSelectionGlobalMechanics.CurrentSelectedPiece.GetComponent("Halo");
                    halo.enabled = false;

                    PlayerSelectionGlobalMechanics.CurrentSelectedPiece.GetComponent<GamePieceControl>().IsSelected = false;
                    PlayerSelectionGlobalMechanics.CurrentSelectedPiece = null;
                }
            }
        }
    }
}
