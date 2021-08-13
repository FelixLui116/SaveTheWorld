using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HowToPlayPanel : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {   
        CancelBtn.onClick.AddListener(() => Cancel_func() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void Cancel_func(){
        this.gameObject.SetActive(false);
    }
}
