using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGun : MonoBehaviour {
    public GameObject player;
    public bool owned;
    public int price;
    private GameObject newGun;

    public void Buy() {
        if (player.GetComponent<SoulCount>().souls >= price && !owned) {
            player.GetComponent<SoulCount>().souls -= price;
            owned = true;
            gameObject.transform.parent.GetComponent<ChangeWeapon>().Unequip();
            gameObject.transform.parent.GetComponent<ChangeWeapon>().numberOfWeapons++;
            gameObject.transform.parent.GetComponent<ChangeWeapon>().Equip(transform.GetSiblingIndex());
        }
    }
}
