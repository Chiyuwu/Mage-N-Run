using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMage : MonoBehaviour
{
    [SerializeField] Transform mage;
    void Update()
    {
        if(mage)
        {
            gameObject.transform.position = new Vector3(mage.position.x, mage.position.y + 4, -10); // Camera follows Mage position along x and y (with offset)
        }
       
    }
}
