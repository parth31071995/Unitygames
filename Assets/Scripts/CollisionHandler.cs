using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

     void OnTriggerEnter(Collider other) 
    {
        //Debug.Log($"{this.name} **Triggered with** {other.gameObject.name}");
        //another way of writing

        startCrashsequence();
       
    }

    void startCrashsequence()
    {
        GetComponent<PlayerControls>().enabled = false; //disable player controls 
        Invoke("ReloadLevel", loadDelay); // reload level after 1 sec
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;


    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
