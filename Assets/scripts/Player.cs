using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private bool isOnGround;
    private float jumpBoostRemaining;
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        score = Score.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");

    }

    // Update iscalled once every physics update
    private void FixedUpdate()
    {

        rigidBodyComponent.velocity = new Vector3(horizontalInput * 2, rigidBodyComponent.velocity.y, 0);
        if (isOnGround)
        {
            if (jumpKeyWasPressed)
            {
                float jumpForce = 5;
                if (jumpBoostRemaining > 0)
                {
                    jumpForce *= 2;
                    jumpBoostRemaining--;
                    score.SetScore(jumpBoostRemaining.ToString());
                }

                rigidBodyComponent.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                jumpKeyWasPressed = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isOnGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Destroy(other.gameObject);
            jumpBoostRemaining++;
            score.SetScore(jumpBoostRemaining.ToString());
        }

        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            jumpBoostRemaining = 0;
            score.SetScore("over");
            Application.Quit();
        }
    }


}