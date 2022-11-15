using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{      
    public float deathTime;
    private float cummulativeDeathTime;
    public int health;
    public bool hasDiedb;
    Animator zombAnimator;
    // Start is called before the first frame update
    void Start()
    {   
        hasDiedb = false;
        zombAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            if(tag == "Enemy"){
                if(hasDiedb == false){
                    hasDiedb = true;
                    zombAnimator.SetTrigger("hasDied");}                             
                cummulativeDeathTime += Time.deltaTime;
                if(cummulativeDeathTime >= deathTime){
                    Destroy(gameObject);
                }
            } else {
                Destroy(gameObject);
            }
            
        }
    }
}
