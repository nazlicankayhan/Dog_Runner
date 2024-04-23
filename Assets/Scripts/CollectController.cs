using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class CollectController : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        PlayerMovement.anims.Add(animator);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            var listC = ListControl.instance;
            other.gameObject.AddComponent<CollectController>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<NodeMovement>();
            if (listC.dogs.Count > 1)
            {
                other.gameObject.GetComponent<NodeMovement>().connectedNode = listC.dogs[listC.dogs.Count - 1].transform;
                StartCoroutine(MovetoPoint(other.gameObject, listC.dogs[listC.dogs.Count - 1].transform.position, 0.2f));
            }
            else
            {
                other.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
            }
            listC.dogs.Add(other.gameObject);
            other.gameObject.tag = "Collected";
            StartCoroutine(animationsStart());
        }
    }

    IEnumerator animationsStart()
    {
        yield return new WaitForSeconds(0.1f);

        foreach (var item in PlayerMovement.anims)
        {
            item.SetBool("Run", true);
        }


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

