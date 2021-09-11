using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
    [SerializeField] private TextMesh textMesh;
    [SerializeField] private Text _text;
    // private Text damageText;
    private Camera camera;

    private void Awake() {
        // damageText = animator.GetComponent<Text>();
    }
    void Start()
    {
        
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
        _text.text =  text;

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        transform.position = screenPosition;
        Destroy(gameObject , 0.5f );
        // damageText.text = text;
        // transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x , transform.position.y ) );
        // Debug.Log(" WorldToScreenPoint: " + transform.position);
    }
    private void Update() {
        // transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x , transform.position.y ) );
    }
}
