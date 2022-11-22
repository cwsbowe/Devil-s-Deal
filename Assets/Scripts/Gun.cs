using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform barrelEnd;
    public int ammo; //total ammo
    public int maxAmmo;
    public float bulletSpeed = 30;
    public float bulletExpiry = 3;
    public bool automatic;
    private float lastFired;
    public int bulletdamage;
    public float fireRate;
    private float timeSinceLastFire;
    public int clipSize; //max in clip
    public int clip; //total in clip
    public int piercing;


    void Start(){
        timeSinceLastFire = 0;
        clip = clipSize;
    }

    void Reload(){
        int neededAmmo = clipSize - clip;
        if(neededAmmo <= ammo){
            clip = clipSize;
            ammo -= neededAmmo;
        } else {
            clip = ammo;
            ammo = 0;
        }
         
    }
    public void IncreaseGunDamage(int damageIncrease){
        bulletdamage += damageIncrease;
    }
    public void IncreaseFireRate(float increasePercent){
        fireRate = fireRate * ((100-increasePercent)/100);
    }
    public void IncrementPiercing(){
        piercing +=1;
    }
    public void IncreaseMaxAmmo(){
        maxAmmo +=50;
    }
    void Update() {
        timeSinceLastFire += Time.deltaTime;
        if (Input.GetKey(KeyCode.R) && clip != clipSize && ammo != 0) {
                Reload();
                GetComponent<Animator>().SetTrigger("Reload");
            }
        
        if (automatic) {
            if (Input.GetKey(KeyCode.Mouse0) && timeSinceLastFire > fireRate) {
                lastFired = Time.time;
                Fire(true);
            }else{
                GetComponent<Animator>().SetBool("Shoot",false);
            }
        } else {
            if (Input.GetKeyDown(KeyCode.Mouse0) && timeSinceLastFire > fireRate) {
                Fire(false);
            }
        }
        
    }

    private void Fire(bool Auto) {
        if (clip > 0) {
            clip--;
            gameObject.GetComponent<AudioSource>().Play();
            if(Auto) {
                GetComponent<Animator>().SetBool("Shoot",true);
            } else{
                GetComponent<Animator>().SetTrigger("Shoot");
            }
            timeSinceLastFire = 0;
            GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation);
            bullet.GetComponent<Bullet>().damage = bulletdamage;
            bullet.GetComponent<Bullet>().piercingCount = piercing;
            bullet.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * bulletSpeed, ForceMode.Impulse);
            StartCoroutine(ExpireBullet(bullet, bulletExpiry));
        }
    }

    private IEnumerator ExpireBullet(GameObject bullet, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
