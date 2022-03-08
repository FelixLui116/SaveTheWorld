using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{

    public Button startBtn;
    public Button continueBtn;
    public Button howToPlayBtn;
    public Button quitBtn;
    public Button settingBtn;
    
    [SerializeField] private Button testScene;
    [SerializeField] private Canvas canvas;

    public string [] SceneName;
    
    [Header("== Panel ==")]
    
    [SerializeField] private GameObject [] BoxPanel; // 0 =startPanel ,1 =HelpPanel, 2 =SettingPanel
    // [SerializeField] private GameObject HowToPlayPanel;
    // [SerializeField] private GameObject SettingPanel;
    [SerializeField] private Button [] StartLevelBox;
    // Start is called before the first frame update
    protected void Start()
    {
        startBtn.onClick.AddListener(() => StartPanel_func() );
        continueBtn.onClick.AddListener(() => ContinuePanel_func() );
        // continueBtn.onClick.AddListener(() => ToScene( SceneName[1] , false ));
        howToPlayBtn.onClick.AddListener(() => HowToPlayPanel_func() );
        quitBtn.onClick.AddListener(() => Quit_func() );

        settingBtn.onClick.AddListener(() =>  Setting_func() );


        testScene.onClick.AddListener(() => ToScene( SceneName[0] , true ));
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }
    
    private void Quit_func (){
        Application.Quit();
    } 

    public void ToScene(string gameScene , bool newGame){
        GlobalManager.Instance.loadSceneAsync(gameScene);

        // newGame
    }

    public void ChangePlayinfo(){      // is working
        GlobalManager.Instance._PlayerData.money = 22222;
    }
    private void StartPanel_func( ){      // is working
        ResetBoxPanel();
        BoxPanel[0].SetActive(true);
    }
    private void ContinuePanel_func( ){      // is working
        ResetBoxPanel();
        BoxPanel[1].SetActive(true);
    }

    public void EneterLevel_func(int level){      // is working
    Debug.Log(" Level: " + SceneName[level]);

        if (SceneName[level] == "")
        {
            Debug.Log("Scene Name string = null ");
            
            GameObject popuptext_panel = Instantiate(Resources.Load("Prefabs/GameObject/PopupTextPanel") as GameObject, canvas.transform);
            PopupTextPanel popuptextpanel = popuptext_panel.GetComponent<PopupTextPanel>();
            popuptextpanel.PanelSetting("Sorry is coming soon" ," Close ");
        }
        else{
            ToScene( SceneName[level] , false );
        }
    }

    private void HowToPlayPanel_func(){      // is working
        ResetBoxPanel();
        // HowToPlayPanel.SetActive(true);
        BoxPanel[2].SetActive(true);
    }
    private void Setting_func(){      // is working
        ResetBoxPanel();
        // SettingPanel.SetActive(true);
        BoxPanel[3].SetActive(true);
    }

    // ToScene( SceneName[1] , true)

    private void ResetBoxPanel(){
        for (var i = 0; i < BoxPanel.Length; i++)
        {
            BoxPanel[i].SetActive(false);
        }
    }
}
