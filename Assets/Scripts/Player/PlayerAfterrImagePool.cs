﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterrImagePool : MonoBehaviour
{
    [SerializeField]
    private GameObject afterImagePrafabs;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static PlayerAfterrImagePool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    public void GrowPool()
    {
        for(int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(afterImagePrafabs);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
    public GameObject GetFromPool()
    {
        if(availableObjects.Count == 0)
        {
            GrowPool();
        }
        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }
}
