using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl main;

    private readonly List<Target> activeTargets = new List<Target>();

    private void Awake()
    {
        main = this;
    }

    /// <summary>
    /// Add target object to list in game controller
    /// ideal when the target is initialized (OnEnable, Awake, Start)
    /// </summary>
    /// <param name="target">target being added</param>
    public void AddTargetToList(Target target)
    {
        activeTargets.Add(target);
    }

    /// <summary>
    /// Delete target object from the list in game controller
    /// ideal to call when the target is being destroyed
    /// </summary>
    /// <param name="target">target being removed</param>
    public void DeleteTargetFromList(Target target)
    {
        activeTargets.Remove(target);
        
        if (activeTargets.Count == 0)
        {
            EndGame();
        }
    }

    /// <summary>
    /// Ends game when all targets are broken down.
    /// </summary>
    private void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;  
#else
        Application.Quit();
#endif
    }
}
