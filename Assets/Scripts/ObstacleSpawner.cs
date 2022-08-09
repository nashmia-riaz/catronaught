using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    RandomObjectPool planetSpawner, asteroidSpawner,debrisSpawner;

    [SerializeField]
    List<GameObject> currentObjects;

    [SerializeField]
    Vector3 screenSize;

    public static ObstacleSpawner instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        screenSize = Camera.main.ScreenToWorldPoint(
            new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));

        planetSpawner.Initialize();
        asteroidSpawner.Initialize();
        debrisSpawner.Initialize();

        SpawnPlanet();
        //SpawnDebris();
    }
    public void SpawnObstacle()
    {
        Debug.Log("Spawn object");
        float randomizer = Random.value;

        if (randomizer < 0.5f)
            SpawnPlanet();
        else if (randomizer < 0.85)
            SpawnAsteroid();
        else
            SpawnDebris();
    }

    void SpawnPlanet() {
        Vector3 position = Vector3.zero;
        GameObject obj = planetSpawner.GetObject();
        obj.SetActive(true);
        float scale = Random.RandomRange(0.5f, 1f);
        obj.transform.localScale = Vector3.one * scale;

        obj.GetComponent<SpriteRenderer>().color = new Vector4(
            Random.Range(0.5f, 1f),
            Random.Range(0.5f, 1f),
            Random.Range(0.5f, 1f),
            255);

        if (currentObjects.Count > 0)
        {
            GameObject lastObj = currentObjects[currentObjects.Count - 1];
            Vector2 objSize = obj.GetComponent<ObstacleScript>().collider.bounds.size;

            Vector2 lastObjSize = Vector2.zero;
            lastObjSize = lastObj.GetComponent<ObstacleScript>().collider.bounds.size;

            float x, y = 0;
            if (lastObj.transform.position.y > 0)
                y = -screenSize.y;
            else
                y = screenSize.y;

            x = lastObj.transform.position.x + lastObjSize.x / 2 + objSize.x / 2;

            position = new Vector3(x, y, 0);
        }
        else
        {
            position = new Vector3(screenSize.x, screenSize.y, 0);
        }

        obj.transform.position = position;
        currentObjects.Add(obj);
    }

    void SpawnAsteroid()
    {
        Vector3 position = Vector3.zero;
        GameObject obj = asteroidSpawner.GetObject();
        obj.SetActive(true);
        float scale = Random.RandomRange(0.1f, 0.2f);
        obj.transform.localScale = Vector3.one * scale;

        float rotation = Random.Range(0f, 360f);
        obj.transform.eulerAngles = new Vector3(0, 0, rotation);

        if (currentObjects.Count > 0)
        {
            GameObject lastObj = currentObjects[currentObjects.Count - 1];
            Vector2 objSize = obj.GetComponent<ObstacleScript>().collider.bounds.size;

            Vector2 lastObjSize = Vector2.zero;
            lastObjSize = lastObj.GetComponent<ObstacleScript>().collider.bounds.size;

            float x, y = 0; 
            x = lastObj.transform.position.x + lastObjSize.x / 2 + objSize.x / 2 + objSize.y / 2;

            position = new Vector3(x, 0, 0);
        }
        else
        {
            position = new Vector3(0, 0, 0);
        }

        obj.transform.position = position;

        currentObjects.Add(obj);
    }

    void SpawnDebris() {
        Vector3 position = Vector3.zero;
        GameObject obj = debrisSpawner.GetObject();
        obj.SetActive(true);
        float scale = Random.RandomRange(1f, 1.5f);
        obj.transform.localScale = Vector3.one * scale;

        float rotation = Random.Range(0f, 360f);
        obj.transform.eulerAngles = new Vector3(0, 0, rotation);

        if (currentObjects.Count > 0)
        {
            GameObject lastObj = currentObjects[currentObjects.Count - 1];
            Vector2 objSize = obj.GetComponent<ObstacleScript>().collider.bounds.size;

            Vector2 lastObjSize = Vector2.zero;
            lastObjSize = lastObj.GetComponent<ObstacleScript>().collider.bounds.size;

            float x, y = 0;
            x = lastObj.transform.position.x + lastObjSize.x / 2 + objSize.x / 2 + objSize.y / 2;

            position = new Vector3(x, 0, 0);
        }
        else
        {
            position = new Vector3(0, 0, 0);
        }

        obj.transform.position = position;

        currentObjects.Add(obj);
    }
}
