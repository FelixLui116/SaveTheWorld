using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject Obj1; 
    void Start()
    {
        // Skill_1_func();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Skill_1_func(Vector3 targetV3){
        // Instantiate(Obj);
        GameObject obj = null;
        obj = PoolSystem.Instance.CreatePoolSkill(Obj1 , targetV3);
    }
}
