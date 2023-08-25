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
    public static GlobalManager GlobalManager;

    [SerializeField] private GameObject [] effect;

    // Awake
    private void Awake() {
        
    }

    void Start()
    {   
        // change color
        switch(teleport_type) 
        {
            case TeleportType.teleportPosition:
                effect[0].SetActive(true);
                break;
            case TeleportType.toScene:
                effect[1].SetActive(true);
                break;
            default:
                break;
        }

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
                // characterController enable move debug 
                CharacterController characterController =  other.gameObject.GetComponent<CharacterController>();
                characterController.enabled = false;
                // other.gameObject.transform.position = ToPosition.position;
                other.gameObject.transform.position = new Vector3( ToPosition.position.x , other.gameObject.transform.position.y,  ToPosition.position.z);
                characterController.enabled = true;
                Debug.Log("teleport.Position:" +other.gameObject.transform.position +" || " +ToPosition.position );
               
                break;
            case TeleportType.toScene:
                Debug.Log(" TeleportType.toScene");
                if (ToScene == null || GlobalManager.Instance == null){
                    Debug.LogError($"ToScene: {ToScene} || GlobalManager_Instance: {GlobalManager.Instance}");
                    return;
                }
                GlobalManager.Instance.loadSceneAsync(ToScene);
                break;
            default:
                break;
        }

    }

}
