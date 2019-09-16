using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    float rotationY;

    // Update is called once per frame
    void Update()
    {
        rotationY += 0.001f;
        gameObject.transform.Rotate(0f, rotationY, 0f);
    }
}
