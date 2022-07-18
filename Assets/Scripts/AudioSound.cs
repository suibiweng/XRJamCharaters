using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// referenced Unity Documentation on second AudioExample
public class AudioSound : MonoBehaviour
{
    private GameObject blob;
    public float pitchValue = 1.0f; 
    public AudioClip mySound; 

    private AudioSource audioSource; 
    private float low = 0.75f; 
    private float high = 1.25f; 

    void Awake()
    {
        blob = GetComponent<GameObject>(); 
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = mySound; 
        audioSource.loop = true; 
    }
    
    void OnGUI()
    {
        pitchValue = GUI.HorizontalSlider(new Rect(700,380,100,500), pitchValue, low, high); 
        audioSource.pitch = pitchValue; 
        // pitchValue = GUI.HorizontalSlider(new Rect(300,380,100,500), pitchValue, low, high); 
        // audioSource.pitch = pitchValue; 
        // pitchValue = GUI.HorizontalSlider(new Rect(500,380,100,500), pitchValue, low, high); 
        // audioSource.pitch = pitchValue; 
    }
}
