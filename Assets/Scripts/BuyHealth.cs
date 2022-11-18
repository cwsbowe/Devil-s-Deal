using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHealth : MonoBehaviour {
    public GameObject player;
    public int price;

    public void Buy() {
        if (player.GetComponent<SoulCount>().souls >= price) {
            player.GetComponent<SoulCount>().souls -= price;
            player.GetComponent<Health>().health = 100;
        }
    }
}
