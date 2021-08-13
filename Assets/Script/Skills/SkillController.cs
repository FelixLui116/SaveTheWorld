using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject SkillPos_Hand; 
    [SerializeField] protected Skill_1 Skill1; 
    [SerializeField] protected Skill_2 Skill2; 
    [SerializeField] protected Skill_3 Skill3; 

    [SerializeField] protected GameObject Obj1; 
    [SerializeField] protected GameObject Obj2; 
    [SerializeField] protected GameObject Obj3; 
    [SerializeField] protected GameObject Obj4; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))      // Test Function
        {
            Skill1.Skill_1_func(Obj1);
        }if (Input.GetKeyDown(KeyCode.W))      // Test Function
        {
        }if (Input.GetKeyDown(KeyCode.E))      // Test Function
        {
        }
    }
}
