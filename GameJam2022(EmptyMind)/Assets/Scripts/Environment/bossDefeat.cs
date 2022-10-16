using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDefeat : MonoBehaviour
{
    int enemiesLeft = 0;
    bool killedAllEnemies = false;

    void Start () {
        enemiesLeft = 1; // or whatever;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print(enemies.Length);
        enemiesLeft = enemies.Length;
        if(enemiesLeft == 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
