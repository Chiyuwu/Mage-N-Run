using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("CollectableOfAllCollectables")) {
            // stop wall & player movement
            MageMovement.setMayMageScoot(false);
            CloudOfDarknessInflation.setWallMayMove();
            // stop score + time
            LevelManagement.setMayCalculate(false);
            // dont destroy on load game manager - check
            // in levelmanagement set everything to 'go' again - check?
            
            /// get player data
            if (SceneManager.GetActiveScene().buildIndex == 2)  // is current scene level 2?
            {
                // get player keyboard name

                // serialize score, name, time
                // make menu so data gets from save file
            }


        }
        
    }


}
