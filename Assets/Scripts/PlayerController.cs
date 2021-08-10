using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerBody;
    const float speed = 10;
    const float jumpForce = 5;
    bool canJump = true;
    bool TopDown = false;
    bool firstSpawn = true;

    GameObject spawnPoint2D;

    [SerializeField]
    GameObject topCamera;
    [SerializeField]
    GameObject sideCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVars.gameStarted)
        {
            if (firstSpawn)
            {
                topCamera.SetActive(true);
                TopDown = true;
                firstSpawn = false;
            }

            float zAxis = Input.GetAxis("Vertical") * speed;
            float xAxis = Input.GetAxis("Horizontal") * speed * -1;
            if (TopDown)
            {
                playerBody.AddForce(new Vector3(zAxis, 0, xAxis), ForceMode.Force);
                if (Input.GetButtonDown("Jump") && canJump)
                {
                    playerBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                }
            }
            else
            {
                playerBody.AddForce(new Vector3(xAxis * -1, 0, 0), ForceMode.Force);
                if (Input.GetButtonDown("Jump") && canJump)
                {
                    playerBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                }
            }
        }
    }

    public void ChangeCameraView()
    {
        if(TopDown)
        {
            TopDown = false;
            playerBody.constraints = RigidbodyConstraints.FreezePositionZ;
            topCamera.SetActive(false);
            sideCamera.SetActive(true);
        }
        else
        {
            TopDown = true;
            playerBody.constraints = RigidbodyConstraints.FreezePositionY;
            sideCamera.SetActive(false);
            topCamera.SetActive(true);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Platform")
        {
            canJump = true;
        }

        if(collision.collider.tag=="Trophy")
        {
            Transform parentTransform = GameObject.FindWithTag("MainCanvas").GetComponent<Transform>();
            Instantiate<GameObject>((GameObject)Resources.Load("YouWon"),parentTransform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Platform")
        {
            canJump = false;
        }
    }
    
}
