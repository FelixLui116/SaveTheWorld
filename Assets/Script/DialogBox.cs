using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{   
    public Text text;
    private int timer = 4;  // each text have 4s to show
    public Transform doc;

    public string[] listText;
    private int textCount = 0; 

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine( DelayDestory() );
        // StartCoroutine( ShowText() );
         StartCoroutine( DocCounting() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public IEnumerator ShowText(){
        // textCount = listText.Length;
        // Debug.Log("listText.Length: " + listText.Length);

        // text.text = listText[textCount].ToString();
        // Debug.Log(" text.text: " +  text.text );
        // StartCoroutine( DocCounting() );
        // yield return new WaitForSeconds(timer);
        // textCount++;

        // Debug.Log(" textCount: " +  textCount + " listText.Length: " +  listText.Length );
        // if (textCount < listText.Length)
        // {
        //      StartCoroutine( ShowText() );
        // }else
        // {
        //     Destroy(gameObject);
        // }
            // for (var k = 0; k < timer; k++) // Reset doc
            // {
            //     GameObject obj = doc.GetChild(k).gameObject;
            //     obj.SetActive(true);
            // }
    //     yield return null;
    // }

    public IEnumerator DocCounting(){  // isShowText

        // Debug.Log("textCount: " + listText.Length);
        if (listText.Length == 0){
            Destroy(gameObject); /// destory log with no Sentencse
            yield return null;
        }else{
            text.text = listText[textCount].ToString();
            for (var i = 0; i < timer; i++)
            {
                GameObject obj = doc.GetChild(i).gameObject;
                obj.SetActive(false);
                yield return new WaitForSeconds(1);
            }

            for (var k = 0; k < timer; k++) // Reset doc
            {
                GameObject obj = doc.GetChild(k).gameObject;
                obj.SetActive(true);
            }
            textCount++;
            if (textCount < listText.Length)
            {
            StartCoroutine( DocCounting() );
            }else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DelayDestory()
    {
        for (var i = 0; i < timer; i++)
        {
            GameObject obj = doc.GetChild(i).gameObject;
            obj.SetActive(false);
            yield return new WaitForSeconds(1);
        }
        
        Destroy(gameObject);
    }
}
