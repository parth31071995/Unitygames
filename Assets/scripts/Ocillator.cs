using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocillator : MonoBehaviour
{

    Vector3 StartingPostion;
   [SerializeField] Vector3 MovementVector;
   [SerializeField] [Range(0,1)] float MovementFactor; //makes it a slider to debug

   [SerializeField] float period = 2f;
   
    // Start is called before the first frame update
    void Start()
    {
        StartingPostion = transform.position;
        Debug.Log(StartingPostion);
    }

    // Update is called once per frame
    void Update()
    {
        //Time.time == how much time has elasped 
        //if(period == 0) { return; }  //this means if p == 0 do not run the code beneath

        // float == 0 or float can sometimes not be same ot sometimes we see them as 0 but they not exactly 0 so they might cause a crash 
        // use math.Epsilon = it is smalled float defined in unity  

        if (period <= Mathf.Epsilon) {return;}

        float cycles = Time.time / period; // eg time = 10 sec and period = 10f then 1 cycle is 10 sec /10

        const float tau = Mathf.PI * 2; //const value of radians 6.283

        float rawSineWave = Mathf.Sin(cycles*tau); // coverts the value into radians 

      

        MovementFactor = (rawSineWave + 1f) / 2f; // to make the values go from 0 to 1 instead of -1 to 1 we add +1 and divided it by 2f 
        // so values can be floated or decimaled for smooth transition

        Vector3 offset = MovementVector * MovementFactor;
         transform.position = StartingPostion + offset;
    }
}
