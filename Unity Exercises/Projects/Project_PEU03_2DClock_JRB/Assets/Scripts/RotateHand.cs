using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    // turnAmount in degrees. Want 6 degrees per second for it to have 60 rotations in a circle (6/360 = 1/60). 
    private int turnAmount = 6;
    [SerializeField] bool useDeltaTime;

    // Update is called once per frame
    void Update()
    {
        // uses deltaTime
        if (useDeltaTime) transform.Rotate(Vector3.back, turnAmount * Time.deltaTime);

        // does not use deltaTime
        else transform.Rotate(Vector3.back, turnAmount);
    }
}
