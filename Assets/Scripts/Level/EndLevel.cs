using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("CollectableOfAllCollectables")) {
            // stop wall & player movement
            // stop score + time
            // dont destroy on load game manager - check
            // in levelmanagement set everything to 'go' again
            
            /// get player data
            // is current scene level 2?
            // get player keyboard name
            
            // serialize score, name, time
            // make menu so data gets from save file
        }
        
    }


}
