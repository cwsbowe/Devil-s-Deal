using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform barrelEnd;
    public float bulletSpeed = 30;
    public float bulletExpiry = 3;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Fire();
        }
    }

    private void Fire() {
        GameObject bullet = Instantiate(bulletPrefab);
        // Physics.IgnoreCollision(bullet.GetComponent<Collider>(), barrelEnd.parent.GetComponent<Collider>()); //ignore collision with barrel of gun
        bullet.transform.position =  barrelEnd.position;
        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        bullet.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(ExpireBullet(bullet, bulletExpiry));
    }

    private IEnumerator ExpireBullet(GameObject bullet, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
