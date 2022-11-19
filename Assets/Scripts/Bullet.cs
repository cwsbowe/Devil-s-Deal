using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage;
    public int piercingCount;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Terrain" ) {
            Destroy(gameObject);
        }
        if(other.tag == "Enemy"){
            piercingCount -=1;
            other.GetComponent<Health>().health -= damage;
        }
        if(piercingCount == 0){
            Destroy(gameObject);
        }
    }
    
}
