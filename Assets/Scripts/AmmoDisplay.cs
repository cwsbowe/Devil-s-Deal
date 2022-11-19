using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {
    public GameObject weapon;

    void Update() {
        if(weapon.transform.GetChild(weapon.GetComponent<ChangeWeapon>().equippedIndex).tag == "Gun"){
            gameObject.GetComponent<Text>().text = "Ammo: " + weapon.transform.GetChild(weapon.GetComponent<ChangeWeapon>().equippedIndex).GetComponent<Gun>().clip + "/" + weapon.transform.GetChild(weapon.GetComponent<ChangeWeapon>().equippedIndex).GetComponent<Gun>().ammo;
        } else {
            gameObject.GetComponent<Text>().text = "";
        }
    }
}
