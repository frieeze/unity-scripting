using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    private Transform cameraTransform;

    private void Awake() {
        cameraTransform = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Physics.Raycast(cameraTransform.position,cameraTransform.forward,Mathf.infinity);
    }
}
