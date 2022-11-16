using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soul : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<SoulCount>().souls++;
            Destroy(gameObject);
        }
    }
}
