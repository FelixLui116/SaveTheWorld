using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GlobalManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource sfxMusic;

    public GameObject notifications;
    public static GlobalManager Instance { get; private set; }
    public MusicController musicController;



    string path = "/JSON/SaveDate.json";

    private void Awake() {

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(backgroundMusic);
            DontDestroyOnLoad(sfxMusic);
            // DontDestroyOnLoad(notifications);
            Instance = this;
        }
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator loadSceneAsync(string sceneName){
        Debug.Log("load sceneName : " + sceneName);
        SceneManager.LoadScene(sceneName , LoadSceneMode.Single);
        yield return null;
    }

    public void ClonePanel (){
        
    }
    

    [SerializeField] public PlayerData _PlayerData = new PlayerData();

    public void SaveIntoJson(){
        string potion = JsonUtility.ToJson(_PlayerData);
        System.IO.File.WriteAllText(Application.dataPath + path, potion);
        // System.IO.File.WriteAllText(Application.dataPath+"/JSON/SaveDate.json", potion);
    }


    public void LoadJson(){
        // using (StreamReader r = new StreamReader(Application.dataPath+"/JSON/SaveDate.json"))
        //     {
        //         string json = r.ReadToEnd();
        //         foreach (var item in json)
        //         {
        //             Debug.Log(item);
        //         }
        //     }
        StreamReader reader = new StreamReader (GetPath());
        string jsonString = reader.ReadToEnd();
        reader.Close();
        JsonUtility.FromJsonOverwrite(jsonString, _PlayerData);
        Debug.Log( "playerHP: "+ _PlayerData.playerHP);
     
    }

    private string GetPath ()
    {   
        string path_ = Path.Combine(Application.dataPath + path);
        Debug.Log("path" +path_);
        return path_;
    }

    [System.Serializable]
        public class PlayerData{
        public float playerHP;
        public float money;
        public string player_Level;
        public List<Skill> skill = new List<Skill>();
        public List<Effect> effect = new List<Effect>();
        public List<Effect> level = new List<Effect>();
    }

    [System.Serializable]
    public class Effect{
        public string name;
        public string desc;
    }
    [System.Serializable]
    public class Skill{
        public string name;
        public string Level;
    }
    [System.Serializable]
    public class level{
        public int level_;
        public int star;
    }

}
