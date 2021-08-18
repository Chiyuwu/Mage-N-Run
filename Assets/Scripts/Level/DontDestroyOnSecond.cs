using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnSecond : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
