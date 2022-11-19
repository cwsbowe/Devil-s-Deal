using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerEnemyAttack : MonoBehaviour
{
    public float attackTime;
    public int attackDamage;
    float cummulativeTime;
    bool timerActive;
    Collider player;
    GameObject zombieAnimator;


    void Start(){
        timerActive = false;
        zombieAnimator = transform.GetChild(0).gameObject;
    }
    void Update(){
        if(timerActive == true){
            cummulativeTime += Time.deltaTime;
        } else {
            cummulativeTime = 0;
        }
        if(player != null){
            if(cummulativeTime > attackTime){
                cummulativeTime = 0;
                Attack();
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            print("Player entered enemy hitbox");
            timerActive = true;
            player = other;
        }        
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            timerActive = false;
            cummulativeTime = 0;
        }       
    }
    void Attack(){
        if(player != null){
            if(GetComponent<Health>().hasDiedb != true){
                print("attacking");
                Health healthscript = player.GetComponent<Health>();
                healthscript.health -= attackDamage;
                zombieAnimator.GetComponent<Animator>().SetTrigger("Attack");
            }
            
        }
    }
}
