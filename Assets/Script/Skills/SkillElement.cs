using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SkillElement : MonoBehaviour{
    enum WeaponSkillTpye { SpeedUp, DamageUp , ShootThrough }   
    [SerializeField] WeaponSkillTpye skillTpye;

    public float ShotingSpeed = 0.0f;
    // public float trytry = 0.0f;
    public void PowerUp(){

    }
    public void FireSpeedUp(float num = 0.0f){

    }


}
// #if UNITY_EDITOR
//     [CustomEditor(typeof(SkillElement))]
//     public class GunSkillEditor : Editor {

//         public override void OnInspectorGUI() {
//             base.OnInspectorGUI();
//             // SkillElement skillElement = (SkillElement)target;
//             EditorGUILayout.LabelField("Element");
//             EditorGUILayout.BeginHorizontal();

//             // skillElement.ShotingSpeed = EditorGUILayout.FloatField(skillElement.ShotingSpeed );
//             // SkillElement.FindProperty("weaponEnd");
//         }
//         // Start is called before the first frame update
//         // void Start()
//         // {
            
//         // }

//         // // Update is called once per frame
//         // void Update()
//         // {
            
//         // }  
//     }
// #endif

