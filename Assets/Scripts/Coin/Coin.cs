using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{
    public CoinData coinData;
    public Material material;

    public GameObject player;
    public GameObject coin;
    public int coins;
    private bool trigger = false;
    public TextMeshProUGUI n_coins;

    void Start()
    {
        material = coinData.material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            trigger = true;
        }
    }

    void Update()
    {
        if (trigger)
        {
            GetCoin();
        }

        n_coins.text = "COINS X " + PlayerPrefs.GetInt("coins");
    }

    void GetCoin()
    {
        // coin 먹은 개수 1 증가
        coins = PlayerPrefs.GetInt("coins");
        coins += 1;
        PlayerPrefs.SetInt("coins", coins);

        Debug.Log(PlayerPrefs.GetInt("coins"));

        // 먹은 coin 없애기
        Destroy(coin);
    }
}
