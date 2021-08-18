using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCollectable : MonoBehaviour
{
    [SerializeField] int amount = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) //If the collided collider is Mage, then
        {
            LevelManagement.setCollectableCount(amount);   // Collectable count goes up
            Destroy(gameObject);  // Destroy collectable
        }
    }
}
