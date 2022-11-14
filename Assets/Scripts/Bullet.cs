using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Terrain" ^ other.tag == "Enemy") {
            if(other.tag == "Enemy"){
                other.GetComponent<Health>().health -= damage;
            }
            Destroy(gameObject);
            
        }
    }
    
}
