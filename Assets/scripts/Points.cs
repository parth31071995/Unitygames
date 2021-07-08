using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

int hits =0;
   private void OnCollisionEnter(Collision other) 
   {

     if(other.gameObject.tag != "Hit")
     {
       hits++;
       Debug.Log("you hit a bump , you piece of shit"+" "+ hits);
     }
     
     
     
   }
   
}
