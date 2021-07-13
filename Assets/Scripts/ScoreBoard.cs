using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

     void Start() 
     {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "start";
         
     }
    
    public void increaseScore(int amountToincrease)
    {
        
        score += amountToincrease;
        scoreText.text = score.ToString();
       // Debug.Log($" Current score is : {score} ");


    }
  
}
