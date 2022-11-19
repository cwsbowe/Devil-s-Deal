using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

    public GameObject lightSource;
    private bool checkDay = false;
    public AudioSource birds;


    void Update() {
        if (lightSource.GetComponent<DayControl>().day == 0 && checkDay) {
            checkDay = false;
            StartCoroutine(PlaySoundForTime(birds, 0.5f, 1f, 2.5f, new Vector3(0, 0, 0)));
        } else if (lightSource.GetComponent<DayControl>().day == 1 && !checkDay) {
            checkDay = true;

        }
    }

    IEnumerator PlaySoundForTime(AudioSource ac, float timeFadeIn, float timeFadeOut, float timePlay, Vector3 location) {
        ac.Play();
        ac.volume = 0;
        while (ac.volume < 1) {
            ac.volume += Time.deltaTime / timeFadeIn;
        }
        float currentTime = Time.deltaTime;
        yield return new WaitForSeconds(timePlay);
        while (ac.volume > 0) {
            ac.volume -= (Time.deltaTime - currentTime) / timeFadeOut;
        }
        ac.Stop();

    }
}
