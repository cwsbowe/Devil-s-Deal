using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SecondTriggerScript : MonoBehaviour
{
    public GameObject Command;
    public GameObject Panel;
    public GameObject TutorialController;
    public GameObject VendorPanel;
    public GameObject DevilPanel;
    public bool vendorAccessed;
    public GameObject DevilVendor;
    public GameObject En1;
    public GameObject En2;
    public GameObject En3;
    public GameObject HealthBar;
    public GameObject Weapon;
    public GameObject Pistol;
    private bool weaponChanged;
    private bool EnemiesActive;
    private bool enemiesDead;
    private bool unTriggered;
    private bool doneWithVendor;
    public GameObject spotlight;
    private bool acceptDealBool;
    // Start is called before the first frame update
    void Start()
    {   
        vendorAccessed = false;
        weaponChanged = false;
        EnemiesActive = false;
        enemiesDead = false;
        unTriggered = true;
        doneWithVendor= false;
        acceptDealBool=false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(VendorPanel.activeSelf){
            vendorAccessed = true;
        }
        if(!VendorPanel.activeSelf && vendorAccessed && !doneWithVendor){
            TutorialController.GetComponent<TextGuide>().MakeAnnouncement("Only the basics. Useful if you're low on supplies",2);
            TutorialController.GetComponent<TextGuide>().MakeAnnouncement("Speaking of supplies here is a pistol",2);
            Pistol.GetComponent<BuyWeapon>().Buy();
            Weapon.GetComponent<ChangeWeapon>().ChangeWeaponFunction();
            StartCoroutine(NextPanelOBJ("Click F to change weapon"));
            doneWithVendor = true;
        }
        if(Weapon.GetComponent<ChangeWeapon>().equippedIndex != 0){
            weaponChanged = true;
        }
        if(vendorAccessed && weaponChanged && !EnemiesActive){
            TutorialController.GetComponent<TextGuide>().MakeAnnouncement("Time to utilise these skills",2);
            StartCoroutine(NextPanelOBJ("Defend yourself - Click R to Reload"));
            HealthBar.SetActive(true);
            En1.SetActive(true);
            En2.SetActive(true);
            En3.SetActive(true);
            EnemiesActive = true;
        }
        if(En1 == null && En2 == null && En3 ==null && !enemiesDead){
            TutorialController.GetComponent<TextGuide>().MakeAnnouncement("Looks like you picked up some souls \n Lets make a deal?",2);
            StartCoroutine(NextPanelOBJ("Click V near the demon to interact"));
            DevilVendor.SetActive(true);
            enemiesDead = true;
        }

        if(DevilPanel.activeSelf && !acceptDealBool){
            StartCoroutine(NextPanelOBJ("Accept the devils deal"));
            acceptDealBool = true;
        }
        

        
    }

    void OnTriggerEnter(){
        if(unTriggered){
            spotlight.SetActive(true);
            StartCoroutine(NextPanelOBJ("Click V next to the box to interact with it"));
            TutorialController.GetComponent<TextGuide>().MakeAnnouncement("Lucky you, you found a vendor box",2);
            unTriggered = false;
            spotlight.SetActive(true);
        }
    }
    IEnumerator NextPanelOBJ(string text){
        Panel.GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(2);
        Panel.GetComponent<Image>().color = Color.white;
        Command.GetComponent<Text>().text = text;
        
    }
    
}
