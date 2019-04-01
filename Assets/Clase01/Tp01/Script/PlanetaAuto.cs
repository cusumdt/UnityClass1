using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaAuto : MonoBehaviour
{
    public Material[] mat;
    public GameObject planeta;
    public GameObject sun;
    public float[] distance;
    public float[] velocity;
    float x;
    float z;
    float[] alpha;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    public float[] velocityRotation;
    float alphaRotation;
    GameObject[] go;

    void Start()
    {
        alpha = new float[8];
        go = new GameObject[8];
        for (int i = 0; i < go.Length; i++)
        {
            go[i] = Instantiate(planeta, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
            go[i].transform.position = new Vector3(distance[i], transform.position.y, transform.position.z);
            go[i].GetComponent<MeshRenderer>().material = mat[i];
        }
    }

    void Update()
    {
        
        //Rotation system 31/03/2019 17:00hs
        for (int i = 0; i < go.Length; i++)
        {
           
            alphaRotation = alphaRotation + Time.deltaTime * velocityRotation[i];
            float tiltAroundZ = alphaRotation * tiltAngle;
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
            Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundZ, 0);
            go[i].transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
        //Transform Position system 25/03/2019 12:30hs
        for (int i = 0; i < go.Length; i++)
        {
            alpha[i] = alpha[i] + Time.deltaTime * velocity[i];
            x = sun.transform.position.x + distance[i] * Mathf.Cos(alpha[i]);
            z = sun.transform.position.z + distance[i] * Mathf.Sin(alpha[i]);
            go[i].transform.position = new Vector3(x, transform.position.y, z);
        }
    }
}
