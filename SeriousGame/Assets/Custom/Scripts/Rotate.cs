using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float Rotation_Speed;
    public float Rotation_Friction; //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].
    public float Rotation_Smoothness; //Believe it or not, adjusting this before anything else is the best way to go.

    private float Resulting_Value_from_Input;
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;

    // Use this for initialization
    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion_Rotate_From = transform.rotation;
        Quaternion_Rotate_To = Quaternion.Euler(0, Input.compass.trueHeading * Rotation_Speed * Rotation_Friction, 0);

        transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * Rotation_Smoothness);
    }

}
