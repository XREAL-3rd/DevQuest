using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager main;
    public List<GameObject> targets;
    [System.NonSerialized] public float time;
    [System.NonSerialized] public bool isGameOver;

    //non-lazy, non-DDOL
    private void Awake() {
        if (main != null && main != this)
            Destroy(gameObject);
        else
            main = this;

        SetTargets();
        time = 0;
        isGameOver = false;

        DontDestroyOnLoad(gameObject);
    }

    private void SetTargets() {
        targets = new List<GameObject>();
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject obj in temp)
            targets.Add(obj);
    }

    public static void TargetDestroyed(GameObject gameObject) {
        main.targets.Remove(gameObject);
        if (main.targets.Count <= 0)
            main.GameOver();
    }

    private void GameOver() {
        main.isGameOver = true;
        SceneManager.LoadScene("GameOverScene");
    }
}