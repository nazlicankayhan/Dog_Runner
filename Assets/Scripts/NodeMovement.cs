using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    public Transform connectedNode;
    public static NodeMovement instance;
    public float NodeSpeed = 5;
    public Vector3 position;
    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        transform.position = new Vector3(
        Mathf.Lerp(transform.position.x, connectedNode.position.x ,
        Time.deltaTime * NodeSpeed),
        connectedNode.position.y ,
        connectedNode.position.z + 3f);
    }
}
