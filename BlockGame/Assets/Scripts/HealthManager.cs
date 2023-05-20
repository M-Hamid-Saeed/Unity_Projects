using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public Text healthScore;
    // Start is called before the first frame update
    private void Start()
    {
        setMaxHealth(100);
    }
    public void setHealth(int health)
    {
        slider.value = health;
        healthScore.text = health.ToString();

    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
