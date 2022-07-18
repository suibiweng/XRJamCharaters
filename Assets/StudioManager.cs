using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudioManager : MonoBehaviour
{
    public GameObject [] guitar; 
    public GameObject [] piano; 
    public GameObject [] drums;
    public GameObject [] instruments; 
    public int guitarIndex, pianoIndex, drumIndex; 
    // Start is called before the first frame update
    void Start()
    {
        findObj();
        closeObjs(guitar);
        closeObjs(piano);
        closeObjs(drums); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void findObj()
    {
        guitar = GameObject.FindGameObjectsWithTag("guitar"); 
        piano = GameObject.FindGameObjectsWithTag("piano");
        drums = GameObject.FindGameObjectsWithTag("drums"); 
    }
    void closeObjs(GameObject [] obs)
    {
        foreach(var o in obs)
        {
            o.SetActive(false); 
        }
    }
    public void openObjs(int arr)
    {
        switch (arr)
        {
            case 0: 
                foreach(var o in guitar)
                {
                    o.SetActive(true); 
                }
            break; 
            case 1: 
                foreach(var o in piano)
                {
                    o.SetActive(true); 
                }
            break; 
            case 2: 
                foreach(var o in drums)
                {
                    o.SetActive(true); 
                }
            break; 
        }
    }
}
