using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public float scaleSpeed;
    public float moveSpeed;
    public float scaleChange;
    public float powerStrength;
   


    void Update()
    {
        moveWave();
        if (transform.localPosition.x > 8)
            Destroy(gameObject);

    }

    void moveWave()
    {
        float newScaleX = transform.localScale.x + scaleSpeed * scaleChange * Time.deltaTime;
        float newScaleY = transform.localScale.y + scaleSpeed * scaleChange * Time.deltaTime;


        transform.localScale = new Vector2(newScaleX, newScaleY);

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemyrb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 forcedirection = (collision.gameObject.transform.position - transform.position).normalized;

            enemyrb.AddForce(forcedirection * powerStrength, ForceMode2D.Impulse);

        }
    }

}
