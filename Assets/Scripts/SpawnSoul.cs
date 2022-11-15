using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoul : MonoBehaviour {
    public int soulValue;
    public GameObject soul;

    public void GenerateSoul() {
        int noOfSouls = Random.Range(1, soulValue);
        for (int i = 0; i < noOfSouls; i++) {
            Vector3 pos = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + 0.5f, transform.position.z + Random.Range(-0.5f, 0.5f));
            Instantiate(soul, pos, Quaternion.identity);
        }
    }
}
