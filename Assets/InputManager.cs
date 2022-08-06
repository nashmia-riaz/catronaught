using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.RotateAnticlockwise();
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameManager.instance.RotateClockwise();
        }
    }
}
