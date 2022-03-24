using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemySlow : Enemy
{
    void Update()
    {
        time += Time.deltaTime;
        seconds = (int)(time % 60);
        playerAlive = FindObjectsOfType<Player>().Length;
        if (playerAlive != 0)
        {
            Move();
            DestroyIfBelow10();
            AddSpeed();
        }
        else
        {
            GameOver();
        }
    }

    // POLUMORPHISM
    private new void Move()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed / 2);
    }
}
