using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float velocity;
    public float distanceZ;
    public float distanceX;
    float alphaRotation;
    public float velocityRotation;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    float tiltAroundX;
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //distanceZ = Input.GetAxis("Vertical") * velocity;
      //  distanceX = Input.GetAxis("Horizontal") * velocity;
        /*alphaRotation = alphaRotation + Time.deltaTime * velocityRotation;
        tiltAroundX = tiltAroundX + Input.GetAxis("Horizontal") * tiltAngle * velocityRotation;
        Quaternion target = Quaternion.Euler(0, tiltAroundX,0 );
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);*/
        //transform.position = new Vector3(distanceX, transform.position.y, distanceZ);
        Vector3 mov = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rig.AddForce(mov * velocity);
    }
}
