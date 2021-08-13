using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    public Button startBtn;
    public Button howToPlayBtn;
    public Button quitBtn;
    public Button settingBtn;

    
    [Header("== Panel ==")]
    
    [SerializeField] private GameObject HowToPlayPanel;
    // Start is called before the first frame update
    protected void Start()
    {
        startBtn.onClick.AddListener(() => ToScene("Game_1") );
        howToPlayBtn.onClick.AddListener(() => HowToPlayPanel_func() );
        quitBtn.onClick.AddListener(() => Quit_func() );

        // settingBtn.onClick.AddListener(() =>  );
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }
    
    private void Quit_func (){
        Application.Quit();
    } 

    public void ToScene(string gameScene){
        StartCoroutine(GlobalManager.Instance.loadSceneAsync(gameScene));
    }

    public void ChangePlayinfo(){      // is working
        GlobalManager.Instance._PlayerData.money = 22222;
    }
    public void HowToPlayPanel_func(){      // is working
        HowToPlayPanel.SetActive(true);
    }
}
