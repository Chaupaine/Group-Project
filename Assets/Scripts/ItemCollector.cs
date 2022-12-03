using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public static ItemCollector access;
    public int coins;
    //GameControl.control.levelC = levelCoins;
    [SerializeField] TextMeshProUGUI coinsText;

    void Start()
    {
        coins = GameControl.control.previousScore;
    }

    void Update()
    {
        coinsText.text = "Coins: " + coins;
    
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            //coinsText.text = "Coins: " + GameControl.control.score;
            Debug.Log("Coins: " + coins);
        }
    }

}
