using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPool : ObjectPool
{
    [SerializeField]
    int maxObjectTypes;

    [SerializeField]
    GameObject[] objectPrefabs;

    [SerializeField]
    List<GameObject>[] ObjectPools;

    public override void Initialize()
    {
        ObjectPools = new List<GameObject>[maxObjectTypes];

        for (int i = 0; i < maxObjectTypes; i++)
        {
            ObjectPools[i] = new List<GameObject>();
            for (int j = 0; j < objectsToSpawn; j++)
            {
                GameObject obj = Instantiate(objectPrefabs[i]);
                obj.SetActive(false);
                obj.transform.SetParent(transform);
                ObjectPools[i].Add(obj);
            }
        }
    }

    public override GameObject GetObject()
    {
        int randomizer = Random.Range(0, maxObjectTypes);
        Debug.Log(randomizer);
        foreach (GameObject obj in ObjectPools[randomizer])
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return GetObject();

        return null;
    }
}
