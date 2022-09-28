using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    int cnt;

    void Start()
    {
        cnt = 0;
    }

    public void Hit()
    {
        cnt += 1;
        Material mat = gameObject.GetComponent<MeshRenderer>().material;
        mat.color = Color.Lerp(mat.color, Color.red, 0.5f); // 명중 시 빨간색으로 변화
        if (cnt == 3)
        {
            Destroy (gameObject);
        }
    }
}
