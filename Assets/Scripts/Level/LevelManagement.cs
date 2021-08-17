using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{
    [SerializeField] GameObject counter;
    [SerializeField] GameObject timer;
    static int collectableCount = 0; 
    static Text counterLabel;
    static Text timerLabel;
    float seconds = 0; 
    float minutes = 0;
    float hours = 0;

    float time = 0;

    public static void setCollectableCount()
    {
        collectableCount += 30; // Add 30 points to counter
        setCounter(); //Counter displays updated points
    }

    public static int getCollectableCount()
    {
        return collectableCount; // Gets current collectable count
    }

    static void setCounter()
    {
        counterLabel.text = getCollectableCount().ToString(); //Count number into String --> display
    }

    private void Start()
    {
        timerLabel = timer.GetComponent<Text>(); //Get text
        timerLabel.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds); //Set format for timer
        counterLabel = counter.GetComponent<Text>(); // Get text for counter
        setCounter(); //display current counter
    }

    private void FixedUpdate()
    {
        time += Time.deltaTime; //Add one second per update cycle
        seconds = Mathf.FloorToInt(time % 60); // Divide by 60 and get remains 
        minutes = Mathf.FloorToInt(time / 60); // Divide by 60
        hours = Mathf.FloorToInt(time / 3600); // Divide by 3600
        timerLabel.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds); // Convert timer numbers into 'special' string
    }
}
