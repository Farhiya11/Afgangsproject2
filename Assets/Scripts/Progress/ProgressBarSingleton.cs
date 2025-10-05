using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarSingleton : MonoBehaviour
{
    private static ProgressBarSingleton instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
