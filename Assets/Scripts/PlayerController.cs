using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gm;

    CharacterController cc;

    public float playerSpeed;
    [Range(0.1f, 1)]
    public float walkSpeed;
    [Range(0.1f, 1)]
    public float runSpeed;
    [Range(1, 5)]
    public float playerRotate = 1;
    [Range(0.1f, 1)]
    public float gravity = 1;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            cc.Move(transform.forward * playerSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            cc.Move(-transform.forward * playerSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            cc.transform.Rotate(0f, -playerRotate, 0f);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            cc.transform.Rotate(0f, playerRotate, 0f);
        }

        cc.Move(-transform.up * gravity);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            playerSpeed = runSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BodyPart")
        {
            other.gameObject.SetActive(false);
            gm.BPCount++;
            Debug.Log("Body Parts Found: "+gm.BPCount);

            if (other.gameObject.name == "BP1")
            {
                gm.BP1Active = false;
            }
            if (other.gameObject.name == "BP2")
            {
                gm.BP2Active = false;
            }
            if (other.gameObject.name == "BP3")
            {
                gm.BP3Active = false;
            }
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
