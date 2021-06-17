using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EnableButtonAfterDelay : MonoBehaviour
{
    public float buttonReactivateDelay = 0.5f;

    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => WhenClicked());
    }

    public void WhenClicked()
    {
        btn.interactable = false;
        StartCoroutine(EnableAfterDelay(btn, buttonReactivateDelay));
    }

    IEnumerator EnableAfterDelay(Button button, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        button.interactable = true;
    }
}