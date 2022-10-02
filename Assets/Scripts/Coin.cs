using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public GameObject player;
    public GameObject coin;
    public int coins;
    private bool trigger = false;
    public TextMeshProUGUI n_coins;

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
