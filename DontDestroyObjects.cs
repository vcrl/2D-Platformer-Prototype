using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjects : MonoBehaviour
{
    public GameObject[] objects;
    void Start()
    {
        foreach (var obj in objects)
        {
            DontDestroyOnLoad(obj);
        }
    }
}
