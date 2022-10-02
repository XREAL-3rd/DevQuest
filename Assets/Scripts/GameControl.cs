using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameControl main;
    [HideInInspector] public PlayerControl player;
    [HideInInspector] public Camera cam;
    [HideInInspector] public CameraControl camc;    
    [HideInInspector] public Target[] targets;


    private float timeValue = 90f;

    private void Awake(){
        main = this;
        player = GameObject.FindObjectOfType<PlayerControl>();
        cam = Camera.main;
        camc = GameObject.FindObjectOfType<CameraControl>();
        targets = GameObject.FindObjectsOfType<Target>();
    }

    private void Update(){
        CheckTimeOut();
        CheckTargets();
    }

    private void CheckTargets(){
        targets = GameObject.FindObjectsOfType<Target>();
        if(targets == null){
            Debug.Log("Clear");
        }
    }

    private void CheckTimeOut(){
        if (timeValue > 0f) {
            timeValue -= Time.deltaTime;
        }
        else {
            timeValue = 0f;
            GameEnd();
        }
    }

    public void GameEnd(){
        targets = GameObject.FindObjectsOfType<Target>();
        if(targets == null){
            Debug.Log("Clear");
        }
        else{
            Debug.Log("Failed");
        }
    }
}
