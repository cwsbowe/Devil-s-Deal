using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGun : MonoBehaviour {
    
    // public GameObject gun;
    public GameObject weapon;
    public GameObject player;
    public int price;
    private GameObject newGun;

    public void CreateGun() {
        if (player.GetComponent<SoulCount>().souls >= price) {
            player.GetComponent<SoulCount>().souls -= price;
            weapon.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.SetActive(true);
            gameObject.transform.SetAsFirstSibling();
        }
    }
}
