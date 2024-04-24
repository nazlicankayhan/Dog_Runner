using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public static List<Animator> anims = new List<Animator>();
    [SerializeField]
    public float forwardSpeed;
    private PlayerActions playerActions;
    bool isBeingPressed = false;
    private Animator animator;
    public bool isGameStarted = false;
    public bool isGameStop = false;
    [SerializeField]
    GameObject Completed, confetti,Retry,Hazýrlayanlar,Panel;

    private void Start()
    {
        instance = this;
        animator = GetComponentInChildren<Animator>();
        Debug.Log(animator.name);
        Completed.SetActive(false);
        confetti.SetActive(false);
        Hazýrlayanlar.SetActive(false);
        Panel.SetActive(false);
    }
    private void FixedUpdate()

    {
        if (isGameStarted == true)
        {
            forwardSpeed = 15f;
            Vector2 mousePos = playerActions.PlayerControl.DeltaPos.ReadValue<Vector2>();
            if (isBeingPressed)
            {
                transform.position = new Vector3((mousePos.x * Time.deltaTime * 10) + transform.position.x,
                transform.position.y, transform.position.z);

            }
            float xPosition = Mathf.Clamp(transform.position.x, 0f, 10f);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }

        if (!isGameStarted) return;


        else if (isGameStop == true)
        {
            forwardSpeed = 0;
        }
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);


    }

    private void OnEnable()
    {
        playerActions = new PlayerActions();
        playerActions.Enable();
        playerActions.PlayerControl.OnPointerDown.performed += (context) => Pressed();
        playerActions.PlayerControl.OnPointerUp.performed += (context) => NotPressed();
    }
    private void OnDisable()
    {
        playerActions.PlayerControl.OnPointerDown.performed -= (context) => Pressed();
        playerActions.PlayerControl.OnPointerUp.performed -= (context) => NotPressed();
    }

    public void RestartMovement()
    {
        isGameStop = false;
        isGameStarted = true;
        foreach (var item in PlayerMovement.anims)
        {
            item.SetBool("Run", true);
        }
        animator.SetBool("Run", true);
    }
    public void MainAnim()
    {
        anims.Clear();
        isGameStop = false;
        isGameStarted = true;
        animator.SetBool("Run",true);
    }

    public void StopMovement()
    {
        forwardSpeed = 0;
        isGameStarted = false;
        isGameStop = true;
        foreach (var item in PlayerMovement.anims)
        {
            item.SetBool("Run", false);
        }
        animator.SetBool("Run", false);
    }




  
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "EndStop")
        {
            Completed.SetActive(true);
            confetti.SetActive(true);
            Retry.SetActive(true);
            Hazýrlayanlar.SetActive(true);
            Panel.SetActive(true);
            StopMovement();
        }

    }


    private void Pressed()
    {
        isBeingPressed = true;
        Vector2 mousePos = playerActions.PlayerControl.DeltaPos.ReadValue<Vector2>();

    }
    private void NotPressed()
    {
        isBeingPressed = false;

    }



}
