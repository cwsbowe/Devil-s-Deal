using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulDisplay : MonoBehaviour {
    public GameObject player;

    void Update() {
        gameObject.GetComponent<Text>().text = "Souls: " + player.GetComponent<SoulCount>().souls;
    }
}
