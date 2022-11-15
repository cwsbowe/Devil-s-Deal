using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
    public GameObject player;

    void Update() {
        gameObject.GetComponent<Text>().text = "Health: " + player.GetComponent<Health>().health.ToString();
    }
}
