using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudOfDarknessInflation : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5; // Wall move speed
    [SerializeField] Transform mage; 
    static bool wallMayMove = true; // Wall is allowed to move
    public static void setWallMayMove() // Wall isn't allowed to move 
    {
        
        wallMayMove = false;  //STOP!! You have violated the law!
    }
    private void FixedUpdate()
    {
        if (wallMayMove) // If the wall is allowed to move...
        {
            transform.position = new Vector2(transform.position.x, mage.position.y); //Cloud is moving with Mage (takes y from Mage position)
            
            transform.Translate(new Vector2(1, 0)* moveSpeed * Time.deltaTime); // ... she damn well will move.
        }

        

    }
}
