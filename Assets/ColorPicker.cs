using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    //referenced WAR dd on Youtube
    public FlexibleColorPicker fcp; 
    public Material material; 

    void Start()
    {
    

        if(PlayerPrefs.HasKey("color"))
        {
            material.color = (Color)(new Color32((byte)PlayerPrefs.GetInt("red"),(byte)PlayerPrefs.GetInt("green"),(byte)PlayerPrefs.GetInt("blue"), 1));
        }
        else
        {
            PlayerPrefs.SetString("color", "set");
            material.color = Color.white;
        }
    }
    private void Update()
    {

        if(fcp!=null)
        {
        material.color = fcp.color;

        PlayerPrefs.SetInt("red", ((Color32)material.color).r);
        PlayerPrefs.SetInt("blue", ((Color32)material.color).b);
        PlayerPrefs.SetInt("green", ((Color32)material.color).g);


        if (material.color == null)
        {
            material.color = Color.white;
        }
        }
        
    }
}
