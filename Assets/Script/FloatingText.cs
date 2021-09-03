using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
    [SerializeField] private TextMesh textMesh;
    // private Text damageText;

    private void Awake() {
        // damageText = animator.GetComponent<Text>();
    }
    void OnEnable()
    {
        // AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        // Debug.Log(clipInfo.Length);
        // Destroy(gameObject, clipInfo[0].clip.length);
        // damageText = animator.GetComponent<Text>();
    }

    public void SetText(string text)
    {
        textMesh.text =  text;
        Destroy(gameObject , 1.0f );
        // damageText.text = text;
        // transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x , transform.position.y ) );
        // Debug.Log(" WorldToScreenPoint: " + transform.position);
    }
    private void Update() {
        // transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x , transform.position.y ) );
    }
}
