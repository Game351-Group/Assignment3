using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float impulseForce = 170000.0f;
    public float impulseTorque = 3000.0f;

    public GameObject hero;
    public float kickForce = 10f;

    Animator animController;
    Rigidbody rigidBody;
    int randomKick;
    bool isCrouching = false;
    public Collider leftLegCollider;
    public Collider rightLegCollider;
    public Collider leftFootCollider;
    public Collider rightFootCollider;

    // Start is called before the first frame update
    void Start()
    {
        // get references to the animation controller of hero
        // character and player's corresponding rigid body
        animController = hero.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();

        leftFootCollider.enabled = false;
        rightFootCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // W/A/S/D input as a combined rotation and movement vector
        Vector3 input = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // allow movement when input detected and not crouching
        if (input.magnitude > 0.001 && !animController.GetBool ("Crouch"))
        {
            // rotations are about y axis
            rigidBody.AddRelativeTorque(new Vector3(0, input.y * impulseTorque * Time.deltaTime, 0));
            // motion is forward/backward (about z axis)
            rigidBody.AddRelativeForce(new Vector3(0, 0, input.z * impulseForce * Time.deltaTime));
            animController.SetBool("Walk", true);
        }
        else
        {
            // crouching with 'C' key (only when not moving)
            animController.SetBool("Walk", false);
            if (Input.GetKeyDown(KeyCode.C))
            {
                isCrouching = !isCrouching; // Toggle crouching state
                animController.SetBool("Crouch", isCrouching);
            }
        }
        // Press SpaceBar to kick
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomKick = Random.Range(0, 3);
            animController.SetTrigger("Kick" + randomKick);
        }
    }

    public void StartKick()
    {
        leftLegCollider.enabled = true;
        rightLegCollider.enabled = true;
        leftFootCollider.enabled = true;
        rightFootCollider.enabled = true;
    }

    public void EndKick()
    {
        leftLegCollider.enabled = false;
        rightLegCollider.enabled = false;
        leftFootCollider.enabled = false;
        rightFootCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kickable"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 forceDirection = other.transform.position - transform.position;
                forceDirection.y = 0;
                rb.AddForce(forceDirection.normalized * kickForce, ForceMode.Impulse);
            }
        }
    }
}
