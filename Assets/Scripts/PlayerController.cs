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
    public OwnerBehavior UIManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        UIManager = GameObject.Find("UIManager").GetComponent<OwnerBehavior>();
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
        /*  IMPORTANT NOTE: maybe stick with floats instead of integers because when instantly switching 
            from moving one side to the other the sprite doesnt change
        */
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Owner")){
            inProximity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Owner")){
            inProximity = false;
        }
    }
}
