using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public enum TeleportType { teleportPosition, toScene }    
    public TeleportType teleport_type;
    public Transform ToPosition;
    public string ToScene = "MainScenes";
    public static GlobalManager GlobalManager_Instance;

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
            
            // Debug.Log(other.gameObject.transform.position );
            
            // if (ToPosition.position != null)
            // {
            //     other.gameObject.transform.position = ToPosition.position;
            // }
            
            switchtype(teleport_type, other);

            /*     Back to Scenes
            if (GlobalManager_Instance == null ){
                Debug.LogError("Missing GlobalManager");
                return;
            }
            GlobalManager_Instance.loadSceneAsync(ToScene);
            */
        }
    }

    private void switchtype(TeleportType tt, Collider other){
        
        switch(tt) 
        {
            case TeleportType.teleportPosition:
                if (ToPosition.position == null){
                    return;
                }
                // not working
                other.gameObject.transform.position = ToPosition.position;
                Debug.Log("teleport.Position:" +other.gameObject.transform.position +" || " +ToPosition.position );
               
                break;
            case TeleportType.toScene:
                Debug.Log(" TeleportType.toScene");
                if (ToScene == null){
                    return;
                }
                GlobalManager_Instance.loadSceneAsync(ToScene);
                break;
            default:
                break;
        }

    }

}
