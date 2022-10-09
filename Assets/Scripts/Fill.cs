using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//일반화 시킨 진행 Fill.
public class Fill : MonoBehaviour
{
    private Image back;
    private Image filler;
    private RectTransform backRect;
    private RectTransform fillerRect;
    private Vector2 size;

    public float Value
    {
        set => fillerRect.sizeDelta = new(Mathf.Lerp(0, size.x, value), size.y);
    }

    //설마 Component를 런타임에 바꾸는 사람이 있겠어?
    private void Awake()
    {
        back = GetComponent<Image>();
        backRect = GetComponent<RectTransform>();

        filler = transform.GetChild(0).GetComponent<Image>();
        fillerRect = filler.GetComponent<RectTransform>();
    }

    public void UpdatePos(Vector3 pos, float width, float height)
    {
        backRect.transform.position = pos;
        backRect.sizeDelta = new(width, height);

        //Background Border 설정에 맞춰 Filler 부분에 간격(여백) 적용.
        fillerRect.anchoredPosition = new(-0.5f * width, 0);
        fillerRect.sizeDelta = new(fillerRect.sizeDelta.x * width / size.x, height);

        size.Set(width, height);
    }

    public void Show(bool show)
    {
        back.enabled = show;
        filler.enabled = show;
    }
}