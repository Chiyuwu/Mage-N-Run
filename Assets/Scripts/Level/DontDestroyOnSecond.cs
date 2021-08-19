using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            Destroy(gameObject);
        }



    }



    private void Start()
    {


        

    
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
            
        }
    
    
    
    }


}
