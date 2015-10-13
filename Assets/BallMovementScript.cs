using UnityEngine;
using System.Collections;

public class BallMovementScript : MonoBehaviour
{

    float mouseSpeed = 5.0f;
    public float xDistance = 5, zDistance = 5, yPosition = 1.5f;
    public Transform targetCamera;

    public float pushForce = 20;
    public float jumpForce = 50.0f;

    float originalPushForce;
    float xpos, zpos;

    bool grounded = true;
    bool buttonDown = false;
    Vector3 reverseDirection;

    float groundCheckDistance = 0.7f;


    void Start()
    {
        originalPushForce = pushForce;
    }


    void Update()
    {
        CheckGroundStatus();

        if (PauseScript.showOptions)
        {
            mouseSpeed = PauseScript.mouseSensitivity;
        }
    }
    

    void FixedUpdate()
    {

        if (!grounded)
        {
            pushForce = originalPushForce / 5;
        }
        else
        {
            pushForce = originalPushForce;
        }

        if (Input.GetMouseButton(1))
        {
            targetCamera.LookAt(transform);
            targetCamera.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * mouseSpeed);
        }


        if (transform.rigidbody.velocity.magnitude < 50)
        {
            transform.rigidbody.AddForce(targetCamera.right * Input.GetAxis("Horizontal") * pushForce);
            transform.rigidbody.AddForce(targetCamera.forward * Input.GetAxis("Vertical") * pushForce);
        }


        if (Input.GetKey(KeyCode.S)) {
            if (!buttonDown)
            {
                reverseDirection = -targetCamera.forward;
            }
            buttonDown = true;
            transform.rigidbody.AddForce(reverseDirection * pushForce * 0.5f);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            buttonDown = false;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                transform.rigidbody.AddForce(new Vector3(0, jumpForce, 0));
            }
        }

        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) ||
            (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) ||
            (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) ||
            (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)))
        {
            pushForce = originalPushForce / 2;
        }
        else
        {
            pushForce = originalPushForce;
        }

        //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        //{
        //    pushForce = originalPushForce / 2;
        //}
        //else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        //{
        //    pushForce = originalPushForce / 2;
        //}
        //else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        //{
        //    pushForce = originalPushForce / 2;
        //}
        //else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        //{
        //    pushForce = originalPushForce / 2;
        //}
        //else
        //{
        //    pushForce = originalPushForce;
        //}


        //how far do you want camera to be placed on the x-axis
        xpos = -xDistance * targetCamera.forward.x;
        //how far do you want camera to be placed on the z-axis
        zpos = -zDistance * targetCamera.forward.z;
        targetCamera.position = Vector3.Lerp(targetCamera.position, (transform.position + new Vector3(xpos, yPosition, zpos)), 0.1f);
        //spotLight.position.y = targetCamera.position.y;
        //spotLight.position.x = transform.position.x;
        //spotLight.position.z = transform.position.z;
        targetCamera.LookAt(transform);

    }

    //void OnCollisionEnter(Collision collider)       // NOT WORKING PROPERLY ON RAMPS
    //{
    //    if (collider.gameObject.tag == "Ground")
    //    {
    //        Debug.Log("Grounded");
    //        grounded = true;
    //    }
    //}
    //void OnCollisionExit(Collision collider)
    //{
    //    if (collider.gameObject.tag == "Ground")
    //    {
    //        Debug.Log("In air");
    //        grounded = false;
    //    }
    //}

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * groundCheckDistance));

        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
        {
            grounded = true;
            //Debug.Log("Grounded");
            if (hitInfo.collider.tag.Equals("Booster"))
            {
                BoosterScript.onBooster = true;
            }
            else
            {
                BoosterScript.onBooster = false;
            }
        }
        else
        {
            BoosterScript.onBooster = false;
            grounded = false;
            //Debug.Log("In air");
        }
    }

}