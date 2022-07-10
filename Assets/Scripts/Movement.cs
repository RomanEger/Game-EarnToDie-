using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float petrol = 10f;

    public float speed;

    public float MaxSpeed;

    public float speedUp;

    public int MotorPower = 10000;

    public WheelJoint2D[] Wheels = new WheelJoint2D[2];

    JointMotor2D Motor;

    void Update()
    {
        //�������� ������ ������
        if (Input.GetKey(KeyCode.A) == true && Motor.motorSpeed < MaxSpeed / 3) 
        {
            Motor.motorSpeed = (Motor.motorSpeed + speedUp) + Time.deltaTime;

            Motor.maxMotorTorque = MotorPower;

            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            //�������� �������
            petrol -= 1 + Time.deltaTime;
            if (petrol == 0)
            {
                Debug.Log("Petrol is ended");

            }
        }
        //�������� ������ �����
        else if (Input.GetKey(KeyCode.D) == true && Motor.motorSpeed > -MaxSpeed) 
        {
            Motor.motorSpeed = (Motor.motorSpeed - speedUp) - Time.deltaTime;

            Motor.maxMotorTorque = MotorPower;

            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            //�������� �������
            petrol -= 1;
            if (petrol == 0)
            {
                Debug.Log("Petrol is ended");

            }
        }
        //����������, ���� �� ������ ������� ��������
        else if (Input.GetKey(KeyCode.D) != true && Motor.motorSpeed < 0)
        {
            Motor.motorSpeed = (Motor.motorSpeed + speedUp/4f) + Time.deltaTime;
            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
        }
        //����������, ���� �� ������ ������� ��������
        else if (Input.GetKey(KeyCode.A) != true && Motor.motorSpeed > 0)
        {
            Motor.motorSpeed = (Motor.motorSpeed - speedUp/4f) - Time.deltaTime;
            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
        }
        //������
        if (Input.GetKey(KeyCode.Space) == true && Motor.motorSpeed < 0)
        {
            Motor.motorSpeed = (Motor.motorSpeed + speedUp) + Time.deltaTime;
            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            Debug.Log("������ �����");
        }
        //������
        else if (Input.GetKey(KeyCode.Space) == true && Motor.motorSpeed > 0)
        {
            Motor.motorSpeed = (Motor.motorSpeed - speedUp) + Time.deltaTime;
            Wheels[0].motor = Motor;
            Wheels[1].motor = Motor;
            Debug.Log("������ �����");
        }

        speed = (int)(Motor.motorSpeed / -20);
        
    }

    void OnGUI()
    {
        GUIStyle styleTime = new GUIStyle();
        styleTime.fontSize = 20;
        styleTime.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 1200, 1200), speed + " ��/�", styleTime);
    }
}
