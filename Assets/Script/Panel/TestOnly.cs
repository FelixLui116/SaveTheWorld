using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnly : MonoBehaviour
{
    public PistolShoot pistolShoot;
    // Start is called before the first frame update
    void Start()
    {
        // pistolShoot.Start();

        pistolShoot.pickupGun_cloneBullet();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))      // Test Function
        {
            pistolShoot.shooting_func();
        }
    }
}
