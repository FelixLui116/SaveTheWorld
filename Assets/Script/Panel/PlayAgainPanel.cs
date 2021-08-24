using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainPanel : BasePanel
{
    // Start is called before the first frame update

    public string sceneName = "MainScenes";
    private void Awake() {
        NoBtn.onClick.AddListener(() => BackToMain() );

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMain(){
        LevelController.Instance.savePoint();
        StartCoroutine(GlobalManager.Instance.loadSceneAsync(sceneName));

    }

}
