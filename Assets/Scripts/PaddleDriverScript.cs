using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleDriverScript : MonoBehaviour
{
    public float hitPower = 0f;
    public float paddleDamper = 0f;
    public float upPosition = 45f;
    public float downPosition = 0f;

    public HingeJoint hinge;
    public string inputName;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring
        {
            spring = hitPower,
            damper = paddleDamper
        };
        spring.targetPosition = System.Math.Abs(Input.GetAxis(inputName)-1)
            <0.0001f ? upPosition : downPosition;

        hinge.spring = spring;
        hinge.useLimits = true;

    }
}
