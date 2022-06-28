using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement; 

public class ClothManager : MonoBehaviour
{
    // public GameObject [] objects; 

    public int A_index,T_index,P_index,H_index,S_index; 

    public GameObject [] accessories; 
    public GameObject [] tops; 
    public GameObject [] pants; 
    public GameObject [] shoes; 
    public GameObject [] hair; 
 
    //test toggle
    public GameObject obj; 
    public bool isEnabled = true; 

    // Start is called before the first frame update
    void Start()
    {
        objOff(); 
        A_index = 0; 
        T_index = 0; 
        P_index = 0; 
        H_index = 0; 
        S_index = 0; 

    }

    void Update()
    {
        // selectObj(index); 
        // showaObj(index);
       // OpenAccessories();  
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); 
    }

    public void objOff()
    {
        accessories = GameObject.FindGameObjectsWithTag("aObj"); 
        // if (accessories == null) 
        // {
        //     Debug.LogError("Failed to find an object");
        //     this.enabled = false; 
        //     return; 
        // }
        for (int i = 0; i < accessories.Length; i++)
        {
            accessories[i].SetActive(false); 
            // accessories[i] = objects[i];
            // for each (var item in accessories)
            // {
            //     Console.WriteLine(item); 
            // }
        }

        tops = GameObject.FindGameObjectsWithTag("tObj");
        //  if (tops == null) 
        // {
        //     Debug.LogError("Failed to find an object");
        //     this.enabled = false; 
        //     return; 
        // } 
        for (int i = 0; i < tops.Length; i++)
        {
            tops[i].SetActive(false); 
        }

        pants = GameObject.FindGameObjectsWithTag("pObj"); 
        // if (pants == null) 
        // {
        //     Debug.LogError("Failed to find an object");
        //     this.enabled = false; 
        //     return; 
        // }
        for (int i = 0; i < pants.Length; i++)
        {
            pants[i].SetActive(false); 
        }

        shoes = GameObject.FindGameObjectsWithTag("sObj"); 
        // if (shoes == null) 
        // {
        //     Debug.LogError("Failed to find an object");
        //     this.enabled = false; 
        //     return; 
        // }
        for (int i = 0; i < shoes.Length; i++)
        {
            shoes[i].SetActive(false); 
        }

        hair = GameObject.FindGameObjectsWithTag("hObj"); 
        if (hair == null) 
        {
            Debug.LogError("Failed to find an object");
            this.enabled = false; 
            return; 
        }
        for (int i = 0; i < hair.Length; i++)
        {
            hair[i].SetActive(false); 
        }
        //the last object it ends on is the last piece of hair 
       
    }

    void closeObjs(GameObject [] objs)
    {
        foreach(var o in objs)
        {
            o.SetActive(false);
        }
    }

    public void Next(int whicharray)
    {
        A_index = 0; 
        T_index = 0; 
        P_index = 0; 
        H_index = 0; 
        S_index = 0; 

        switch(whicharray)
        {
            case 0:
                if (A_index > accessories.Length)
                {
                    A_index = 0;
                }
                    
                closeObjs(accessories);
                accessories[A_index].SetActive(true); 
                
                A_index++;
            break;
            
            case 1:
                T_index++;
                if (T_index > tops.Length)
                {
                    T_index = 0;
                }
                    
                closeObjs(tops);
                tops[T_index].SetActive(true); 
            break;
            
            case 2:
                P_index++;
                if (P_index > pants.Length)
                {
                    P_index = 0;
                }
                    
                closeObjs(pants);
                pants[P_index].SetActive(true); 
            break;

            case 3:
                H_index++;
                if (H_index > hair.Length)
                {
                    H_index = 0;
                }
                    
                closeObjs(hair);
                hair[H_index].SetActive(true); 
            break;

            case 4:
                S_index++;
                if (S_index > shoes.Length)
                {
                    S_index = 0;
                }
                    
                closeObjs(shoes);
                shoes[S_index].SetActive(true); 
            break;
        }
        
    }

    public void Previous(int whicharray)
    {
        switch(whicharray)
        {
            case 0:
                A_index--;
                if (A_index < 0)
                {
                    A_index = accessories.Length - 1;
                }
                    
                closeObjs(accessories);
                accessories[A_index].SetActive(true); 
            break;

            case 1:
                T_index--;
                if (T_index < 0)
                {
                    T_index = tops.Length - 1;
                }
                    
                closeObjs(tops);
                tops[T_index].SetActive(true); 
            break;
            
            case 2:
                P_index--;
                if (P_index < 0)
                {
                    P_index = pants.Length - 1;
                }
                    
                closeObjs(pants);
                pants[P_index].SetActive(true); 
            break;

            case 3:
                H_index--;
                if (H_index < 0)
                {
                    H_index = hair.Length - 1;
                }
                    
                closeObjs(hair);
                hair[H_index].SetActive(true); 
            break;

            case 4:
                S_index--;
                if (S_index < 0)
                {
                    S_index = shoes.Length - 1;
                }
                    
                closeObjs(shoes);
                shoes[S_index].SetActive(true); 
            break;
        }
       
    }

/*
Code to change material color of the clothes

material.color
Material.SetColor - API
*/

}
