using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{   
    public Text text;
    public int timer;
    public Transform doc;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( DelayDestory() );
    }

    // Update is called once per frame
    void Update()
    {
        
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
