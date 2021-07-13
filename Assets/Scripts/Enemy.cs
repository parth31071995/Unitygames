using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    
    [SerializeField] int scoreHit = 15;
    [SerializeField] int hitPoints = 10;

    

    ScoreBoard scoreBoard;
    GameObject ParentVal;


     void Start()
    {
        
        scoreBoard = FindObjectOfType<ScoreBoard>();

        // looks in the whole project and tells compiler the very first scoreboard you find is the one that is being reffered too
        
        ParentVal = GameObject.FindWithTag("Spawn");
        addRigidBody();

        
    }

    void OnParticleCollision(GameObject other) 
    {
        updateScore();
        if(hitPoints <1)
        {
        killEnemy();
        }
    }

    void updateScore()
    {
        GameObject vfx =  Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = ParentVal.transform;
        hitPoints --;
        
    }

    void killEnemy()
    {
       scoreBoard.increaseScore(scoreHit); 
       GameObject fx =  Instantiate(deathFX, transform.position, Quaternion.identity);
       fx.transform.parent = ParentVal.transform;
        Destroy(gameObject);

        /* implementiing death vfx on every enemy particle where this script is 
        instead of adding them manually , adding them as run time. Instantiate takes three parameters
        (object , position , rotation ) , transform.position = current position , Quaternion.identity = no rotation req )*/

    }

    void addRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
       rb.useGravity = false;
    }
}

