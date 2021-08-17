using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDownCheck : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor")) // If character touches floor ...
        {
            MageMovement.setMageHasJumped(); // ... jumpcounter gets reseted
        
        }
    }
}
