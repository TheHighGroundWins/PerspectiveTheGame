using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingRotation : MonoBehaviour
{
    [SerializeField]
    GameObject viewButton;
    float speed = -50;
    float totalRotation = 0;

    void Start()
    {
        viewButton.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GlobalVars.gameStarted&&totalRotation<360)
        {

            transform.Rotate(new Vector3(0,speed*Time.deltaTime,0));
            totalRotation++;
        }
        else
        {
            GlobalVars.gameStarted = true;
            viewButton.SetActive(true);
            Destroy(gameObject);
        }
    }
}
