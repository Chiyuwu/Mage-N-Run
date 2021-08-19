using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
  


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("CollectableOfAllCollectables")) {
            

           
            MageMovement.setMayMageScoot(false); // stop wall & player movement

           
            CloudOfDarknessInflation.setWallMayMove(); //Wall stops moving

            if (SceneManager.GetActiveScene().buildIndex == 2)  // is current scene level 2?
            {              

                LevelManagement.setScore(1000, 0); //Reset score to 1000
                ChangeScene.switchToScene(0); //Change scene to menu

            } 
            
            else if(SceneManager.GetActiveScene().buildIndex == 1) //current scene is Level 1
            {
                ChangeScene.switchToScene(2); //...otherwise change to level 2
            }
            
          


        }
        
    }


}
