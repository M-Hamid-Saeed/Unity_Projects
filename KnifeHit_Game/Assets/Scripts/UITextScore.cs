using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITextScore : MonoBehaviour
{
    public Text scoreUI;
    public Text knivesUI;
    public Text won;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void setUI(int score, int knives)
    {
        scoreUI.text = "Score :" + score;
        knivesUI.text = "Knives: " + knives;    
    }
    public void winnerUI()
    {

        won.text = "YOU WON";
    }
}
