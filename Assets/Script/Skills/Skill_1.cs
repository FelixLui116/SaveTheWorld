using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject Obj1; 
    // [SerializeField] private int CloneTime; 
    [SerializeField] private Vector3 [] position; 

    [SerializeField] private float destroyTime = 1f;
    
    void Start()
    {
        // Skill_1_func();
        // Skill_1_func();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Skill_1_func(){
        // Instantiate(Obj);  .transform.eulerAngles.y;
        for (int i = 0; i < position.Length; i++)
        {
            var bullet = Instantiate(Obj1);
        }
    }

    private void destroyTime_func(){
        // yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject , destroyTime);
    }
}
