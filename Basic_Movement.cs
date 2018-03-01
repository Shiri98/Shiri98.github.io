using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basic_Movement : MonoBehaviour {

    public GameObject MyObj;
    public int gridSize = 2;
    public GameObject winspot;
    public int minGrid = 0;
    public int maxGrid = 8;
    public int minEnemy = 0;
    public int maxEnemy = 8;
    Vector3 playerStart;
    public GameObject background;
    public GameObject [] Enemy;
    public int score = 0;
    public Text scoreText;
    public float enemyspeed = 10;
    int randoX, randoZ;

    // Use this for initialization
    void Start()
    {
        playerStart = MyObj.transform.position;
        RandoPosi();
        winspot.transform.position = new Vector3(randoX, winspot.transform.position.y, randoZ);
        scoreText.text = "score:" + score.ToString();

        for (int i = 0; i < Enemy.Length; i++)
        {
            RandoPosi();
            while (randoX == winspot.transform.position.x && randoZ == winspot.transform.position.z)
            {
                RandoPosi();
            }
            Enemy[i].transform.position = new Vector3(randoX, Enemy[i].transform.position.y, randoZ);
            // winspot.transform.position = new Vector3(Random.Range(2f, 8f), 2, Random.Range(2f, 8f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayMovement();
        CheckBoundary();
        CheckWin();
        CheckEnemy();
        EnemyMovement();
        //Enemy.transform.position = ;
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i].GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
        }
    }

    void RandoPosi()
    {
        randoX = (int)Random.Range(minEnemy / gridSize, maxEnemy / gridSize);
        randoX *= gridSize;
        randoZ = (int)Random.Range(minEnemy / gridSize, maxEnemy / gridSize);
        randoZ *= gridSize;

    }
    void PlayMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MyObj.transform.position += new Vector3(0, 0, gridSize);
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MyObj.transform.position -= new Vector3(0, 0, gridSize);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MyObj.transform.position += new Vector3(gridSize, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MyObj.transform.position -= new Vector3(gridSize, 0, 0);
        }
    }

    void CheckBoundary()
    {
        if (MyObj.transform.position.z > 8)
        {
            MyObj.transform.position = new Vector3(MyObj.transform.position.x, MyObj.transform.position.y, minGrid);
            MyObj.GetComponent<AudioSource>().Play();
        }

        if (MyObj.transform.position.z < 0)
        {
            MyObj.transform.position = new Vector3(MyObj.transform.position.x, MyObj.transform.position.y, maxGrid);
            MyObj.GetComponent<AudioSource>().Play();
        }

        if (MyObj.transform.position.x > 6)
        {
            MyObj.transform.position = new Vector3(minGrid, MyObj.transform.position.y, MyObj.transform.position.z);
            MyObj.GetComponent<AudioSource>().Play();
        }

        if (MyObj.transform.position.x < 0)
        {
            MyObj.transform.position = new Vector3(6, MyObj.transform.position.y, MyObj.transform.position.z);
            MyObj.GetComponent<AudioSource>().Play();
        }
    }

    void CheckWin()
    {
        if (MyObj.transform.position == winspot.transform.position)
        {
            MyObj.transform.position = playerStart;
            winspot.GetComponent<AudioSource>().Play();
            //MyObj.transform.localScale *= 1.01f;
            score++;
            background.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f,1f,0f,1f,0f,1f);
            Start();
        }

    }

    void CheckEnemy() {
        for (int i = 0; i < Enemy.Length; i++){
            if (MyObj.transform.position == Enemy[i].transform.position)
            {
                MyObj.transform.position = playerStart;
                background.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
                Enemy[i].GetComponent<AudioSource>().Play();
                score--;
                Start();
            }
        }
    }

    void EnemyMovement()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i].transform.position += new Vector3(gridSize / enemyspeed, 0f, 0f);

            if (Enemy[i].transform.position.x > maxEnemy)
            {
                Enemy[i].transform.position = new Vector3(minEnemy, Enemy[i].transform.position.y, Enemy[i].transform.position.z - gridSize);
            }

            if (Enemy[i].transform.position.z < minEnemy)
            {
                Enemy[i].transform.position = new Vector3(minEnemy, Enemy[i].transform.position.y, maxEnemy);
            }
        }
    }
}
