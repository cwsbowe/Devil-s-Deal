using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFirstZombies : MonoBehaviour
{   
    public GameObject zomb1;
    public GameObject zomb2;
    public GameObject zomb3;
    public GameObject Command;
    public GameObject Panel;
    private bool triggered;
    public GameObject TutorialController;
    // Start is called before the first frame update
    void Start(){
        triggered = false;
    }
    void OnTriggerEnter(){
        zomb1.SetActive(true);
        zomb2.SetActive(true);
        zomb3.SetActive(true);
        StartCoroutine(NextPanelOBJ("Use Space to jump and traverse the alley"));
        TutorialController.GetComponent<TextGuide>().MakeAnnouncement("That is if you aren't eaten first",2);
    }
    IEnumerator NextPanelOBJ(string text){
        Panel.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(5);
        Panel.GetComponent<Image>().color = Color.white;
        Command.GetComponent<Text>().text = text;
        
    }
}

