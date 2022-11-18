using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform barrelEnd;
    public int ammo;
    public int maxAmmo;
    public float bulletSpeed = 30;
    public float bulletExpiry = 3;
    public bool automatic;
    private float lastFired;

    void Update() {
        if (automatic) {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time - lastFired > 0.1f) {
                lastFired = Time.time;
                Fire();
            }
        } else {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Fire();
            }
        }
    }

    private void Fire() {
        if (ammo > 0) {
            ammo--;
            GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * bulletSpeed, ForceMode.Impulse);
            StartCoroutine(ExpireBullet(bullet, bulletExpiry));
        }
    }

    private IEnumerator ExpireBullet(GameObject bullet, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
