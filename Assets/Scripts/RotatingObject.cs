using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField]
    float RPM;

    [SerializeField]
    bool rotateClockwise;

    // Start is called before the first frame update
    void OnEnable()
    {
        rotateClockwise = Random.Range(0, 2) == 0 ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isGamePaused) return;

        transform.Rotate(0, 0, RPM * Time.deltaTime * (rotateClockwise ? 1 : -1));
    }
}
