using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllingScripts : MonoBehaviour
{
    [SerializeField] private bool isGameStart;
    public CubeController cubeScript;
    public CountdownTimer counttimerScript;
    public TimerScript elapsedtimeScript ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
            isGameStart = true;
        else if (Input.GetKey(KeyCode.M))
            isGameStart = false;
        if (isGameStart)
        {
            cubeScript.enabled = true;
            counttimerScript.enabled = true;
            elapsedtimeScript.enabled = true;
        }
        else
        {
            cubeScript.enabled = false;
            counttimerScript.enabled = false;
            elapsedtimeScript.enabled = false;
        }
        
    }
}
