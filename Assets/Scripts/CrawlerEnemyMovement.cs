using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerEnemyMovement : MonoBehaviour {
    Rigidbody rb;
    public GameObject player;
    public Vector3 lookAt;
    GameObject zombAnimator;
    public int Speed;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
        zombAnimator = transform.GetChild(0).gameObject;
    }

    void FixedUpdate() {   
        if(GetComponent<Health>().hasDiedb != true){
            if (player != null) {
                zombAnimator.GetComponent<Animator>().SetBool("isWalking", true);
                Vector3 MyLocation = GetComponent<Transform>().position;
                Vector3 PlayerPos = player.GetComponent<Transform>().position;
                Vector3 direction = PlayerPos - MyLocation;
                lookAt = new Vector3(PlayerPos.x, 0, PlayerPos.z);
                GetComponent<Transform>().LookAt(lookAt);
                Vector3 newvelocity = new Vector3(direction.normalized.x * Speed * 10f, MyLocation.y,direction.normalized.z * Speed * 10f);
                rb.AddForce(newvelocity,ForceMode.Force);
            } else {
                zombAnimator.GetComponent<Animator>().SetBool("isWalking", false);
            }
        
        }
        
    }
}
