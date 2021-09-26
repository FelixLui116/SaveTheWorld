using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCCharacterController : BaseCharacter
{
    // [Header("Dialog")]
    // private Camera camera;
    // private GameObject dialogBox;
    // private Transform dialogBoxParent;
     private GameObject dialogBoxClone;
    [SerializeField] private string[] sentences;
    private int sentencesCount = 0;

    // private int offsetY = 50;

    private bool isPlayer = false;
    private void Awake() {
        // camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        // dialogBoxParent = GameObject.Find("DialogLayer").GetComponent<Transform>();
        // dialogBox = Resources.Load<GameObject>("Prefabs/GameObject/DialogBox");
    }
    void Start()
    {
        targetPlayer = LevelController.Instance.playerObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("space"))      // Test Function
        // {
        // }
        // if (dialogBoxClone != null)
        // {
        //     Vector2 screenPosition = GetComponent<Camera>().WorldToScreenPoint(transform.position);
        //     // Vector2 screenPosition = camera.WorldToScreenPoint( new Vector2( (transform.position.x), (transform.position.y)  ));
        //     screenPosition.y += offsetY;
        //     dialogBoxClone.transform.position = screenPosition;
        // }
    }

    private void FixedUpdate() {
        // DetectTarget();
        
        
  
    }
    private void OnTriggerEnter(Collider other) {
        // Neet get parent
        if (!isPlayer)
        {
            if(other.gameObject.tag == "Player"){
                // Debug.Log("is Player~~~");
                isPlayer = true;

                StartCoroutine( DialogAll_sentences() );

                // for (var i = 0; i < sentences.Length; i++)
                // {
                    // dialogBoxClone = DialogBoxSystem.Instance.CloneDialogFunc(sentences[sentencesCount] );
                    // sentencesCount++;

                    // if(sentencesCount == sentences.Length) sentencesCount = 0;
                // }
                

                // dialogBoxClone = Instantiate(dialogBox , dialogBoxParent);
            } 
        }
    }

    private void OnTriggerExit(Collider other) {
        // Neet get parent
        if (isPlayer)
        {
            if(other.gameObject.tag == "Player"){
                Debug.Log("Not Player~~~");
                isPlayer = false;

                StopCoroutine( DialogAll_sentences() );
                Destroy(dialogBoxClone);
            } 
        }
    }

    IEnumerator DialogAll_sentences()
    {
        int BoxDestroyTimer = 3;
        // int sentencesToShow = (sentences.Length - sentencesCount);
        // Debug.Log("sentencesToShow " + sentencesToShow);
        // for (var i = 0; i < (sentences.Length) ; i++)
        // {
        //     if (isPlayer)
        //     {
        //         dialogBoxClone = DialogBoxSystem.Instance.CloneDialogFunc(sentences[sentencesCount] , BoxDestroyTimer );
        //         sentencesCount++;
        //         if(sentencesCount == sentences.Length) sentencesCount = 0;
        //         yield return new WaitForSeconds(BoxDestroyTimer);
        //         yield return new WaitForSeconds(0.25f);
        //     }else{
        //         StopCoroutine( DialogAll_sentences() );

        //     }
        // }
        if (isPlayer)
        {
            dialogBoxClone = DialogBoxSystem.Instance.CloneDialogFunc(sentences[sentencesCount] , BoxDestroyTimer );
            sentencesCount++;
            if(sentencesCount == sentences.Length){
                sentencesCount = 0;
            } else{
                
                yield return new WaitForSeconds(BoxDestroyTimer);
                yield return new WaitForSeconds(0.25f);
                StartCoroutine( DialogAll_sentences() );
            }
        }
        // else{
        //     StopCoroutine( DialogAll_sentences() );
        // }
                
    }

    void OnMouseDown()
    {
        // FloatingTextController.Initialize();
        // FloatingTextController.CreateFloatingText( "123", this.transform);
        // FloatingTextController.Instance.CreateFloatingText( "Hello", transform);
        // Debug.LogFormat("{0} was dealt {1} damage", gameObject.name, "Hello");
    }
    // private void DetectTarget(){
    //     Vector3 targetPlayer_V3  = new Vector3(targetPlayer.position.x ,targetPlayer.position.y , targetPlayer.position.z );
    //     Vector3 thisObj_V3 = new Vector3( transform.position.x ,transform.position.y , transform.position.z);

    //     if(Vector3.Distance(thisObj_V3, targetPlayer_V3) < DetectRange)
    //     {
    //         //Do something
    //         detected_Target = true;
    //         Debug.Log(" Is Player- NPC");
    //         // CurrentState = EnemyState.GetTarget;   // movePath.StopCoroutines();
    //         // movePath.Base_moveToTarget( targetPlayer );

    //     }else{
    //         detected_Target = false;
    //         // CurrentState = EnemyState.Idle;
    //     }
    // } 

}
