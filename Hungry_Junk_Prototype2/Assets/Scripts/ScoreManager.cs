using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int star = 0;
    public Text scoreUI;
    public Text starUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increaseScore()
    {
        score++;
        AwardStar();
        updateGUI();

    }
    public void AwardStar()
    {
        int scoreThreshold = 3;
        if (score % scoreThreshold == 0)
        {
            star++;
        }
       

    }
    public void updateGUI()
    {
        scoreUI.text = "Score : " + score;
        starUI.text = "Stars : " + star;

       
    }
}
