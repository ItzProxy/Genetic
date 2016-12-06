using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Muscle : MuscleController
{
    //Muscle variables
    protected float strength;//how fast does it contract per frame ie contracts 3 units/sec relative to the internal clock
    protected float maxLength;//how long the muscle is
    protected float minLength;//how far does it contract before it has to relax
    protected bool isContractMotion; //is the object contracting
    protected Vector3 rotation; //rotation
    FixedJoint2D[] NodeConnected = new FixedJoint2D[2];//only 2 nodes can connect to a muscle

    //Game
    GameObject self;
    //Muscle
    public Muscle()
    {
        strength = 0;
        maxLength = 1F;
        minLength = 1F;
        isContractMotion = true;
    }
    public Muscle(float _strength, float _length, float _contractionLength, bool _isContractMotion)
    {
        strength = _strength;
        maxLength = _length;
        minLength = _contractionLength;
        isContractMotion = _isContractMotion;
    }

    public Muscle(Muscle otherMuscle)//deep copy 
    {
        strength = otherMuscle.strength;
        maxLength = otherMuscle.maxLength;
        minLength = otherMuscle.minLength;
        isContractMotion = otherMuscle.isContractMotion;
    }
    //Muscle Functions
    //setters
    public void setNodesConnected(FixedJoint2D leftNode, FixedJoint2D rightNode)
    {
        NodeConnected[0] = leftNode;
        NodeConnected[1] = rightNode;
    }
    public void setRotation(Vector3 angle)
    {
        rotation = angle;
    } 
    //getters
    public float getStrength()
    {
        return strength;
    }
    public bool getContractMotion()
    {
        return isContractMotion;
    }
    public float getLength()
    {
        return maxLength;
    }
    public float getContractionlength()
    {
        return minLength;
    }
    public Vector3 getRotationAngle()
    {
        return rotation;
    }
    //Muscle Functions
    public void changeContractMotion(float muscleCurrentLen)
    {
        if(muscleCurrentLen > maxLength)
        {
            isContractMotion = true;
        }
        if(muscleCurrentLen < minLength)
        {
            isContractMotion = false;
        }
    }
    public string print()
    {
        string form = "Strength: " + strength +
            "\n rotation: (" + rotation.x + "," + rotation.y + "," + rotation.z + ")" +
            "\n length: " + maxLength +
            "\n contractionLength: " + minLength +
            "\n isContracting: " + isContractMotion;
        return form;
    }
}