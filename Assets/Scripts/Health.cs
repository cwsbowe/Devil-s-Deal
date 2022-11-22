using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {      
    public float deathTime;
    private float cummulativeDeathTime;
    public int health;
    public bool hasDiedb;
    Animator zombAnimator;
    public SpawnSoul souls;
    
    void Start() {   
        hasDiedb = false;
        zombAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    void Update() {
        if (health <= 0) {
            if (tag == "Enemy") {
                if (hasDiedb == false) {
                    hasDiedb = true;
                    GetComponent<AudioSource>().Play();
                    zombAnimator.SetTrigger("hasDied");
                    souls.GenerateSoul();
                    GetComponent<BoxCollider>().enabled = false;
                    GetComponent<CapsuleCollider>().enabled = false;
                }
                cummulativeDeathTime += Time.deltaTime;
                if (cummulativeDeathTime >= deathTime) {
                    Destroy(gameObject);
                }
            } else {
                SceneManager.LoadScene("Start");
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            
        }
    }
}
