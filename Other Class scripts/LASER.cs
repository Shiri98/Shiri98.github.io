using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LASER : MonoBehaviour {
    
    public Transform seeker;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray douche = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(douche.origin, douche.direction * 100f);

        RaycastHit douchehit = new RaycastHit();

        if(Physics.Raycast(douche, out douchehit , 100f))
        {
           if (Input.GetMouseButtonDown(0))
            {
                //Destroy(douchehit.collider.gameObject);
                if(douchehit.rigidbody != null)
                douchehit.rigidbody.AddForce(Random.insideUnitSphere*10000f);
            }
           if (Input.GetMouseButtonDown(1))
            {
                
                Instantiate(seeker,douchehit.point,Quaternion.identity); 
            }

            if (Input.GetMouseButtonDown(2))
            {
                Destroy(douchehit.collider.gameObject);
            }
        }
	}
}
