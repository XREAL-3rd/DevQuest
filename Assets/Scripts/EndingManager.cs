using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public static EndingManager main;

    public int targetremain;
    //List<Target> targetlist = new List<Target>();

    public GameObject ending;


    void Awake()
    {
        main = this;
        //targets.GetComponentsInChildren<Target>(false, targetlist);
        targetremain = GameObject.Find("Targets").transform.childCount;
    }

    public void removemsg()
	{
        targetremain--;
        if (targetremain <= 0) ending.SetActive(true);
	}
}
