using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TMP_Text displayText;

    private float currentTime;

    void Update()
    {
	    currentTime += Time.deltaTime;
	
        //convert the current time to minutes and seconds
	    float minutes = Mathf.FloorToInt(currentTime / 60);
	    float seconds = currentTime % 60;

        //display timer
        displayText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }
 
}
