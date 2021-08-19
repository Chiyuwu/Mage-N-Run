using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("CollectableOfAllCollectables")) {
            Debug.Log("end");

            // stop wall & player movement
            MageMovement.setMayMageScoot(false);
            CloudOfDarknessInflation.setWallMayMove();
            // stop score + time
            
            // dont destroy on load game manager - check
            // in levelmanagement set everything to 'go' again - check?
            
            /// get player data
            if (SceneManager.GetActiveScene().buildIndex == 2)  // is current scene level 2?
            {

                Debug.Log(SceneManager.GetActiveScene().buildIndex);
                // LevelManagement.setMayCalculate(false);
                // get player keyboard name

                // serialize score, name, time
                // make menu so data gets from save file

                LevelManagement.setScore(1000, 0);
                ChangeScene.switchToScene(0);

            } else if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log(SceneManager.GetActiveScene().buildIndex);
                LevelManagement.setMayCalculate(true);
                ChangeScene.switchToScene(2);
            }else if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                Debug.Log(SceneManager.GetActiveScene().buildIndex);

                LevelManagement.setMayCalculate(true);
            }


        }
        
    }


}
