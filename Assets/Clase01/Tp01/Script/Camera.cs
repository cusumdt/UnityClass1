using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    bool castSwitch=true;
    int planet=0;
    float x=0;
    float z=0;
    float y=0;
   // public int cant;
    public GameObject[] SolarSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (planet < SolarSystem.Length)
        {
            //Preguntar
             /*   x = transform.position.x + Time.deltaTime*0.3f;
                if (x>= SolarSystem[planet].transform.position.x-4)
                {
                    x = SolarSystem[planet].transform.position.x-4;
                }
                transform.position = new Vector3(x, 4.61f, SolarSystem[planet].transform.position.z);
                */
            transform.position = new Vector3(SolarSystem[planet].transform.position.x - 4, 4.61f, SolarSystem[planet].transform.position.z);
        }
        else
        {
            transform.position = new Vector3(-28.6f, 18.14f, -11.67f);
        }
        StartCoroutine("switchCamera");
    }

    private IEnumerator switchCamera()
    {
        if (castSwitch)
        {
            castSwitch = false;
            yield return new WaitForSeconds(5.0f);
            planet++;
            if (planet==SolarSystem.Length+1) {
                planet = 0;
            }
            castSwitch = true;
        }
    }
}
