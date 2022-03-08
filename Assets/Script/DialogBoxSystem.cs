using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxSystem : MonoBehaviour
{
    public static DialogBoxSystem Instance { get; private set; }

    private Camera camera;
    private GameObject dialogBox;
    private Transform dialogBoxParent;
     [SerializeField] private GameObject dialogBoxClone;
    private int offsetY = 25;

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

    // public GameObject CloneDialogFunc(string text , int timer){
    //     dialogBoxClone = Instantiate(dialogBox , dialogBoxParent);

    //     // Fix bug the Clone positon Not update in first frame
    //     Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
    //     screenPosition.y += offsetY;
    //     dialogBoxClone.transform.position = screenPosition;
    //     //

    //     DialogBox _dialogBox = dialogBoxClone.GetComponent<DialogBox>(); 
    //     _dialogBox.text.text = text.ToString();
    //     _dialogBox.timer = timer;

        

    //     return dialogBoxClone;
    // }

    public GameObject CloneDialogFunc(string[] text , int timer){
        dialogBoxClone = Instantiate(dialogBox , dialogBoxParent);

        // Fix bug the Clone positon Not update in first frame
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        screenPosition.y += offsetY;
        dialogBoxClone.transform.position = screenPosition;
        //

        DialogBox _dialogBox = dialogBoxClone.GetComponent<DialogBox>(); 

        _dialogBox.listText = text;
        // _dialogBox.text.text = text.ToString();
        // _dialogBox.timer = timer;

        return dialogBoxClone;
    }

    public void testfunction_list(string[]  stringList){
        for (var i = 0; i < stringList.Length; i++)
        {
            Debug.Log(stringList[i]);
            
        }
    }
    // public void DestroyDialogFun(){
    //     // Destroy(dialogBoxClone);
    // }



}
