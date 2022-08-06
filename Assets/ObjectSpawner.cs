using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> objectPool = new List<GameObject>();

    [SerializeField]
    List<GameObject> currentObjects = new List<GameObject>();

    [SerializeField]
    GameObject objectPrefab;

    [SerializeField]
    int objectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < objectsToSpawn; i++)
        {
            GameObject obj =Instantiate(objectPrefab);
            obj.SetActive(false);
            objectPool.Add(obj);
            obj.transform.SetParent(transform);
        }

        SpawnNewObject();
    }

    GameObject GetObject()
    {
        foreach(GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return null;
    }

    public void SpawnNewObject()
    {
        Debug.Log("Spawning new object");
        GameObject obj = GetObject();
        obj.SetActive(true);
        currentObjects.Add(obj);

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
    }

    public void DespawnObject(GameObject obj)
    {
        obj.SetActive(false);
        currentObjects.Remove(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
