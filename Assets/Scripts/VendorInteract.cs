using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorInteract : MonoBehaviour
{
    private bool inRange = false;
    private bool panelOpen = false;
    public GameObject panel;
    public GameObject weapon;
    public GameObject TextPanel; // interact message
    public GameObject Crosshair;
    private bool crosshairWasActive;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            inRange = true;
            TextPanel.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            TextPanel.SetActive(false);
            inRange = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            panel.SetActive(false);
            panelOpen = false;
            weapon.SetActive(true);
        }
    }

    void Update() {
        if (inRange && Input.GetKeyDown(KeyCode.V)) {

            if (!panelOpen) {
                crosshairWasActive = Crosshair.activeSelf;
                Crosshair.SetActive(false);
                Cursor.lockState = CursorLockMode.Confined;
                TextPanel.SetActive(false);
                Cursor.visible = true;
                panelOpen = true;
                GetComponent<AudioSource>().Play();
                panel.SetActive(true);
                weapon.SetActive(false);
            } else {
                ExitPanel();
                TextPanel.SetActive(false);
            }
        }
    }
    public void ExitPanel(){
        if(panelOpen){
            if(crosshairWasActive){Crosshair.SetActive(true);}
                Cursor.lockState = CursorLockMode.Locked;
                
                Cursor.visible = false;
                panelOpen = false;
                panel.SetActive(false);
                weapon.SetActive(true);
        }
    }
}

