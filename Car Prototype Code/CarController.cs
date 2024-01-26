using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject CarBody;
    public Animator CarAnim;

    public Transform Wheel1;
    public Transform Wheel2;
    public Transform Wheel3;
    public Transform Wheel4;
    //front wheels mesh
    public Transform Wheel1Mesh;
    public Transform Wheel2Mesh;
    //rear wheels mesh
    public Transform Wheel3Mesh;
    public Transform Wheel4Mesh;

    public Transform Right;
    public Transform Left;
    public Transform Straight;

    public TrailRenderer Trail1;
    public TrailRenderer Trail2;
    public TrailRenderer Trail3;
    public TrailRenderer Trail4;

    public AudioSource CarEngineSound;
    public AudioSource CarDriftSound;
    public bool DriftCheck;





    
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey("w"))
        {
            RB.velocity += transform.forward * 150 * Time.deltaTime;

            Wheel1.Rotate(- 500 * Time.deltaTime,0,0);
            Wheel2.Rotate(- 500 * Time.deltaTime,0,0);
            Wheel3.Rotate(500 * Time.deltaTime,0,0);
            Wheel4.Rotate(500 * Time.deltaTime,0,0); //500 as default value

            if(CarEngineSound.isPlaying == false)
            {
                CarEngineSound.Play();
            }
        }
        else
        {
            CarEngineSound.Stop();
        }
        if(Input.GetKey("s"))
        {
            RB.velocity -= transform.forward * 80 * Time.deltaTime;

            Wheel1.Rotate(500 * Time.deltaTime,0,0);
            Wheel2.Rotate(500 * Time.deltaTime,0,0);
            Wheel3.Rotate(-500 * Time.deltaTime,0,0);
            Wheel4.Rotate(-500 * Time.deltaTime,0,0);
        }
        if(Input.GetKey("a") && Input.GetKey("w"))
        {
            transform.Rotate(0, -0.2f, Time.deltaTime, 0);
            CarBody.transform.rotation = Quaternion.Lerp(CarBody.transform.rotation, Left.rotation, 1 * Time.deltaTime);
            RB.velocity += CarBody.transform.forward * 120 * Time.deltaTime;
            RB.velocity -= transform.forward * 110 * Time.deltaTime;

            //Wheel1.transform.rotation = Quaternion.Lerp(Wheel1.transform.rotation, Left.rotation, 1 * Time.deltaTime);
            //Wheel3.transform.rotation = Quaternion.Lerp(Wheel3.transform.rotation, Left.rotation, 1 * Time.deltaTime);

            CarAnim.SetTrigger("Left");
        }
        if(Input.GetKey("d") && Input.GetKey("w"))
        {
            transform.Rotate(0, 0.2f, Time.deltaTime, 0);
            CarBody.transform.rotation = Quaternion.Lerp(CarBody.transform.rotation, Right.rotation, 1 * Time.deltaTime);
            RB.velocity += CarBody.transform.forward * 120 * Time.deltaTime;
            RB.velocity -= transform.forward * 110 * Time.deltaTime;

            //Wheel1.transform.rotation = Quaternion.Lerp(Wheel1.transform.rotation, Right.rotation, -1 * Time.deltaTime);
            //Wheel3.transform.rotation = Quaternion.Lerp(Wheel3.transform.rotation, Right.rotation, -1 * Time.deltaTime);

            CarAnim.SetTrigger("Right");
        }
        if(!Input.GetKey("d") && !Input.GetKey("a"))
        {
            CarBody.transform.rotation = Quaternion.Lerp(CarBody.transform.rotation, Straight.rotation, 4 * Time.deltaTime);
        }

        //Drift Check

        if(CarBody.transform.localRotation.y * 100 > 50 || CarBody.transform.localRotation.y * 100 < -50)
        {
            Trail1.emitting = true;
            Trail2.emitting = true;
            Trail3.emitting = true;
            Trail4.emitting = true;

            if(DriftCheck == false)
            {
                DriftCheck = true;
                CarDriftSound.Play();
            }
        }
        else
        {
            Trail1.emitting = false;
            Trail2.emitting = false;
            Trail3.emitting = false;
            Trail4.emitting = false;

            DriftCheck = false;
        }

    }
}
