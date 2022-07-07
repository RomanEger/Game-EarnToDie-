using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int MaxSpeed;

    public int speedUp;

    public int MotorPower = 10000;

    public WheelJoint2D[] Wheels = new WheelJoint2D[2];

    JointMotor2D Motor;

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 && Motor.motorSpeed < MaxSpeed/3) //GetAxisRaw; <0
        {
            Motor.motorSpeed = (Motor.motorSpeed + speedUp) + Time.deltaTime;
            
            Motor.maxMotorTorque = MotorPower;

            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && Motor.motorSpeed > -MaxSpeed) //GetAxisRaw; >0
        {
            Motor.motorSpeed = (Motor.motorSpeed - speedUp) - Time.deltaTime;

            Motor.maxMotorTorque = MotorPower;

            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (Motor.motorSpeed > 0)
            {
                Motor.motorSpeed = (Motor.motorSpeed - speedUp) - Time.deltaTime;
            }
            else if (Motor.motorSpeed < 0)
            {
                Motor.motorSpeed = (Motor.motorSpeed + speedUp) + Time.deltaTime;
            }
        }
        /*{
            if (Motor.motorSpeed > 0)
            {
                Motor.motorSpeed = (Motor.motorSpeed - speedUp) - Time.deltaTime;
            }
            else if (Motor.motorSpeed < 0)
            {
                Motor.motorSpeed = (Motor.motorSpeed + speedUp) + Time.deltaTime;
            }
        }*/
        
        
        /*if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }*/
    }
}