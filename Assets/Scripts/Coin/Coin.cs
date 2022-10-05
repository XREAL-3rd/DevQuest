using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{
    public CoinData coinData;

    public GameObject player;
    public GameObject coin;
    public int coins;
    private bool trigger = false;
    public TextMeshProUGUI n_coins;

    void Start()
    {
        GetComponent<MeshRenderer>().material = coinData.material;
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
        // coin ���� ���� 1 ����
        coins = PlayerPrefs.GetInt("coins");
        coins += 1;
        PlayerPrefs.SetInt("coins", coins);

        Debug.Log(PlayerPrefs.GetInt("coins"));

        // ���� coin ���ֱ�
        Destroy(coin);
    }
}
