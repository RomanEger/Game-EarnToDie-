using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float nitro = 1000f;

    public float petrol = 1000f;

    public float speed;

    public float MaxSpeed;

    public float nitroUp;

    public float speedUp;

    public int MotorPower = 10000;

    public WheelJoint2D[] Wheels = new WheelJoint2D[2];

    JointMotor2D Motor;

    void Update()
    {
        //Ускорение при движении вперед
        if(Input.GetKey(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.W) == true && Motor.motorSpeed > -MaxSpeed * 1.5f) 
        {
            
            if (nitro > 0)
            {
                nitro -= 1;

                Motor.motorSpeed = (Motor.motorSpeed - nitroUp) - Time.deltaTime;

                Motor.maxMotorTorque = MotorPower;

                Wheels[0].motor = Motor;
                Wheels[1].motor = Motor;

                Debug.Log("Nitro is using");
            }
        }

        //накопление нитро
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            if (nitro < 1000f)
            {
                nitro += 0.1f;
            }
        }

        //проверка топлива
        if (Input.GetKey(KeyCode.W) == true | Input.GetKey(KeyCode.S) == true)
        {
            
            petrol -= 0.05f;
            if (petrol <= 0)
            {
                Debug.Log("Petrol is ended");
                Motor.motorSpeed = 0;

                Wheels[0].motor = Motor;
                Wheels[1].motor = Motor;
            }
        }
        

        //движение машины НАЗАД
        if (Input.GetKey(KeyCode.S) == true && Motor.motorSpeed < MaxSpeed / 3) 
        {
            Motor.motorSpeed = (Motor.motorSpeed + speedUp) + Time.deltaTime;

            Motor.maxMotorTorque = MotorPower;

            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            
        }

        //движение машины ВПЕРЕД
        else if (Input.GetKey(KeyCode.W) == true && Motor.motorSpeed > -MaxSpeed) //&& Input.GetKey(KeyCode.LeftShift) == false) 
        {
            Motor.motorSpeed = (Motor.motorSpeed - speedUp) - Time.deltaTime;

            Motor.maxMotorTorque = MotorPower;

            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            
        }


        //торможение, если не нажаты клавиши движения
        else if (Input.GetKey(KeyCode.W) != true && Motor.motorSpeed < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) == false && Motor.motorSpeed < -MaxSpeed) //&& Input.GetKey(KeyCode.S) == false)
            {
                Motor.motorSpeed = (Motor.motorSpeed + nitroUp / 3f) + Time.deltaTime;
                Wheels[0].motor = Motor;
                Wheels[1].motor = Motor;
                petrol -= 0.001f;
            }
            else {
                Motor.motorSpeed = (Motor.motorSpeed + speedUp / 4f) + Time.deltaTime;
                Wheels[0].motor = Motor;
                Wheels[1].motor = Motor;
                petrol -= 0.001f;
            }
        }

        //торможение, если не нажаты клавиши движения
        else if (Input.GetKey(KeyCode.S) != true && Motor.motorSpeed > 0)
        {
            Motor.motorSpeed = (Motor.motorSpeed - speedUp/4f) - Time.deltaTime;
            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            petrol -= 0.001f;
        }


        //тормоз
        if (Input.GetKey(KeyCode.Space) == true && Motor.motorSpeed < 0)
        {
            Motor.motorSpeed = (Motor.motorSpeed + speedUp) + Time.deltaTime;
            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            Debug.Log("Тормоз нажат");
        }

        //тормоз
        else if (Input.GetKey(KeyCode.Space) == true && Motor.motorSpeed > 0)
        {
            Motor.motorSpeed = (Motor.motorSpeed - speedUp) + Time.deltaTime;
            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            Debug.Log("Тормоз нажат");
        }

        
        //спидометр   //надо сделать правильнее
        speed = (int)(Motor.motorSpeed / -20);
        
    }

    void OnGUI()
    {
        GUIStyle styleTime = new GUIStyle();
        styleTime.fontSize = 20;
        styleTime.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 1200, 1200), speed + " км/ч", styleTime);
    }
}
