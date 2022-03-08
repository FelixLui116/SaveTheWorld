using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupTextPanel : BasePanel
{
    [SerializeField] private Text text;
    [SerializeField] private Text button_text;
    [SerializeField] private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Cloase_panel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cloase_panel(){ 
        Destroy(this.gameObject);
    }
    public void PanelSetting( string txt, string txt_Btn ){
        text.text = txt;
        button_text.text = txt_Btn;
    }
}
