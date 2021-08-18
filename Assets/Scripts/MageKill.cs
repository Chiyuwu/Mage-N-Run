using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // If the wall touches the character ...
        {
            CloudOfDarknessInflation.setWallMayMove(); // ... the wall stops moving ...
            ChangeScene.switchToScene(0);   // Go back to Main Menu
            
            //collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject); // ... and the character gets destroyed
        }
    }
}
