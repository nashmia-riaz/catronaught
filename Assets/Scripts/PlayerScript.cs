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
    [Range(0, 0.2f)]
    float thrusterForce;

    bool isPlayerDead = false;

    private void Start()
    {
       Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero); 
        transform.position = new Vector3(bottomLeft.x + gameObject.GetComponent<Collider2D>().bounds.size.x, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlayerDead || GameManager.instance.isGamePaused || GameManager.instance.isGameOver) return;

        transform.Rotate(0, 0, RPM * Time.deltaTime* (rotateAntiClockwise ? 1 : -1));
        transform.position += transform.up * thrusterForce;
    }

    public void RotateClockwise()
    {
        if (isPlayerDead) return;
        rotateAntiClockwise = false;
    }

    public void RotateAntiClockwise()
    {
        if (isPlayerDead) return;
        rotateAntiClockwise = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.isGamePaused || GameManager.instance.isGameOver) return;

        if (collision.gameObject.tag == "Obstacle")
        {
            isPlayerDead = true;
            Vector2 forceDirection = collision.transform.position - transform.position;
            gameObject.GetComponent<Rigidbody2D>().AddForce(-forceDirection * 5, ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 300f;
            GameManager.instance.GameOver();
        }
    }

}
