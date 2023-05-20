using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement health;
    public GameOverScript gameoverscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth == 0)
            gameOver();


    }
    private void gameOver()
    {
        gameoverscript.gameObject.SetActive(true);

    }
}
