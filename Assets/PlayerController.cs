using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;

    [Range(0.1f, 1)]
    public float playerSpeed;
    [Range(1, 5)]
    public float playerRotate = 1;
    [Range(0.1f, 1)]
    public float gravity = 1;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //SimpleMovement();
        CCMove();
    }

    void CCMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cc.Move(transform.forward * playerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cc.Move(-transform.forward * playerSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            cc.transform.Rotate(0f, -playerRotate, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cc.transform.Rotate(0f, playerRotate, 0f);
        }

        cc.Move(-transform.up * gravity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            Debug.Log("Triggered!");
        }
    }

    void SimpleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, 1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -1f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 1f, 0f);
        }
    }
}
