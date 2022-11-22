using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CrawlerEnemyMovement : MonoBehaviour {
    Rigidbody rb;
    public GameObject player;
    public Vector3 lookAt;
    GameObject zombAnimator;
    public float moveSpeed;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
        zombAnimator = transform.GetChild(0).gameObject;
    }

    void FixedUpdate() {   
        if(GetComponent<Health>().hasDiedb != true){
            if (player != null) {
                GetComponent<NavMeshAgent>().SetDestination(player.GetComponent<Transform>().position);
                GetComponent<NavMeshAgent>().speed = moveSpeed;
                zombAnimator.GetComponent<Animator>().SetBool("isWalking", true);
            } else {
                zombAnimator.GetComponent<Animator>().SetBool("isWalking", false);
            }
        
        }
        
    }
}
