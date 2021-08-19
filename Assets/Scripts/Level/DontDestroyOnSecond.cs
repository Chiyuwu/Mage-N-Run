using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnSecond : MonoBehaviour
{
    [SerializeField] string ObjectName;

    private void Start()
    {
        //gameObject.transform.root.Find(ObjectName);
        Debug.Log(gameObject.transform.root.Find(ObjectName).gameObject.name);

        if (SceneManager.GetActiveScene().buildIndex == 0 )//|| gameObject.transform.root.Find(ObjectName))
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
