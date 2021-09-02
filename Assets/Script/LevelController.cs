using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public bool TestPlayer = false;
    public GameObject PlayerPrefabs;

    public GameObject playerObject;

    public GameObject[] enemyType;
    public PlayerCharacterController player; 
    public GameObject SceneBuilding;

    public static LevelController Instance { get; private set; }
    public Image[] Ammo_Color;
    public Text Debug_Text;
    public Image GunUI_Image = null;  // baseCharacter.baseGun. ( WeaponImg , WeaponImg_Disable)
    public Text AmmoText;
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
            Debug.Log("=== 1: "+ playerObject.transform.position );
            playerPrefabs.name = "Player";
        }

        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // playerObject.transform.position = PlayerStartingPoint.position;
        // Debug.Log("=== : "+ playerObject.transform.position + " || " + PlayerStartingPoint.position);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  savePoint(){
        GlobalManager.Instance._PlayerData.money = 1111;

        GlobalManager.Instance.SaveIntoJson();
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
