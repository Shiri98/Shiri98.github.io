using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    public float RotateSpeed;
    public Text branch;
    public Text Wintext;
    private int branchcount;
    public int TreeSurgerySucess;

    float acc = 0;
    float vel = 0;

    public GameObject Dedtree;
    public GameObject LiveTree;
    public GameObject sanic;
    public float gravity;
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        branchcount = 0;
        SetCountText();
    }
    void Update()
    {
        //Rotates the player (doesn't work too well considering i have to freeze the player's x,y and z rotations)
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        
        //Causes player movement
        moveDirection.z = Input.GetAxis("Vertical") * speed;
        moveDirection.x = Input.GetAxis("Horizontal") * speed;

        //player jumping mechanic
        if (controller.isGrounded && vel < 0)
        {
            vel = 0;

        }

        if (Input.GetButtonDown("Jump"))
        {
            if (controller.isGrounded)
            {
                //print("I'm Jumping");
                acc += jumpSpeed;
                sanic.GetComponent<AudioSource>().Play();
            }
        }

        acc -= gravity;
        vel += acc;
        acc = 0;

        moveDirection.y = vel;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        //Branch and Log Pick ups
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            branchcount = branchcount + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        branch.text = "Tree Parts Found: " + branchcount.ToString();
        if(branchcount == TreeSurgerySucess)
        {
            Dedtree.gameObject.SetActive(false);
            LiveTree.gameObject.SetActive(true);
            Wintext.text = "SURGERY COMPLETE";
        }
    }
}