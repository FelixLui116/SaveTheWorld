using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Input.GetKeyDown("space"))      // Test Function
        {
            // print("space key was pressed");
            if(baseGun != null ){
                // baseGun.attack_func();
            }
        }
    
    }
}
