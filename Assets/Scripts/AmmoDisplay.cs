using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {
    public GameObject weapon;

    void Update() {
        gameObject.GetComponent<Text>().text = "Ammo: " + weapon.transform.GetChild(weapon.GetComponent<ChangeWeapon>().equippedIndex).GetComponent<Gun>().ammo + "/" + weapon.transform.GetChild(weapon.GetComponent<ChangeWeapon>().equippedIndex).GetComponent<Gun>().maxAmmo;
    }
}
