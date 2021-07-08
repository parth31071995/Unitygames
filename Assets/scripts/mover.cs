using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{

    //[SerializeField]float xValue = 0;
    //[SerializeField]float yValue = 0f;
    //[SerializeField]float zValue = 0;
    [SerializeField] float movespeed =12f;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();        
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the game");  
        Debug.Log("Move your player with arrow keys");
        Debug.Log("Don't hit the wall");      
    }

    void MovePlayer()
    {
        /*defining float here as the value need to be updated by every frame , if we 
        decare it at top it will not change*/
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        float zValue = Input.GetAxis("Vertical")* Time.deltaTime * movespeed;

        transform.Translate(xValue,0,zValue);
    }
}
