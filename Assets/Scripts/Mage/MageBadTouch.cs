using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBadTouch : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(MageMovement.getMayMageBadTouch()) //Get if Mage can be hurt
        {
            if(collision.gameObject.CompareTag("Pain")) // If Mage collides with collider 'Pain' ...
            {
                MageMovement.setMayMageScoot(false); // ... Mage can't move
                MageMovement.setMayMageBadTouch(false); // ... Mage can't be hurt a second time
                MageMovement.setAnimIsDamaged(true); // ... Play damage animation 
            }
        }
        
    }
}
