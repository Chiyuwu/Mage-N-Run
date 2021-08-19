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

    static float time = 0;

    static bool mayCalculate = true; //counter and score can count further

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
        return mayCalculate; //Calculate can .... calculate 
    }
    public static void setScore( float value1, float value2)
    {
        score = value1; 
        time = value2; 
    }

    public static void resetScore(float value1, float value2)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            setScore(value1, value2); //Reset score counter ONLY at level1 start
        }
    }


    private void Awake()
    {

        if (instanceRef == null)
        {
            instanceRef = this;
            DontDestroyOnLoad(gameObject);  //LevelManager is a unique game object
        }
        else if (instanceRef != this)
        {
            Destroy(gameObject);//Destroy any copies
        }



    }

    private void Start()
    {
        
        mayCalculate = true;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            setScore(1000, 0);
            score = 1000f;
            setMayCalculate(true);
        } //Score resets to 1000 at lvl1 start 
        if (getMayCalculate()) //If counter si allowed to count, then update graphics
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
            time += Time.deltaTime; //Add one second per update cycle
            seconds = Mathf.FloorToInt(time % 60); // Divide by 60 and get remains 
            minutes = Mathf.FloorToInt(time / 60); // Divide by 60
            hours = Mathf.FloorToInt(time / 3600); // Divide by 3600
            timerLabel.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds); // Convert timer numbers into 'special' string

            if(score > 0)
            {
                score -= Time.deltaTime; //no negative count
            }
        
            counterLabel.text = string.Format("{0:0}", getCollectableCount());  //Count number into String --> display
        }
        
    }
}
