using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControl : MonoBehaviour {
    public GameObject spawner;
    public bool doWeThinkWaveActive;
    public GameObject DevilVendor;
    public GameObject RegularVendor;
    public int day;
    public GameObject SpawnPoints;

    // Start is called before the first frame update
    void Start() {
        day = 0;
        doWeThinkWaveActive = false;
        DevilVendor.SetActive(false);
        RegularVendor.SetActive(false);
    }

    // Update is called once per frame
    void Update() {   
        if(spawner.GetComponent<WaveControl>().waveActive && !doWeThinkWaveActive){
            doWeThinkWaveActive = true;
            setNight();
            day = 1;
        } else if(!spawner.GetComponent<WaveControl>().waveActive && doWeThinkWaveActive){
            doWeThinkWaveActive = false;
            if(spawner.GetComponent<WaveControl>().waveNumber % 5 == 0){
                setBloodMoon();
                day = 2;
            } else{
                setDay();
                day = 0;
            }
            
        }
        
    }

    void setDay() {
        transform.rotation = Quaternion.Euler(30,0,0);
        GetComponent<Light>().color = Color.white;
        GetComponent<Light>().intensity = 2;
        spawnRegularVendor();
    }
    void setNight() {
        GetComponent<Light>().intensity = 0.1f;
        transform.rotation = Quaternion.Euler(-11,0,0);
        GetComponent<Light>().color = Color.black;
        RegularVendor.GetComponent<VendorInteract>().ExitPanel();
        RegularVendor.SetActive(false);        
        DevilVendor.GetComponent<VendorInteract>().ExitPanel();
        DevilVendor.SetActive(false);
        
    }

    void setBloodMoon() {
        GetComponent<Light>().intensity = 4;
        transform.rotation = Quaternion.Euler(30,0,0);
        GetComponent<Light>().color = Color.red;
        spawnRegularVendor();
        DevilVendor.SetActive(true);
    }

    void spawnRegularVendor(){
        RegularVendor.SetActive(true);
        int spawnPointCount = SpawnPoints.transform.childCount;
        RegularVendor.transform.position = SpawnPoints.transform.GetChild(Random.Range(0,spawnPointCount)).position;
    }
}
