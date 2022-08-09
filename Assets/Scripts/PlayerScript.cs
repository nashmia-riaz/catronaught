using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    bool rotateAntiClockwise = false;

    [SerializeField]
    float RPM;

    [SerializeField]
    [Range(0, 0.1f)]
    float thrusterForce;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, RPM * Time.deltaTime* (rotateAntiClockwise ? 1 : -1));
        transform.position += transform.up * thrusterForce;
    }

    public void RotateClockwise()
    {
        rotateAntiClockwise = false;
    }

    public void RotateAntiClockwise()
    {
        rotateAntiClockwise = true;
    }
}
