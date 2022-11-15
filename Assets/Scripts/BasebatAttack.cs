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
            other.GetComponent<Rigidbody>().AddForce((new Vector3(other.transform.position.x,0,other.transform.position.z) - new Vector3(transform.position.x,0,transform.position.z)).normalized*100f*knockback);
        }
        
    }

    void meleeAttack(){
        attackBool = false;
        GetComponent<Animator>().SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        attackBool = true;
    }
}
