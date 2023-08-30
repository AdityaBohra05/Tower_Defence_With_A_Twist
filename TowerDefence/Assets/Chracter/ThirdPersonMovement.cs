using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform BaseTransform;

    public Transform cam;

    public float speed =6;

    public float turnSmoothTime = 1.1f;

    public float jumpHeight =3f;
    public float gravity = -300.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    float turnSmoothVelocity;

    Vector3 velocity;
    bool isGround;

    //public Animator mAnimator;

    void Start()
    {
       // mAnimator = GetComponent<Animator>();
    }
    

    void Update()
    {

        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        

       if(Input.GetButtonDown("Jump") && isGround)
       {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -1.5f * gravity);
            
       

       }

      
      

        

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;// + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(BaseTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            BaseTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);

           // mAnimator.SetBool("isWalking", true);

        }

        else 
        {
           // mAnimator.SetBool("isWalking", false);
        }
    }
}
