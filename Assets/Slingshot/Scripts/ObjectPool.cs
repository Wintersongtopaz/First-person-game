using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //The prefab to instantiate
    public GameObject prefab;
    //How many instances to store in the pool
    public int instanceCount = 10;
    // Stored instances
    public List<GameObject> instances = new List<GameObject>();
    //Next index to pull from the pool
    public int index = 0;

    void Awake()
    {
        SpawnInstances();
    }

    void SpawnInstances()
    {
        for(int i = 0; i < instanceCount; i++)
        {
            GameObject newInstance = Instantiate(prefab);
            newInstance.SetActive(false);
            instances.Add(newInstance);
        }
    }
  

    public GameObject GetInstance()
    {
        //Get return instance
        GameObject returnInstance = instances[index++];
        //Wrap around index
        if (index >= instanceCount) index = 0;
        return returnInstance;
    }
}
