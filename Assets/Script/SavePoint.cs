using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public static GlobalManager GlobalManager_Instance;
    public static LevelController LevelController_Instance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        // GlobalManager.Instance.loadSceneAsync(ToScene);  //"MainScenes"
        if (other.name == "Player")
        {
            LevelController.Instance.savePoint_BasePlayerInform();
            // GlobalManager_Instance.SaveIntoJson();
        }
    }
}
