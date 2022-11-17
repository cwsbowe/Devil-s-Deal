using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasebatAttack : MonoBehaviour
{
    public bool attackBool;
    public float cooldown;
    public int damage;
    public float knockback;
    // Start is called before the first frame update
    void Start()
    {
        attackBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            meleeAttack();
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Enemy"){
            other.GetComponent<Health>().health -= damage;
        }
        
    }

    void meleeAttack(){
        if(attackBool){
            attackBool = false;
            GetComponent<Animator>().SetTrigger("Attack");
            StartCoroutine(ResetAttackCooldown());
        }
        
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        attackBool = true;
    }
}
