﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int BPCount;

    public bool BP1Active = true;
    public bool BP2Active = true;
    public bool BP3Active = true;

    public TextMeshProUGUI LeftUIText;
    public TextMeshProUGUI RightUIText;

    public Transform playerTR;
    public Transform BP1TR;
    public Transform BP2TR;
    public Transform BP3TR;
    public Transform spaceshipTR;

    // Start is called before the first frame update
    void Start()
    {
        LeftUIText = GameObject.Find("LeftUIText").GetComponent<TextMeshProUGUI>();
        RightUIText = GameObject.Find("RightUIText").GetComponent<TextMeshProUGUI>();

        playerTR = GameObject.Find("Player").GetComponent<Transform>();
        BP1TR = GameObject.Find("BP1").GetComponent<Transform>();
        BP2TR = GameObject.Find("BP2").GetComponent<Transform>();
        BP3TR = GameObject.Find("BP3").GetComponent<Transform>();
        spaceshipTR = GameObject.Find("Spaceship").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        NavigationGuide();
        RightUIText.text = "Body Parts Found: " + BPCount;
    }

    void NavigationGuide()
    {
        if (Vector3.Distance(playerTR.position, spaceshipTR.position) > 10f && BPCount < 3)
        {
            if (Vector3.Distance(playerTR.position, BP1TR.position) < 50f && BP1Active == true)
            {
                LeftUIText.text = "A body part has been detected within jagged mountains!";
            }
            else if (Vector3.Distance(playerTR.position, BP2TR.position) < 50f && BP2Active == true)
            {
                LeftUIText.text = "A body part has been detected within lumpy mountains!";
            }
            else if (Vector3.Distance(playerTR.position, BP3TR.position) < 50f && BP3Active == true)
            {
                LeftUIText.text = "A body part has been detected within impassable mountains!";
            }
            else
            {
                LeftUIText.text = "You have to find your scattered body parts! Your radar isn't close enough to detect anything, look around!";
            }
        }
        else if (Vector3.Distance(playerTR.position, spaceshipTR.position) < 10f && BPCount < 3)
        {
            LeftUIText.text = "You're still missing body parts, you can't leave yet!";
        }
        else if (Vector3.Distance(playerTR.position, spaceshipTR.position) > 10f && BPCount == 3)
        {
            LeftUIText.text = "You have found all your body parts! Head back to your ship!";
        }
        else if (Vector3.Distance(playerTR.position, spaceshipTR.position) < 10f && BPCount == 3)
        {
            LeftUIText.text = "Press Space to Blast Off!";
            if (Input.GetKeyDown(KeyCode.Space))
            {

            }
        }
    }
}