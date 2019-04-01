using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    public GameObject sun;
    public float distance;
    public float velocity;
    float x;
    float z;
    float alpha;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    public float velocityRotation;
    float alphaRotation;

    void Start()
    {
        transform.position = new Vector3(distance, transform.position.y, transform.position.z);
    }

    void Update()
    {

        //Rotation system 31/03/2019 17:00hs
        alphaRotation = alphaRotation + Time.deltaTime * velocityRotation;
        float tiltAroundZ = alphaRotation * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundZ, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        alpha = alpha + Time.deltaTime * velocity;
        //Transform Position system 25/03/2019 12:30hs
        x = sun.transform.position.x + distance * Mathf.Cos(alpha);
        z = sun.transform.position.z + distance * Mathf.Sin(alpha);
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
