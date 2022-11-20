using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

    public GameObject lightSource;
    private bool checkDay = false;
    public AudioSource birds;
    public AudioSource day;
    public AudioSource night;
    public AudioSource bloodMoon;

    void Start() {
        day.volume = 0.3f;
        night.volume = 0.3f;
    }

    void Update() {
        if (lightSource.GetComponent<DayControl>().day == 0 && checkDay) {
            night.Stop();
            checkDay = false;
            StartCoroutine(PlaySoundForTime(birds, 0.5f, 4f, 2.5f, new Vector3(0, 0, 0)));
            day.Play();
        } else if (lightSource.GetComponent<DayControl>().day == 1 && !checkDay) {
            day.Stop();
            checkDay = true;
            night.Play();
        } else if (lightSource.GetComponent<DayControl>().day == 2 && !checkDay) {
            day.Stop();
            checkDay = true;
            bloodMoon.Play();
        }
    }

    IEnumerator PlaySoundForTime(AudioSource ac, float timeFadeIn, float timeFadeOut, float timePlay, Vector3 location) {
        ac.Play();
        ac.volume = 0;
        float currentTime = 0;
        while (currentTime < timeFadeIn) {
            currentTime += Time.deltaTime;
            ac.volume = Mathf.Lerp(0, 1, currentTime / timeFadeIn);
        }
        yield return new WaitForSeconds(timePlay);
        currentTime = 0;
        while (currentTime < timeFadeOut) {
            currentTime += Time.deltaTime;
            ac.volume = Mathf.Lerp(1, 0, currentTime / timeFadeOut);
        }
        ac.Pause();
    }
}
