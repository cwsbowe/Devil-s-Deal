using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveDisplay : MonoBehaviour
{
    public GameObject spawner;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Wave: "+ spawner.GetComponent<WaveControl>().waveNumber;
        
    }
}
