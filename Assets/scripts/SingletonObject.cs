using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SingletonObject : MonoBehaviour
{
    private static SingletonObject instance;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this instance as the singleton
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this duplicate instance
            Destroy(gameObject);
        }
    }
}