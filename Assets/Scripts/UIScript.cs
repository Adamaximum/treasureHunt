using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
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

        playerTR = GameObject.Find("Player").GetComponent<Transform>();
        BP1TR = GameObject.Find("BP1").GetComponent<Transform>();
        BP2TR = GameObject.Find("BP2").GetComponent<Transform>();
        BP3TR = GameObject.Find("BP3").GetComponent<Transform>();
        spaceshipTR = GameObject.Find("Spaceship").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerTR.position, spaceshipTR.position) > 10f)
        {
            if (Vector3.Distance(playerTR.position, BP1TR.position) < 50f)
            {
                LeftUIText.text = "A body part has been detected within jagged mountains!";
            }
            else if (Vector3.Distance(playerTR.position, BP2TR.position) < 50f)
            {
                LeftUIText.text = "A body part has been detected within lumpy mountains!";
            }
            else if (Vector3.Distance(playerTR.position, BP3TR.position) < 50f)
            {
                LeftUIText.text = "A body part has been detected within impassable mountains!";
            }
        }
        else if(Vector3.Distance(playerTR.position, spaceshipTR.position) < 10f)
        {
            LeftUIText.text = "You're still missing body parts, you can't leave yet!";
        }
        
        else
        {
            LeftUIText.text = "You have to find your scattered body parts! Your radar isn't close enough to detect anything, look around!";
        }
    }
}
