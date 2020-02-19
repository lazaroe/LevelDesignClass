using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Vector3 aimDownSights;
    public Vector3 hipFire;
    public float aimspeed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDownSights, aimspeed * Time.deltaTime);
            print("aiming");
        }
        else {
            transform.localPosition = Vector3.Slerp(transform.localPosition, hipFire, aimspeed * Time.deltaTime);
        }
    }
}
