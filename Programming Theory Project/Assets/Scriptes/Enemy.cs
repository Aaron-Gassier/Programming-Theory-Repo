using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    protected float speed = 6.0f;
    protected GameObject player;
    protected Rigidbody enemyRb;
    [SerializeField]
    protected int playerAlive;
    protected float xzRange = 15;
    protected float time;
    protected int seconds;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
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

    protected void GameOver()
    {
        Debug.Log("Game Over you survived: " + seconds + " seconds");
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
    }

    protected void AddSpeed()
    {
        speed += 0.1f;
    }
    

    protected void Move()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

    protected void DestroyIfBelow10()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    protected void CheckRange()
    {
        if (transform.position.x < -xzRange)
        {
            transform.position = new Vector3(-xzRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xzRange)
        {
            transform.position = new Vector3(xzRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -xzRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -xzRange);
        }

        if (transform.position.z > xzRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xzRange);
        }
    }
}
