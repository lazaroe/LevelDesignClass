using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSiren : MonoBehaviour
{
    public Light siren;
    public float intervalTime = 0.1f;
    float intervalTimer = 0f;
    bool isOn;

    void Update()
    {

        intervalTimer += Time.deltaTime;

        if (intervalTimer > intervalTime)
        {
            isOn = !isOn;
            if (isOn)
            {
                siren.intensity = 1.0f;
            }
            else
            {
                siren.intensity = 0.0f;
            }

            intervalTimer = 0f;
        }
    }
}
