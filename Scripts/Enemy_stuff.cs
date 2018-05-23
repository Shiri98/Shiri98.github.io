using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_stuff : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    Vector3 playerStart;

    void Start()
    {
        //Player starting position
        playerStart = player.transform.position;
    }

    void Update()
    {
        //Manual Reset
        if (Input.GetKeyDown("r"))
        {
            player.transform.position = playerStart;
            GetComponent<AudioSource>().Play();
            Start();
        }
    }

    //Collision reset
    void OnCollisionEnter(Collision Obs)
    {
        if (Obs.gameObject == enemy1)
        {
            player.transform.position = playerStart;
            GetComponent<AudioSource>().Play();
            Start();
        }

        if (Obs.gameObject == enemy2)
        {
            player.transform.position = playerStart;
            GetComponent<AudioSource>().Play();
            Start();
        }

        if (Obs.gameObject == enemy3)
        {
            player.transform.position = playerStart;
            GetComponent<AudioSource>().Play();
            Start();
        }

        if (Obs.gameObject == enemy4)
        {
            player.transform.position = playerStart;
            GetComponent<AudioSource>().Play();
            Start();
        }

        if (Obs.gameObject == enemy5)
        {
            player.transform.position = playerStart;
            GetComponent<AudioSource>().Play();
            Start();
        }
    }
}
