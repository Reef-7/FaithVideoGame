using UnityEngine;
public class FmsScript : MonoBehaviour
{
    CharacterController controller;
    public Transform cameraTransform; // 2 camera
    public float playerSpeed = 5;

    public float mouseSensitivity = 3;  //1
    Vector2 look;


    Vector3 velocity; // 7 person
    float mass = 1f;
    public float jumpSpeed = 5f;
    //character

    public bool isPaused = false;


    Animator animator; //Animation controller
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        //2 locked mouse
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        if (isPaused)
            return;


        UpdateLook(); //2
        UpdateMovement();  //3
        UpdateGravity();   //4
    }

    void UpdateLook()
    {   //2
        look.x += Input.GetAxis("Mouse X") * mouseSensitivity;   //2 camera
        look.y += Input.GetAxis("Mouse Y") * mouseSensitivity; //2  camera
        //Returns rotation z,x,y degrees around the z,x,y applied in that order.
        look.y = Mathf.Clamp(look.y, -90, 90);
        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0); //2.1
        transform.localRotation = Quaternion.Euler(0, look.x, 0); //2   player
     }
    void UpdateMovement()
    {   //3
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var input = new Vector3();
        input += transform.forward * z;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1f);

        animator.SetBool("isWalking", input.magnitude > 0.1f); //animation update

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y += jumpSpeed;
        }
        controller.Move((input * playerSpeed/*9*/ + velocity) * Time.deltaTime);
    }
    private void UpdateGravity()
    {     //4  

        var gravity = Physics.gravity * mass * Time.deltaTime;
        //Check CharacterController touching the ground during the last move?
        velocity.y = controller.isGrounded ? -1 : velocity.y + gravity.y;
    }
}
