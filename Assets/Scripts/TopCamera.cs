using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCamera : MonoBehaviour
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
         transform.position= new Vector3(0, 5, 0)+ playerTranform.position;
    }
}
