using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AnimationManager animationManager;

    [SerializeField] GameObject placeableObject;

    Touch touch1;
    Touch touch2;

    Vector2 t1Pos = Vector2.zero;
    Vector2 t2Pos = Vector2.zero;
    float tPosDistance;

    [SerializeField] float pinchThreshold = 200f;

    //when player 2 pinches, disable pinch explode/unexplode after first motion
    bool canPinch = true;

    void Start()
    {    
    }

    void Update()
    {
        //Testing code for triggering 3D model exploded view animation
        if (Input.GetKeyDown(KeyCode.E))
        {
            animationManager.Explode();
        }        
        else if (Input.GetKeyDown(KeyCode.U))
        {
            animationManager.Unexplode();
        }

        //detect mouse or touch input 
        
        if (Input.GetMouseButtonDown(0))
        {
            placeableObject.GetComponent<RotateObject>().SetStartValues();

            t1Pos = Input.GetTouch(0).position;
        }
        else if (Input.GetMouseButton(0))
        {
            //only rotate for 1 finger gestures
            if (Input.touchCount == 1)
            {
                placeableObject.GetComponent<RotateObject>().Rotate();
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            t2Pos = Input.GetTouch(1).position;
            tPosDistance = Vector2.Distance(t1Pos, t2Pos);
            Debug.Log("Start distance: " + tPosDistance);
        }


        //detect pinch
        if (Input.touchCount > 1)
        {
            t1Pos = Input.GetTouch(0).position;
            t2Pos = Input.GetTouch(1).position;

            //check if pinch has expanded by threshold amount since first double touch
            if (Vector2.Distance(t1Pos, t2Pos) >= tPosDistance + pinchThreshold)
            {
                animationManager.Explode();
                canPinch = false;
            }
            else if (Vector2.Distance(t1Pos, t2Pos) <= tPosDistance - pinchThreshold)
            {
                animationManager.Unexplode();
                canPinch = false;
            }

        }
        else
        {
            tPosDistance = 0f;
            canPinch = true;
        }
    }
}
