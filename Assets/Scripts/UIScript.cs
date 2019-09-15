using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Transform playerTR;
    public Transform BP1TR;
    public Transform BP2TR;
    public Transform BP3TR;

    // Start is called before the first frame update
    void Start()
    {
        playerTR = GameObject.Find("Player").GetComponent<Transform>();
        BP1TR = GameObject.Find("BP1").GetComponent<Transform>();
        BP2TR = GameObject.Find("BP2").GetComponent<Transform>();
        BP3TR = GameObject.Find("BP3").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerTR.position, BP1TR.position) < 30f)
        {
            Debug.Log("Getting warmer!");
        }
    }
}
