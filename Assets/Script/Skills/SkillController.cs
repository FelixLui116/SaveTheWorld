using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("Player Skill")]
    [SerializeField] protected GameObject SkillPos_Hand; 
    [SerializeField] protected GameObject Skill1; 
    [SerializeField] protected GameObject Skill2; 
    [SerializeField] protected GameObject Skill3; 
    // [SerializeField] protected GameObject [] Skills; 

    [Header("Gun Skill")]

    [SerializeField] protected GameObject GunSkill; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))      // Test Function
        {
            // Skill1.Skill_1_func(Obj1, null);
            // PoolSystem.Instance.
            // Skill1.Skill_1_func();
        }if (Input.GetKeyDown(KeyCode.W))      // Test Function
        {
        }if (Input.GetKeyDown(KeyCode.E))      // Test Function
        {
        }
    }

    public void Controll_skill_1(Transform targetTF){

        // CloneSkillObj(targetTF , Skill1);
        PoolSystem.Instance.CreatePoolSkill_top(targetTF , Skill1);
    }

    public void CloneSkillObj (Transform targetTF , GameObject obj){
        
    }

}
