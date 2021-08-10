using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCamera : MonoBehaviour
{
    [SerializeField]
    Transform playerTranform;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3(0,0,-5) + playerTranform.position;
    }
}
