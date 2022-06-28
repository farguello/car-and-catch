using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private int playerCurrentLane = 1;
    private bool isOnGround = true;

    public float jumpForce = 10.0f;
    public float gravityModifier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        transform.position = Vector3.up;
        playerCurrentLane = 1;

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    void MovePlayer()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && playerCurrentLane != 0)
        {
            transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
            playerCurrentLane--;
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && playerCurrentLane != 2)
        {
            transform.position = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
            playerCurrentLane++;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
}
