using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BasePanel : MonoBehaviour
{
    [SerializeField] protected Button YesBtn;
    [SerializeField] protected Button NoBtn;
    [SerializeField] protected Button CancelBtn;
    // [SerializeField] protected
    // Start is called before the first frame update
    void Start()
    {
        
        // YesBtn.onClick.AddListener(() => ToScene("Game_1") );
        // NoBtn.onClick.AddListener(() => ToScene("Game_1") );
        // CancelBtn.onClick.AddListener(() => Cancel_func() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // protected void Cancel_func(){
    // }
}
