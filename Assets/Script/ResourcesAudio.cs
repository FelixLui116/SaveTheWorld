using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAudio : MonoBehaviour
{    

    [SerializeField]  private enum GunAudio { FIRE , RELOAD , PICKUP , DROP};
    [Header("Item")]
    public AudioClip[] Ammo_Audio;   // BLUE, GREEN, yellow, RED 
    public AudioClip medkit;
    public AudioClip coin;

   
    [Header("Gun")]
    [SerializeField] public AudioClip [] Gun_1 , Gun_2 , Gun_3; // etc..



    public static ResourcesAudio Instance { get; private set; }

    private void Awake() {

        if (Instance == null)
        {
            Instance = this;
        }
    } 
    // Start is called before the first frame update
    // void Start()
    // {
    // }

    // // test only
    // public int [] numberRoom;    // 4,5,1,2,3
    // private int position =4;     // 0,1,2,3,4
    // private void Start() {
    //     for (int i = 0; i < numberRoom.Length; i++)        // return sent not corrent 
    //     {
    //         int positionOnTable;
    //         positionOnTable = i - position;
    //         if (positionOnTable < 0){
    //             // positionOnTable = (PlayerArray.Length-1) + positionOnTable; // always -XX, -- = +;
    //             positionOnTable = numberRoom.Length;
    //             positionOnTable -= position;
    //             positionOnTable +=i;
    //         }
    //         Debug.Log("==== PT 2: "+ i + " || " +positionOnTable + "= "+ numberRoom.Length +"-"+ position);
    //         // Debug.Log("==== PT 3: " +positionOnTable);
    //     }
    // }
}
