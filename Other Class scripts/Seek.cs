using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

    Rigidbody rb;
    Vector3 targetPos;
    public GameObject targetobj;
   
    public float thrust = 10f;

    public object Gameobject { get; private set; }

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (targetobj != null)
        {
            targetPos = targetobj.transform.position;
            Vector3 direction = Vector3.Normalize(targetPos - transform.position);
            rb.AddForce(direction * thrust);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        
        //Destroy(gameObject);
        if (col.gameObject == targetobj)
        {
            Destroy(col.gameObject);
        }
    }
}

