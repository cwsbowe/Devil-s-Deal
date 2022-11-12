using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerEnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public int Speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Vector3 MyLocation = GetComponent<Transform>().position;
        Vector3 PlayerPos = player.GetComponent<Transform>().position;
        Vector3 direction = PlayerPos - MyLocation;
        GetComponent<Transform>().LookAt(new Vector3(PlayerPos.x,0,PlayerPos.z));
        Vector3 newvelocity = new Vector3(direction.normalized.x * Speed,0,direction.normalized.z * Speed);
        rb.velocity = newvelocity;
    }
}
