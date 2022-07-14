using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// referenced Unity Documentation on second AudioExample
public class AudioSound : MonoBehaviour
{
    public float pitchValue = 1.0f; 
    public AudioClip mySound; 

    private AudioSource audioSource; 
    private float low = 0.75f; 
    private float high = 1.25f; 

    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = mySound; 
        audioSource.loop = true; 
    }
    
    void OnGUI()
    {
        pitchValue = GUI.HorizontalSlider(new Rect(490,300,100,30), pitchValue, low, high); 
        audioSource.pitch = pitchValue; 
    }
}
