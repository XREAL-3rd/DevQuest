using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject { 
    void RegisterObserver(Observer _observer); 
    void RemoveObserver(Observer _observer);

    void NotifyObservers(); 
} 

public interface Observer  {
    void ObserverUpdate(float hp); 
}