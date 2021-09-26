﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxSystem : MonoBehaviour
{
    public static DialogBoxSystem Instance { get; private set; }

    private Camera camera;
    private GameObject dialogBox;
    private Transform dialogBoxParent;
    private GameObject dialogBoxClone;
    private int offsetY = 50;

    private int[] dialogList;

    // Start is called before the first frame update
    void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        dialogBoxParent = GameObject.Find("DialogLayer").GetComponent<Transform>();
        dialogBox = Resources.Load<GameObject>("Prefabs/GameObject/DialogBox");
    }
    void Start()
    {
    }

    void Update()
    {
        if (dialogBoxClone != null)
        {
            Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
            screenPosition.y += offsetY;
            dialogBoxClone.transform.position = screenPosition;
        }
    }

    public GameObject CloneDialogFunc(string text){
        dialogBoxClone = Instantiate(dialogBox , dialogBoxParent);
        DialogBox _dialogBox = dialogBoxClone.GetComponent<DialogBox>(); 
        _dialogBox.text.text = text.ToString();
        return dialogBoxClone;
    }
    // public void DestroyDialogFun(){
    //     // Destroy(dialogBoxClone);
    // }



}