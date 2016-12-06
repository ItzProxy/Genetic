using System;
using UnityEngine;

public class MuscleController : MonoBehaviour
{
    public Muscle muscleControl;
    // Use this for initialization

    protected virtual void Start()
    {
        Debug.Log(muscleControl.print());
        //transform.eulerAngles = new Vector3(0, 0, muscleControl.getRotationAngle());
    }
    protected virtual void Update()
    {

        if (muscleControl.getContractMotion())
        {
            transform.localScale -= new Vector3(muscleControl.getStrength(), 0, 0);
        }
        else
        {
            transform.localScale += new Vector3(muscleControl.getStrength(), 0, 0);
        }

    }
    protected virtual void LateUpdate()
    {
        muscleControl.changeContractMotion(transform.localScale.x);
    }
}