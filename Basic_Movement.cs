using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Movement : MonoBehaviour {

    public GameObject MyObj;
    public int gridSize = 2;
    public GameObject winspot;
    public int minGrid = 0;
    public int maxGrid = 8;
    Vector3 playerStart;
    public GameObject background;
    public GameObject Enemy;


	// Use this for initialization
	void Start () {
        playerStart = MyObj.transform.position;
        int randoX = (int)Random.Range(minGrid,maxGrid / gridSize);
        Debug.Log(randoX);
        randoX *= gridSize;
        int randoZ = (int)Random.Range(minGrid, maxGrid / gridSize);
        Debug.Log(randoZ);
        randoZ *= gridSize;
        winspot.transform.position = new Vector3(randoX, winspot.transform.position.y, randoZ);


        // winspot.transform.position = new Vector3(Random.Range(2f, 8f), 2, Random.Range(2f, 8f));
    }
	
	// Update is called once per frame
	void Update () {
        PlayMovement();
        CheckBoundary();
        CheckWin();

        Enemy.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 0f, 1f, 0f, 1f);
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
            MyObj.transform.position = new Vector3(MyObj.transform.position.x, MyObj.transform.position.y, 0);
        }

        if (MyObj.transform.position.z < 0)
        {
            MyObj.transform.position = new Vector3(MyObj.transform.position.x, MyObj.transform.position.y, 8);
        }

        if (MyObj.transform.position.x > 6)
        {
            MyObj.transform.position = new Vector3(0, MyObj.transform.position.y, MyObj.transform.position.z);
        }

        if (MyObj.transform.position.x < 0)
        {
            MyObj.transform.position = new Vector3(6, MyObj.transform.position.y, MyObj.transform.position.z);
        }
    }

    void CheckWin()
    {
        if (MyObj.transform.position == winspot.transform.position)
        {
            MyObj.transform.position = playerStart;
            //MyObj.transform.localScale *= 1.01f;
            background.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f,1f,0f,1f,0f,1f);
            Start();
        }

    }
}
