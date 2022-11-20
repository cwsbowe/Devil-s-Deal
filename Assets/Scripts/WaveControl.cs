using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int waveNumber;
    public GameObject sunlight;
    private GameObject day;
    private GameObject night;
    private GameObject bloodMoon;
    public int WaveTime;
    public int safeTime;
    public GameObject announcementBar;
    public GameObject enemyHolder;
    public float percentageSpawnRateChange;
    private float cummulativeTime;
    public bool waveActive;
    private bool announcementBarActive;



    void Start(){
        announcementBarActive = false;
        GetComponent<EnemySpawn>().spawning = true;
        sunlight = night;
        waveNumber = 1;
        waveActive = true;
        ShowAnnouncement("Wave " + waveNumber);
        print("beginning wave 1");
        ShowAnnouncement("You have " + parseTimeToText(WaveTime) + " to survive");
    }
    void Update()
    {   
        //increment wavetimer
        cummulativeTime += Time.deltaTime;

        //check if its time for state change

        //wave time over
        if(waveActive && cummulativeTime >= WaveTime){
            cummulativeTime = 0;
            GetComponent<EnemySpawn>().spawning = false;
            waveActive = false;
            if(waveNumber % 5 == 0){
                ShowAnnouncement("Devishly good");
                sunlight = bloodMoon;
            } else {
                ShowAnnouncement("You survived another night");
                sunlight = day;
            }
            
                
        }

        //safe time over
        if(!waveActive && cummulativeTime >= WaveTime){
            GetComponent<EnemySpawn>().spawnRate = GetComponent<EnemySpawn>().spawnRate * (1-(percentageSpawnRateChange/100));
            cummulativeTime = 0;
            waveActive = true;
            GetComponent<EnemySpawn>().spawning = true;
            sunlight = night;
            waveNumber +=1;
            ShowAnnouncement("Wave " + waveNumber);
            ShowAnnouncement("You have " + parseTimeToText(WaveTime) + " to survive");
        }
        
    }
    string parseTimeToText(int seconds){
        int minutes = seconds / 60;
        int displaySeconds = seconds % 60;
        return "" +minutes +":"+displaySeconds;
    }

    IEnumerator AnnouncementTimer(string text,float showtime)
    {   
        print("trying to show " + text);
        float letterShowtime = 0.1f;
        if(announcementBarActive){
            print("waiting for announcer");
            yield return new WaitUntil(() => !announcementBarActive);
            print("announcer freed up");
        }
        announcementBarActive = true;
        for (int i = 0; i < text.Length; i++) {
            announcementBar.GetComponent<Text>().text +=text[i];
            yield return new WaitForSeconds(letterShowtime);
        }
        yield return new WaitForSeconds(showtime);
        announcementBar.GetComponent<Text>().text = "";
        print("hiding announcement");
        announcementBarActive = false;
        
    }

    void ShowAnnouncement(string text){
        
        StartCoroutine(AnnouncementTimer(text,3));
        
    }
}
