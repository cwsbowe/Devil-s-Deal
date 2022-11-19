using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyAmmo : MonoBehaviour {
    public GameObject player;
    public GameObject weapon;
    public int price;

    public void Buy() {
        if (player.GetComponent<SoulCount>().souls >= price) {
            player.GetComponent<SoulCount>().souls -= price;
            for (int i = 0; i < weapon.transform.childCount; i++) {
                if (weapon.transform.GetChild(i).GetComponent<BuyWeapon>().owned) {
                    if(weapon.transform.GetChild(i).tag == "gun"){
                        weapon.transform.GetChild(i).GetComponent<Gun>().ammo = weapon.transform.GetChild(i).GetComponent<Gun>().maxAmmo;
                    }
                }
            }
        }
    }
}