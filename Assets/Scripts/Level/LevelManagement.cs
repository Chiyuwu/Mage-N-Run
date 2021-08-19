using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    static LevelManagement instanceRef;

    [SerializeField] GameObject counter;
    [SerializeField] GameObject timer;
    static float score = 1000; 
    static Text counterLabel;
    static Text timerLabel;
    float seconds = 0; 
    float minutes = 0;
    float hours = 0;

    float time = 0;

    static bool mayCalculate = true;

    public static void setCollectableCount(int amount)
    {
        score += amount; // Add 30 points to counter
        setCounter(); //Counter displays updated points
    }

    public static float getCollectableCount()
    {
        return score; // Gets current collectable count
    }

    static void setCounter()
    {
        counterLabel.text = string.Format("{0:0}", getCollectableCount());  //Count number into String --> display
    }

    public static void setMayCalculate(bool value)
    {
        mayCalculate = value;
    }

    bool getMayCalculate()
    {
        return mayCalculate;
    }

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
        mayCalculate = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            score = 1000f;
        }
        if (getMayCalculate())
        {
            timerLabel = timer.GetComponent<Text>(); //Get text
            timerLabel.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds); //Set format for timer
            counterLabel = counter.GetComponent<Text>(); // Get text for counter
            setCounter(); //display current counter
        }
        
    }

    private void FixedUpdate()
    {
        if(getMayCalculate())
        {
            Debug.Log("calc");
            time += Time.deltaTime; //Add one second per update cycle
            seconds = Mathf.FloorToInt(time % 60); // Divide by 60 and get remains 
            minutes = Mathf.FloorToInt(time / 60); // Divide by 60
            hours = Mathf.FloorToInt(time / 3600); // Divide by 3600
            timerLabel.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds); // Convert timer numbers into 'special' string

            if(score > 0)
            {
                score -= Time.deltaTime;
            }
        
            counterLabel.text = string.Format("{0:0}", getCollectableCount());  //Count number into String --> display
        }
        
    }
}
