using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoul : MonoBehaviour {
    public int soulValue;
    public GameObject soul;
    public Vector3 newpos;

    public void GenerateSoul() {
        int noOfSouls = Random.Range(1, soulValue);
        for (int i = 0; i < noOfSouls; i++) {
            newpos = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + 1f, transform.position.z + Random.Range(-0.5f, 0.5f));
            GameObject newSoul = Instantiate(soul);
            newSoul.transform.position = newpos;
            print("new position set");
        }
    }
}
