using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControl : MonoBehaviour
{
    public GameObject spawner;
    public bool doWeThinkWaveActive;
    // Start is called before the first frame update
    void Start()
    {  
        doWeThinkWaveActive = false;
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
    }
    void setNight(){
        GetComponent<Light>().intensity = 0.1f;
        transform.rotation = Quaternion.Euler(-11,0,0);
        GetComponent<Light>().color = Color.black;
    }

    void setBloodMoon(){
        GetComponent<Light>().intensity = 4;
        transform.rotation = Quaternion.Euler(30,0,0);
        GetComponent<Light>().color = Color.red;
    }
    /*
    void initialiseLights(){
        Light defaultLight = GetComponent<Light>();
        //day
        day = new GameObject();
        day.AddComponent<Light>();
        day.transform.rotation = Quaternion.Euler(30,0,0);
        day.GetComponent<Light>().color = Color.white;
        day.GetComponent<Light>().intensity = 2;
        //night
        night = new GameObject();
        night.AddComponent<Light>();
        night.transform.rotation = Quaternion.Euler(-8,0,0);
        night.GetComponent<Light>().color = Color.black;
        night.GetComponent<Light>().intensity = 0.1f;
        //night
        bloodMoon = new GameObject();
        bloodMoon.AddComponent<Light>();
        bloodMoon.transform.rotation = Quaternion.Euler(90,0,0);
        bloodMoon.GetComponent<Light>().color = Color.red;
        bloodMoon.GetComponent<Light>().intensity = 5f;
    } */
}
