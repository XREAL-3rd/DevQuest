using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CoinData", menuName = "CoinScriptable/CreateCoinData", order = int.MaxValue)]

public class CoinData : ScriptableObject
{
    [SerializeField]
   public Material material;
}
