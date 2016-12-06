using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenBody : MonoBehaviour
{
    float scaled = 100f;
    int maxMuscles;
    int maxNodes;
    List<Transform> muscles;
    List<Transform> nodes;
    public Transform NodePrefab;
    public Transform MusclePrefab;
    // Use this for initialization
    void Start()
    {
        muscles = new List<Transform>();
        nodes = new List<Transform>();
        BuildABody();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
        }
    }
    private void BuildABody()
    {
        GameObject newParent = new GameObject("FullBody");
        bool startVertex = false;
        HashSet<int> checkNodes = new HashSet<int>();
        int randNodes = UnityEngine.Random.Range(2, 7);//gets a random number of nodes
        int randCalcMuscles = UnityEngine.Random.Range(randNodes - 1, ((randNodes * (randNodes - 1)) / 2));

        for (int i = 0; i < randNodes; i++)
        {
            Transform node = NodePrefab;
            node.transform.position = new Vector3(UnityEngine.Random.Range(-146, 146),
                                   UnityEngine.Random.Range(150, 500),
                                   600f);
            node.GetComponent<Rigidbody2D>().mass = UnityEngine.Random.Range(0f, 100f);
            Transform self = Instantiate(node, newParent.transform);

            nodes.Add(self);
        }
        for (int i = 0; i < randCalcMuscles; i++)
        {
            Transform muscle = MusclePrefab;
            float length = UnityEngine.Random.Range(4f, 10f);
            length = length * scaled;
            Muscle configureMuscleControl = new Muscle(UnityEngine.Random.Range(11f, 15f),
                length,
                UnityEngine.Random.Range(0f, length - 1),
                true);

            muscle.transform.position = new Vector3(UnityEngine.Random.Range(-146, 146),
                                   UnityEngine.Random.Range(60, 177),
                                   600f);

            muscle.localScale = new Vector3(length, transform.localScale.y, 0);
            Transform self = Instantiate(muscle, newParent.transform);
            self.GetComponent<MuscleController>().muscleControl = new Muscle(configureMuscleControl);
            self.GetComponent<MuscleController>().muscleControl.print();
            muscles.Add(self);
        }
        foreach (var numMuscle in muscles)
        {
            int leftNode = UnityEngine.Random.Range(0, randNodes);
            checkNodes.Add(leftNode);
            int rightNode = UnityEngine.Random.Range(0, randNodes);
            while(checkNodes.Contains(rightNode))
            {
                rightNode = UnityEngine.Random.Range(0, randNodes);
            }

            FixedJoint2D rightJoint = nodes[leftNode].gameObject.AddComponent<FixedJoint2D>();
            FixedJoint2D leftJoint = nodes[rightNode].gameObject.AddComponent<FixedJoint2D>();
            leftJoint.connectedBody = rightJoint.connectedBody  = numMuscle.GetComponent<Rigidbody2D>();
            leftJoint.autoConfigureConnectedAnchor = rightJoint.autoConfigureConnectedAnchor = false;
            leftJoint.connectedAnchor = new Vector2(-0.067f, 0);
            rightJoint.connectedAnchor = new Vector2(0.067f, 0);
            numMuscle.Rotate(0,0, UnityEngine.Random.Range(0, 360));
            numMuscle.GetComponent<MuscleController>().muscleControl.setRotation(numMuscle.rotation.eulerAngles);
            numMuscle.GetComponent<MuscleController>().muscleControl.setNodesConnected(leftJoint,rightJoint);
        }
    }
}
