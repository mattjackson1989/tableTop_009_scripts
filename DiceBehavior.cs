using Assets.Scripts.Globals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehavior : MonoBehaviour
{
    public static bool isGrabbingPiece;
    public static int playersTryingToMove;
    // Start is called before the first frame update
    void Start()
    {
        ORIGIN = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -2)
        {
            transform.position = ORIGIN;
        }
    }

    private void FixedUpdate()
    {

    }

    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 startPos;
    private Vector3 ORIGIN;
    void OnMouseDrag()
    {
        DiceManager.CurrentSelectedDice = this.gameObject;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        startPos = transform.position;
        
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.Rotate(new Vector3(10f, 5f, 0));
    }
    public Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDown()
    {
        DiceManager.CurrentSelectedDice = this.gameObject;
        transform.Rotate(new Vector3(10f, 5f, 0));
        GetComponent<Rigidbody>().useGravity = false;
        isGrabbingPiece = true;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        startPos = transform.position;
    }

    private void OnMouseUp()
    {
        transform.Rotate(new Vector3(10f, 5f, 0));
        GetComponent<Rigidbody>().useGravity = true;
        isGrabbingPiece = false;
        transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
    }

    //void OnMouseDrag()
    //{
    //    float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    //    Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
    //    transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);

    //}
}
