using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAnimationState : MonoBehaviour
{
    [SerializeField] float invulnerableDuration = 3; // Serialized field for Invulnerability

    public void startAnimationIsDamaged()
    {
        MageMovement.setYeetMage(true);
        Debug.Log("yeet"); // Animation commands the throwback (yeeting)
    }

    public void endAnimationIsDamaged() 
    {
        MageMovement.setAnimIsDamaged(false); // Damage animation is concluded
        MageMovement.setMayMageScoot(true); // Mage is able to move again
        MageMovement.setMayMageBadTouch(true); // Mage can be hurt again
    }



}
