using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour {
    public int equippedIndex; //starts at 0
    public int numberOfWeapons = 1;

    public void Unequip() {
        gameObject.transform.GetChild(equippedIndex).gameObject.SetActive(false);
    }

    public void Equip(int index) {
        equippedIndex = index;
        gameObject.transform.GetChild(index).gameObject.SetActive(true);

    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.F) && numberOfWeapons > 1) {
            Unequip();
            bool changed = false;
            for (int i = equippedIndex + 1; i < gameObject.transform.childCount; i++) {
                if (gameObject.transform.GetChild(i).GetComponent<BuyGun>().owned) {
                    Equip(equippedIndex + 1);
                    changed = true;
                    break;
                }
            }
            if (!changed) {
                Equip(0);
            }
        }
    }
}
