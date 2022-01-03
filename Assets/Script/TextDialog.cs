using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDialog : MonoBehaviour
{
    // Start is called before the first frame update
     private GameObject dialogBoxClone;
    [SerializeField] private string[] sentences;
    // private int sentencesCount = 0;
    
    private bool isPlayer = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                
                // if(sentencesCount == sentences.Length){
                //     sentencesCount = 0;
                // }
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
            // DialogBoxSystem.Instance.testfunction_list(sentences);
            dialogBoxClone = DialogBoxSystem.Instance.CloneDialogFunc(sentences, BoxDestroyTimer * sentences.Length );

            // yield return new WaitForSeconds(BoxDestroyTimer * sentences.Length);
            yield return null;




            // dialogBoxClone = DialogBoxSystem.Instance.CloneDialogFunc(sentences[sentencesCount] , BoxDestroyTimer );
            // sentencesCount++;
            // if(sentencesCount == sentences.Length){
            //     sentencesCount = 0;
            // } else{
                
            //     yield return new WaitForSeconds(BoxDestroyTimer);
            //     yield return new WaitForSeconds(0.25f);
            //     StartCoroutine( DialogAll_sentences() );
            // }
        }
        // else{
        //     StopCoroutine( DialogAll_sentences() );
        // }
                
    }

}
