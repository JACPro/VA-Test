using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AnimationManager animationManager;

    [SerializeField] GameObject placeableObject;

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
        }
        else if (Input.GetMouseButton(0))
        {
            placeableObject.GetComponent<RotateObject>().Rotate();
        }
    }
}
