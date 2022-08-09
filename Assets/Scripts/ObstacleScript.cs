using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public Collider2D collider;

    private void Start()
    {
        collider = gameObject.GetComponentInChildren<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Spawner")
        {
            ObstacleSpawner.instance.SpawnObstacle();
            Debug.Log(gameObject.name + " hit " + collision.name);
        }
        else if (collision.name == "Destroyer")
            transform.parent.GetComponent<ObjectPool>().DespawnObject(gameObject);
    }
}
