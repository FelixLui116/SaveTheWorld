using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public bool TestPlayer = false;
    public GameObject PlayerPrefabs;

    public GameObject playerObject;

    // public GameObject[] enemyType;
    // public PlayerCharacterController player; 
    public GameObject SceneBuilding;

    public static LevelController Instance { get; private set; }
    public Image[] Ammo_Color;
    public Text Debug_Text;
    public Image GunUI_Image = null;  // baseCharacter.baseGun. ( WeaponImg , WeaponImg_Disable)
    public Text AmmoText;

    public Transform StartPlayerPos;

    public UIContrller uIContrller;

    private void Awake() {

        if (Instance == null)
        {
            // DontDestroyOnLoad(notifications);
            Instance = this;
        }
        if (TestPlayer)
        {
            GameObject playerPrefabs = Instantiate(PlayerPrefabs);
            playerObject = playerPrefabs;
            // playerObject.transform.position = new Vector3(10,0,10);
            // Debug.Log("=== 1: "+ playerObject.transform.position );
            playerPrefabs.name = "Player";
        }

    }
    
    // private void OnMouseDown()
    // {
    //     Debug.Log("=== 1: "+ playerObject.transform.position );
    //     playerObject.transform.position = new Vector3(10,0,10);
    // }
    // Start is called before the first frame update
    void Start()
    {
        // if (newGame){
            
        // }
        // else{
            // old game
            Load_SaveData();
        // }

        // playerObject.transform.position = PlayerStartingPoint.position;
        // Debug.Log("=== : "+ playerObject.transform.position + " || " + PlayerStartingPoint.position);
    }
    
    public Transform ResetStartPosition (){

        // playerObject.transform.position = new Vector3(10f,0f, 0f);
        // Debug.Log("=== position: "+ playerObject.transform.position );
        return StartPlayerPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  savePoint(){
        GlobalManager.Instance._PlayerData.money = 12;

        GlobalManager.Instance.SaveIntoJson();
    }

    public void savePoint_BasePlayerInform ( ){
        PlayerCharacterController pc = playerObject.GetComponent<PlayerCharacterController>();
        
        GlobalManager.Instance._PlayerData.player_Position = playerObject.transform.position;
        GlobalManager.Instance._PlayerData.money = pc.Coin;
        GlobalManager.Instance._PlayerData.playerHP = pc.Current_health;

        Debug.Log("PC position:" + playerObject.transform.position +" || "+pc.Coin+" || "+ pc.Current_health);
        GlobalManager.Instance.SaveIntoJson();
    }


    public void Load_SaveData(){
        GlobalManager.Instance.LoadJson();
        var PlayerData = GlobalManager.Instance._PlayerData;
        uIContrller.playerCharacterController.Coin = PlayerData.money;

        uIContrller.playerCharacterController.Current_health = PlayerData.playerHP;
    }

    // // like this Ammo_text_update(1,28, 1000); 
    // public void Ammo_text_update(int CurrentAmmo ,int TotalAmmo ,int Ammo){
    // //     // something like this dispaly
    // //     //  0/28
    // //     //  200
    //         AmmoText.text = BulletText( CurrentAmmo, TotalAmmo , Ammo );
    // }
    // private string BulletText(int CurrentAmmo ,int TotalAmmo ,int Ammo) // CurrentAmmo/ TotalAmmo  (new line) Ammo
    // {
    //     if (Ammo!= null){
            
    //     }else{
        
    //     }
    //     return  CurrentAmmo +"/"+ TotalAmmo + "\n" + Ammo;
    // }

    
    
}
