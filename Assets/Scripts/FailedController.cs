using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedController : MonoBehaviour
{
    [SerializeField]
    GameObject Failed, Retry;
    [SerializeField]
    float forwardSpeed ;
    public GameObject dogParent;

     Transform target;
    public float speed = 1;
    public Vector3 velocity= Vector3.zero;

    public PlayerMovement playerMovement;
     NodeMovement nodeMovement;
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Collected")
        {
            var ListC = ListControl.instance;
            ListC.b++;
            if (ListC.b == 1)
            {
                StartCoroutine(WaitAtTheObstacle());
            }
            foreach (var item in ListC.dogs)
            {
                Vector3 randomNewPosition = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10) + ListC.gameObject.transform.position.z);
                StartCoroutine(MovetoPoint( item, randomNewPosition, 0.3f));
                item.tag = "Collectable";
                item.GetComponent<BoxCollider>().isTrigger = true;
                Destroy(item.GetComponent<NodeMovement>());
                Destroy(item.GetComponent<CollectController>());
            }
            ListC.dogs.Clear();
            Score.score = 0;
        }
    }
    IEnumerator WaitAtTheObstacle()
    {
        playerMovement.StopMovement();
        dogParent.transform.position = new Vector3(dogParent.transform.position.x , dogParent.transform.position.y,
        dogParent.transform.position.z - 3f) ;
        yield return new WaitForSeconds(0.8f);
        playerMovement.RestartMovement();
    }
    public IEnumerator MovetoPoint(GameObject changePositionObject, Vector3 stopPos,
    float duration)
    {
        float elapsedTime = 0;
        var startPos = changePositionObject.transform.position;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            var progress = Mathf.Clamp01(elapsedTime / duration);

            changePositionObject.transform.position = Vector3.Lerp(startPos, stopPos, progress);

            yield return null;
        }
    }
}
