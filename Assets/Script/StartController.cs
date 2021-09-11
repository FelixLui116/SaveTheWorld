using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    
    public Button startBtn;
    public string [] SceneName;
    void Start()
    {
        startBtn.onClick.AddListener(() => ToScene( SceneName[0] ));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToScene(string gameScene){
        // StartCoroutine(GlobalManager.Instance.loadSceneAsync(gameScene));
        GlobalManager.Instance.loadSceneAsync(gameScene);


        // newGame
    }
}
