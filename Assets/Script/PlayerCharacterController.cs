using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : BaseCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))      // Test Function
        {
            print("space key was pressed");
            if(baseGun != null ){
                baseGun.shooting_func();
            }
        }
    }
}
