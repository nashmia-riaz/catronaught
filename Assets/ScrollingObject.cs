using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    [SerializeField]
    float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered " + collision.name);
        if (collision.tag == "MainCamera")
            GameManager.instance.ScrolledOutOfView(gameObject);
        else if (collision.tag == "Destroy")
            GameManager.instance.DespawnObject(gameObject);
    }
}