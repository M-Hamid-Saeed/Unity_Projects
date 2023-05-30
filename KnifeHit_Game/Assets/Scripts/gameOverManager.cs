using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverManager : MonoBehaviour
{
    public GameObject gameoverman;
    // Start is called before the first frame update
   public void RestartButton()
    {
        SceneManager.LoadScene("Main Scene");
        Time.timeScale = 1f;
    }

    public void setactive()
    {
        
        gameoverman.SetActive(true);

    }
}
