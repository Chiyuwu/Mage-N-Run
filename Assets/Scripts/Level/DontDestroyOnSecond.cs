using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DontDestroyOnSecond : MonoBehaviour
{
    static DontDestroyOnSecond instanceRef;


    
    private void Awake()
    {   
        if (instanceRef == null) 
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instanceRef != this)
        {
            Destroy(gameObject); // If LevelUI is already existing --> destroy copy
        }

    }


}
