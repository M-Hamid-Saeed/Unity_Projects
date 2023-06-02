using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyrb;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        enemyrb.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
