using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int horizontalInput;
    [SerializeField] private int verticalInput;
    public int speed = 2;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    public bool inProximity = false;
    public bool tylenol = false;
    public OwnerBehavior UIManager;
    public CustomerBehavior customer1;
    public GameObject interactScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        UIManager = GameObject.Find("UIManager").GetComponent<OwnerBehavior>();
        interactScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // For Horizontal character movement
        if (Input.GetKey("d")){
            horizontalInput = 1;
        } else if (Input.GetKey("a")){
            horizontalInput = -1;
        } else {
            horizontalInput = 0;
        }
        
        // For Vertical character movement
        if (Input.GetKey("w")){
            verticalInput = 1;
        } else if (Input.GetKey("s")){
            verticalInput = -1;
        } else {
            verticalInput = 0;
        }
        
        playerRb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        playerAnimator.SetInteger("X", horizontalInput * speed);
        playerAnimator.SetInteger("Y", verticalInput * speed);
        
        if (Input.GetKeyDown("e") && inProximity){
            UIManager.StartDialogue();
        }
        if (Input.GetKeyDown("e") && tylenol){
            customer1.StartDialogue();
        }
        /*  IMPORTANT NOTE: maybe stick with floats instead of integers because when instantly switching 
            from moving one side to the other the sprite doesnt change
        */
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Owner")){
            inProximity = true;
            interactScreen.SetActive(true);
        }
        if (other.gameObject.CompareTag("Customer")){
            interactScreen.SetActive(true);
            tylenol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Owner")){
            inProximity = false;
            interactScreen.SetActive(false);
        }
        if (other.gameObject.CompareTag("Customer")){
            interactScreen.SetActive(false);
            tylenol = false;
        }
    }
}
