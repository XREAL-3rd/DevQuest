using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimUI : MonoBehaviour {
    private RectTransform rectTransform;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update() {
        rectTransform.anchoredPosition = Input.mousePosition;
    }
}
