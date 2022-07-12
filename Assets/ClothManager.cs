using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement; 
using System.IO;

public class ClothManager : MonoBehaviour
{
    public int A_index,T_index,P_index,H_index,S_index;
    // public static readonly string SAVE_FOLDER = Application.dataPath = "/Saves/"; 
    public GameObject [] accessories; 
    public GameObject [] tops; 
    public GameObject [] pants; 
    public GameObject [] shoes; 
    public GameObject [] hair; 
 
    //test toggle
    public GameObject obj; 
    public bool isEnabled = true; 

    public static ClothManager Instance; 

    // private void Awake()
    // {

    //     if(!Directory.Exists(SAVE_FOLDER))
    //     {
    //         Directory.CreateDirectory(SAVE_FOLDER); 
    //     }
    //     else
    //     {
    //         File.WriteAllText(Application.dataPath + "/save.txt", json); 
    //     }
    // }
    // Start is called before the first frame update
    void Start()
    {
        findObj();
        objOff(); 
        A_index = 0; 
        T_index = 0; 
        P_index = 0; 
        H_index = 0; 
        S_index = 0; 

        BlobPlayerPrefs(); 
    }

    void Update()
    {
        // selectObj(index); 
        // showaObj(index);
       // OpenAccessories();  
        //   for (int i = 0; i < tops.Length; i++)
        // { 
        //     Debug.Log(tops[i]); 
        // }
    }

    public void findObj()
    {
        accessories = GameObject.FindGameObjectsWithTag("aObj"); 
        tops = GameObject.FindGameObjectsWithTag("tObj");
        pants = GameObject.FindGameObjectsWithTag("pObj"); 
        shoes = GameObject.FindGameObjectsWithTag("sObj"); 
        hair = GameObject.FindGameObjectsWithTag("hObj"); 
    }
    public void objOff()
    {
        for (int i = 0; i < accessories.Length; i++)
        {
            accessories[i].SetActive(false); 
            // accessories[i] = objects[i];
            // for each (var item in accessories)
            // {
            //     Console.WriteLine(item); 
            // }
        }
      
        for (int i = 0; i < tops.Length; i++)
        {
            tops[i].SetActive(false); 
        }

        for (int i = 0; i < pants.Length; i++)
        {
            pants[i].SetActive(false); 
        }

        for (int i = 0; i < shoes.Length; i++)
        {
            shoes[i].SetActive(false); 
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

        switch(whicharray)
        {
            case 0:
                A_index++;
                if (A_index >= accessories.Length)
                {
                    A_index = 0;
                }
                    
                closeObjs(accessories);
                accessories[A_index].SetActive(true); 
                PlayerPrefs.SetInt("a_index", A_index);
            break;
            
            case 1:
                T_index++;
                if (T_index >= tops.Length)
                {
                    T_index = 0;
                }
                    
                closeObjs(tops);
                tops[T_index].SetActive(true); 
                PlayerPrefs.SetInt("t_index", T_index);
            break;
            
            case 2:
                P_index++;
                if (P_index >= pants.Length)
                {
                    P_index = 0;
                }
                    
                closeObjs(pants);
                pants[P_index].SetActive(true);
                PlayerPrefs.SetInt("p_index", P_index); 
            break;

            case 3:
                H_index++;
                if (H_index >= hair.Length)
                {
                    H_index = 0;
                }
                    
                closeObjs(hair);
                hair[H_index].SetActive(true); 
                PlayerPrefs.SetInt("h_index", H_index);
            break;

            case 4:
                S_index++;
                if (S_index >= shoes.Length)
                {
                    S_index = 0;
                }
                    
                closeObjs(shoes);
                shoes[S_index].SetActive(true); 
                PlayerPrefs.SetInt("s_index", S_index);
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

    public void BlobPlayerPrefs()
    {
        if(PlayerPrefs.HasKey("a_index"))
        {
            A_index = PlayerPrefs.GetInt("a_index");
            accessories[A_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("a_index", -1);
        }

        if(PlayerPrefs.HasKey("t_index"))
        {
            T_index = PlayerPrefs.GetInt("t_index");
            tops[T_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("t_index", -1);
        }

        if(PlayerPrefs.HasKey("p_index"))
        {
            P_index = PlayerPrefs.GetInt("p_index");
            pants[P_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("p_index", -1);
        }

        if(PlayerPrefs.HasKey("h_index"))
        {
            H_index = PlayerPrefs.GetInt("h_index");
            hair[H_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("h_index", -1);
        }

        if(PlayerPrefs.HasKey("s_index"))
        {
            S_index = PlayerPrefs.GetInt("s_index");
            shoes[S_index].SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("s_index", -1);
        }
    }

    // private void Save()
    // {
    //     int A_index = obj.GetInt();
    //     int T_index = obj.GetInt();
    //     int P_index = obj.GetInt();
    //     int H_index = obj.GetInt();
    //     int S_index = obj.GetInt();

    //     SaveObject saveBlob = new SaveObject()
    //     {
    //         A_index = A_index;
    //         T_index = T_index; 
    //         P_index = P_index;
    //         H_index = H_index;
    //         S_index = S_index;
    //     }
    //     string json = JsonUtility.ToJson(SaveObject); 
    //     File.WriteAllText(Application.dataPath + "/save.txt", json);  
    // }
/*
Code to change material color of the clothes

material.color
Material.SetColor - API
*/

    void destroyObj()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject); 
            return; 
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // public class SaveObject
    // {
    //     public int A_index,T_index,P_index,H_index,S_index = -1; 
    // }
}

