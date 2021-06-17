using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAudio : MonoBehaviour
{    

    [SerializeField]  private enum GunAudio { FIRE , RELOAD , PICKUP , DROP};
    [Header("Item")]
    public AudioClip[] Ammo_Audio;   // BLUE, GREEN, YOLLOW, RED 
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
    void Start()
    {
    }

}
