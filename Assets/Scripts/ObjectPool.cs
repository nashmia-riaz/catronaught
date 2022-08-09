using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> objectPool = new List<GameObject>();

    [SerializeField]
    protected GameObject objectPrefab;

    [SerializeField]
    protected int objectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize();
    }

    public virtual void Initialize()
    {

    }

    public virtual GameObject GetObject()
    {
        foreach(GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return null;
    }

    public virtual void SpawnNewObject() { }
    public virtual void SpawnNewObject(Vector3 position)
    {
        GameObject obj = GetObject();
        obj.SetActive(true);
        obj.transform.position = position;
    }

    public virtual void SpawnNewObject(Vector3 position, GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = position;
    }

    public void DespawnObject(GameObject obj)
    {
        Debug.Log("Despawn object");
        obj.SetActive(false);
    }
}
