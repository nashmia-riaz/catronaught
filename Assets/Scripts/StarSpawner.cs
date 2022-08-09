using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : ObjectPool
{
    List<GameObject> currentObjects = new List<GameObject>();

    private void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        for (int i = 0; i < objectsToSpawn; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            objectPool.Add(obj);
            obj.transform.SetParent(transform);
        }

        SpawnNewObject();
    }

    public override void SpawnNewObject()
    {
        GameObject obj = GetObject();
        obj.SetActive(true);

        if (currentObjects.Count <= 1)
        {
            obj.transform.position = Vector2.zero;
        }
        else
        {
            GameObject lastCurrentObject = currentObjects[currentObjects.Count - 1];
            float lengthOfObject = lastCurrentObject.GetComponent<BoxCollider2D>().bounds.size.x;
            obj.transform.position = lastCurrentObject.transform.position + new Vector3(1, 0, 0) * lengthOfObject;
        }
        currentObjects.Add(obj);
    }
}
