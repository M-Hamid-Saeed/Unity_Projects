using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private float lowerBound = -4.5f;
    private float upperBound = 7.0f;
    public HealthManager healthscript;
    
    public int currentHealth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > upperBound)
            transform.position = new Vector2(upperBound, transform.position.y);
        else if (transform.position.x < lowerBound)
            transform.position = new Vector2(lowerBound, transform.position.y);
        float input = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(Vector2.right * input);
       


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(currentHealth!=0)
            TakeDamage(25);
        StartCoroutine(slowmoeffect());

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthset();
    }
    public void healthset()
    {
        healthscript.setHealth(currentHealth);
    }
    
    IEnumerator slowmoeffect()
    {
        
        float originaltimeScale = Time.timeScale;
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime / 10f;
        yield return new WaitForSeconds(0.1f);

        Time.timeScale = originaltimeScale;
        Time.fixedDeltaTime = Time.fixedDeltaTime * 10f;


    }
    
}

