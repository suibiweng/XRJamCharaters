using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement; 
using System.IO;

[System.Serializable]
public class ClothManager : MonoBehaviour
{

    public GameObject [] accessories; 
    public GameObject [] tops; 
    public GameObject [] pants; 
    public GameObject [] shoes; 
    public GameObject [] hair; 
 
    //test toggle
    public  GameObject obj;
    public bool isEnabled = true; 

    public static ClothManager Instance; 
    public int A_index,T_index,P_index,H_index,S_index;
    //referenced WAR dd on Youtube
    public FlexibleColorPicker fcp; 
    public Material material; 

    public float red, green, blue; 
    public string SAVE_FOLDER ;
public bool isLoadCloth;
    public TextAsset saveJson; 
    private void Awake()
    {
        if(!Directory.Exists(SAVE_FOLDER))
        {
//            Directory.CreateDirectory(SAVE_FOLDER); 
        }
        else
        {
          //  File.WriteAllText(Application.dataPath + "/save.txt", json); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SAVE_FOLDER = Application.dataPath + "/save.txt"; 
        findObj();
        objOff(); 
        A_index = 0; 
        T_index = 0; 
        P_index = 0; 
        H_index = 0; 
        S_index = 0; 
        if(isLoadCloth)
        {
            Load(); 
        }
        else
        {
            ColorPicker(); 
        }

        // BlobPlayerPrefs(); 
      
    }

    void Update()
    {


        if(isLoadCloth){
 

}else{
  ColorPicker(); 


}
       // ColorPicker(); 
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
    void openObjs(GameObject [] obs)
    {
        foreach(var o in obs)
        {
            o.SetActive(true); 
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

    //reference WAR dd Flexible Color Picker video 
    public void ColorPicker()
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

            // Debug.Log((byte)((Color32)material.color).r);
        }
        red = (byte)((Color32)material.color).r; 
        green = (byte)((Color32)material.color).g; 
        blue = (byte)((Color32)material.color).b; 

        // Debug.Log(red); 
        // Debug.Log(green); 
        // Debug.Log(blue); 

    }
    
    //reference Code Monkey Save and Load video
    public void Save()
    {
        //save all assets and skin color 
        SaveObject saveBlob = new SaveObject()
        {
            A_index = A_index,
            T_index = T_index,
            P_index = P_index,
            H_index = H_index,
            S_index = S_index,

            red = red,
            green = green,
            blue = blue
        };
        string json =JsonUtility.ToJson(saveBlob); 
        File.WriteAllText(SAVE_FOLDER, json);  
    }

    public void Load() 
    {
        //reference Code Monkey Save and Load video 
        if (File.Exists(SAVE_FOLDER))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER); 
            Debug.Log(saveString); 

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString); 

            A_index = saveObject.A_index;
            T_index = saveObject.T_index; 
            P_index = saveObject.P_index;
            H_index = saveObject.H_index;  
            S_index = saveObject.S_index; 
            // print(A_index);
            // print(T_index);
            // print(P_index);
            // print(H_index);
            // print(S_index);

            red = saveObject.red; 
            green = saveObject.green; 
            blue = saveObject.blue;
            // print(red);
            // print(green);
            // print (blue);

            accessories[A_index].SetActive(true); 
            tops[T_index].SetActive(true); 
            pants[P_index].SetActive(true);
            hair[H_index].SetActive(true);
            shoes[S_index].SetActive(true);
        }





        // SaveObject.SetInt(SaveObject.A_index);
        // Debug.Log(A_index); 

        // reference Destined to Learn Reading JSON file 
        // public BlobList myBlobList = new BlobList(); 
        // myBlobList = JsonUtility.FromJson<BlobList>(saveJson.text);

    }    
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

    public class SaveObject
    {
        public int A_index,T_index,P_index,H_index,S_index = -1; 
        public float red, green, blue; 
    }
    
    //Destined to Learn
    public class BlobList
    {
        public SaveObject[] blob; 
    }
}

