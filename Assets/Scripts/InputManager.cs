using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isGamePaused) return;

        if (Input.GetMouseButtonDown(0))
        {
            if(!GameManager.instance.hasStarted)
                GameManager.instance.StartGame();

            GameManager.instance.RotateAnticlockwise();
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameManager.instance.RotateClockwise();
        }
    }
}
