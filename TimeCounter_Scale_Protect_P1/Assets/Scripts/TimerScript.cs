using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    // variables
    public float timer = 0.0f;
    public Text elapsedtime;
 

    // references
  
    
   
    // Update is called once per frame
    void Update()
    {
       

        timer += Time.deltaTime;
        updateTimerUI();

    }

    void updateTimerUI()
    {
        elapsedtime.text = "TIMER: " + returnFormatedTime();
    }

 


    public string returnFormatedTime()
    {
        int seconds = Mathf.FloorToInt(timer % 60);
        int minutes = Mathf.FloorToInt(timer / 60);

        return string.Format("{00:00}:{1:00}", minutes, seconds);
    }


}
