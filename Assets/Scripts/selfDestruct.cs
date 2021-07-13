using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    [SerializeField] float TimeTillDestroy = 3f;
    void Start()
    {

    // This will go inside the explosion particle prefab in order to not destruct mutiple explosions tem files created 
      Destroy(gameObject, TimeTillDestroy); // small g means particular game object , big G means a specified game object   

      // you can see the beahviour in " spawn at run time " at run time 

    }

    
}
