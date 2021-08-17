using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float height;
    Vector3 positionCheck; 
    Vector3 direction = new Vector3(-1, 0, 0); // Direction of movement

    private void Start()
    {
        positionCheck = new Vector3(-80, height, 0); //if position reached --> jump back
    }
    // Update is called once per frame
    void Update()
    {
        if (MageMovement.getMageScoots()) // Mage moves
        {
            if(MageMovement.getHorizontalInput() > 0)    // Mage moves right
            {
                if (gameObject.transform.position.x <= positionCheck.x) // Positioncheck
                {
                    gameObject.transform.position = new Vector3(0, height, 0); // Background position for seamless loop
                }
                if(MageMovement.getAnim().GetBool("isDamaged") == true && MageMovement.getAnim().GetBool("isTouchingFloor") == false && MageMovement.getAnim().GetBool("isMoving") == false) // Damage animation state
                {
                    gameObject.transform.Translate(-direction * speed * Time.deltaTime); // Movement
                }
                else
                {
                    gameObject.transform.Translate(direction * speed * Time.deltaTime); // Movement
                }
                

            } else if (MageMovement.getHorizontalInput() < 0)    // Mage moves left
            {
                if (gameObject.transform.position.x >= -positionCheck.x) // Positioncheck
                {
                    gameObject.transform.position = new Vector3(0, height , 0); // Background position for seamless loop
                }
                if (MageMovement.getAnim().GetBool("isDamaged") == true && MageMovement.getAnim().GetBool("isTouchingFloor") == false && MageMovement.getAnim().GetBool("isMoving") == false) // Damage animation state
                {
                    gameObject.transform.Translate(direction * speed * Time.deltaTime); // Movement
                }
                else
                {
                    gameObject.transform.Translate(-direction * speed * Time.deltaTime); // Movement
                }
            }
            
        }
        
    }
}
