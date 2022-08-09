using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    PlayerScript player;

    [SerializeField]
    StarSpawner starSpawner;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateClockwise()
    {
        player.RotateClockwise();
    }

    public void RotateAnticlockwise()
    {
        player.RotateAntiClockwise();
    }

    public void DespawnObject(GameObject obj)
    {
        if (obj.tag == "Stars")
        {
            starSpawner.DespawnObject(obj);
        }
    }

    public void ScrolledOutOfView(GameObject obj)
    {
        if(obj.tag == "Stars")
        {
            starSpawner.SpawnNewObject();
        }
    }
}
