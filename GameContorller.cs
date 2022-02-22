using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Enables use of UserInterface actions like (Text scoreText)
using UnityEngine.UI;


public class GameContorller : MonoBehaviour
{

    //------Enables methods to be called in update and start section ---- 
    // This refrences the player in the GameContoller

    public Playa Playa;
    public Enemy enemy;

    public Text scoreText;
    public Text endLevelText;
    private int score;

    private float restartTimer = 3f;
    private float finishTimer = 5f;


    [Header("Gravity Level")]
    public float gravity = 9.81f;
    private bool finished;

    // Use this for initialization--------------------------------------------------------------
    void Start()
    {
        endLevelText.enabled = false; 



     // Method to call the onCollectCoin Action we put on player script.
        Playa.onCollectCoin = onCollectCoin;
        
     
    }
    // Update is called once per frame-----------------------------------------------------------
    void Update() 
    {
     Physics.gravity = new Vector3(0, -gravity, 0);




        if (Playa.Finished)
        {
            if (finished == false)
            {
                finished = true;
                OnFinish();
            }
            finishTimer -= Time.deltaTime;

            if (finishTimer <= 0f)
            {
                LevelManager.Instance.LoadNextLevel();
               

            }
        }



        /* 
        -------- Dead Player------
            */
        if (Playa.Dead)
        {
           restartTimer -= Time.deltaTime;
           if (restartTimer <= 0f)
           {
                LevelManager.Instance.ReloadLevel ();
                // -----This line of code restarts the scene-----
                
           }
        }
    }

    void OnFinish()
    {

        endLevelText.enabled = true;

        
        endLevelText.text = "  y o u  f i n i s h e d  " + LevelManager.Instance.LevelName + "!!!";
        endLevelText.text += "\n y o u r  s c o r e  i s :  " + score;
    }


    void onCollectCoin() 
    {
      // once the play CollectCoin score ++; = (add the score +1)
      score++;
      scoreText.text = " score : " + score;
    }


    

}