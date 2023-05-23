using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeSpawn : MonoBehaviour
{
    public int totalKnives = 10;
    public GameObject knifePrefab;
    private GameObject[] knives;
    private int index = 1;
    // Start is called before the first frame update
    void Start()
    {
         knives = new GameObject[totalKnives];
        spawnKnives();

    }

    void spawnKnives()
    {
        // Instantiating knives in the array and setting them false
        for (int i = 0; i < totalKnives; i++)
        {
            knives[i] = Instantiate(knifePrefab, transform.position, Quaternion.identity);
            if(i!=0)
                knives[i].SetActive(false);
        }
    }
    public void knifesetActive()
    {
        //Activate the knife when we throw the previous knife and increment in index for next knife.
        if (index < totalKnives)
        {
            knives[index].SetActive(true);
            index++;
        }
    }

}
