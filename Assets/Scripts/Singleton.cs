using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<S> : MonoBehaviour where S:Component
{
    private static S instance;

    public static S Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<S>();

                if (instance == null)
                {
                    GameObject gameObject = new GameObject("GameControl");
                    instance = gameObject.AddComponent<S>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as S;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
