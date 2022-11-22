using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextGuide : MonoBehaviour
{
    public bool announcementBarActive;
    public GameObject announcementBar;
    public GameObject ObjectiveBarPanel;
    public GameObject thecamera;
    public GameObject weapon;
    public GameObject devilPanel;
    
    void Update(){

    }

    

    void Start(){
        MakeAnnouncement("Ooh i haven't found a new survivor in a while",3);
        MakeAnnouncement("I could really make use of your skills",3);
    }

    public void MakeAnnouncement(string text,float showtime){
        StartCoroutine(AnnouncementTimer(text,showtime));
    }

    // Update is called once per frame
    IEnumerator AnnouncementTimer(string text,float showtime)
    {   
        print("trying to show " + text);
        float letterShowtime = 0.05f;
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

    public void endTutorial(){
        thecamera.transform.position = new Vector3(0,1000,0);
        weapon.SetActive(false);
        ObjectiveBarPanel.SetActive(false);
        devilPanel.SetActive(false);
        MakeAnnouncement("You Never Had A Choice",3);
        MakeAnnouncement("Perhaps I will reward you if you \n last another five days",3);
        StartCoroutine(loadMainGame("Main"));
    }

    public IEnumerator loadMainGame(string sceneID){
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(sceneID);
    }
}
