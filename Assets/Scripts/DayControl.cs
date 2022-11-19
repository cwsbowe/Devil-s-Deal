using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControl : MonoBehaviour
{
    public GameObject spawner;
    public bool doWeThinkWaveActive;
    public GameObject DevilVendor;
    public GameObject RegularVendor;
    // Start is called before the first frame update
    void Start()
    {  
        doWeThinkWaveActive = false;
        DevilVendor.SetActive(false);
        RegularVendor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if(spawner.GetComponent<WaveControl>().waveActive && !doWeThinkWaveActive){
            doWeThinkWaveActive = true;
            setNight();
        } else if(!spawner.GetComponent<WaveControl>().waveActive && doWeThinkWaveActive){
            doWeThinkWaveActive = false;
            setDay();
        }
        
    }

    void setDay(){
        transform.rotation = Quaternion.Euler(30,0,0);
        GetComponent<Light>().color = Color.white;
        GetComponent<Light>().intensity = 2;
        RegularVendor.SetActive(true);
    }
    void setNight(){
        GetComponent<Light>().intensity = 0.1f;
        transform.rotation = Quaternion.Euler(-11,0,0);
        GetComponent<Light>().color = Color.black;
        RegularVendor.SetActive(false);
        DevilVendor.SetActive(false);
    }

    void setBloodMoon(){
        GetComponent<Light>().intensity = 4;
        transform.rotation = Quaternion.Euler(30,0,0);
        GetComponent<Light>().color = Color.red;
        RegularVendor.SetActive(true);
        DevilVendor.SetActive(true);
    }
}
