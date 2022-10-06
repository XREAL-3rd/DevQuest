using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Subject : MonoBehaviour, Subject {
    private List<Observer> observers = new List<Observer>();
    private Dictionary<Observer, float> targetHps = new Dictionary<Observer, float>();
    private const float TARGET_HP = 100f;

    public void RegisterObserver(Observer observer) {
        this.observers.Add(observer);
        targetHps.Add(observer, TARGET_HP);
    }

    public void RemoveObserver(Observer observer) {
        this.observers.Remove(observer);
        targetHps.Remove(observer);
    }

    public void NotifyObservers() {
        float hp;
        for (int i = 0; i < this.observers.Count; i++) {
            if (targetHps.TryGetValue(this.observers[i], out hp))
                this.observers[i].ObserverUpdate(hp);
        }
    }

    public void Changed(Dictionary<Observer, float> changes) {
        foreach (KeyValuePair<Observer, float> pair in changes) {
            targetHps[pair.Key] = pair.Value;
        }
        this.NotifyObservers();
    }
}