using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedSon : MonoBehaviour
{
    [SerializeField]
    GameObject Failed, Retry;

    public PlayerMovement playerMovement;

    private void OnCollisionEnter(Collision collision)
    {
        var ListC = ListControl.instance;
        if (collision.collider.tag == "Obstacle")
        {
            ListControl.instance.a++;
            Debug.Log("a = " + ListControl.instance.a);
        }
        if (ListControl.instance.a >= 3)
        {
            playerMovement.StopMovement();
            Failed.SetActive(true);
            Retry.SetActive(true);
        }
        if (ListC.b == 1)
        {
            collision.collider.tag = "obstacle";
        }
    }
}
