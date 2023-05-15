using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownTimer : MonoBehaviour
{
    public float countdownValue = 3; 
    public Text countdownText;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            countdownValue -= Time.deltaTime;
            countdownText.text =  returnFormatedTime().ToString("0");
             if (countdownValue <= 0)
            {
            countdownValue = 0;
            countdownText.text = string.Empty;
             }


    }
    public float returnFormatedTime()
    {
        
        return countdownValue % 60;
    }
}
