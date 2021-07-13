using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
     void Awake() 
    {
        int numOfMusicplayers = FindObjectsOfType<MusicPlayer>().Length; //tells us how much we can store in this array

        if(numOfMusicplayers > 1) // if there is more than one music player destroy it , using it to kill restarting music when respawned
        {
            Destroy(gameObject);

            // uses singleton pattern 
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
