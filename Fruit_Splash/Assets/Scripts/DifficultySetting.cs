using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultySetting : MonoBehaviour
{
    public int difficulty;
    private Button button;
    
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(setDifficulty);

    }

    void setDifficulty() {
        Debug.Log(gameObject.name);

        gameManager.StartGame(difficulty);
    }
}
