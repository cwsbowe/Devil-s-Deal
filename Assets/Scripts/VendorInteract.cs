using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorInteract : MonoBehaviour
{
    private bool inRange = false;
    private bool panelOpen = false;
    public GameObject panel;
    public GameObject weapon;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            inRange = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
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
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                panelOpen = true;
                panel.SetActive(true);
                weapon.SetActive(false);
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                panelOpen = false;
                panel.SetActive(false);
                weapon.SetActive(true);
            }
        }
    }
}
