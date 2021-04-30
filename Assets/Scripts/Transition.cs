using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public float duration;
    public float pause;
    public GameObject living;
    public GameObject cube;
    public GameObject cantina;
    public GameObject mezz;

    private GameObject currObj;
    private GameObject transObj;
    private float expo;
    private float pauseLeft;
    private bool transing = false;

    void Start() {
        currObj = living;
        transObj = currObj;
        pauseLeft = pause;
    }

    void Update() {
        if (transing) {
            expo = RenderSettings.skybox.GetFloat("_Exposure");

            if (currObj != transObj) {
                if ( expo > Time.deltaTime / duration) {
                    RenderSettings.skybox.SetFloat("_Exposure", expo - Time.deltaTime / duration);
                    expo = expo - Time.deltaTime / duration;
                } else {
                    RenderSettings.skybox.SetFloat("_Exposure", 0f);
                    currObj.SetActive(false);
                    transObj.SetActive(true);
                    if (pauseLeft > 0f) {
                        pauseLeft -= Time.deltaTime;
                    } else {
                        currObj = transObj;
                        pauseLeft = pause;
                    }
                }
            } else {
                if (1f - expo > Time.deltaTime / duration) {
                    RenderSettings.skybox.SetFloat("_Exposure", expo + Time.deltaTime / duration);
                } else {
                    RenderSettings.skybox.SetFloat("_Exposure",  1f);
                    foreach (Transform child in currObj.transform) {
                        child.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
    
    public void ToCube() {
        transObj = cube;
        transing = true;
        foreach (Transform child in currObj.transform) {
            child.gameObject.SetActive(false);
        }
    }
    
    public void ToLiving() {
        transObj = living;
        transing = true;
        foreach (Transform child in currObj.transform) {
            child.gameObject.SetActive(false);
        }
    }
    
    public void ToCantina() {
        transObj = cantina;
        transing = true;
        foreach (Transform child in currObj.transform) {
            child.gameObject.SetActive(false);
        }
    }
    
    public void ToMezz() {
        transObj = mezz;
        transing = true;
        foreach (Transform child in currObj.transform) {
            child.gameObject.SetActive(false);
        }
    }
}