using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private BallShooting ballShooting;

    private float yawn = 0.0f;
    private float pitch = 0.0f;

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
        cameraTransform.position += new Vector3(Input.GetAxis("Horizontal")*speed,
                                                0f,
                                                Input.GetAxis("Vertical")*speed);
        if(Input.GetButtonDown("Fire1")){ 
            ballShooting.SpawnBall();
        } 

    
        yawn += Input.GetAxis("Mouse X")*5f;
        pitch -= Input.GetAxis("Mouse Y")*5f;
        if(pitch<-90f) pitch = -90f;
        else if(yawn >90f) yawn = 90f;
        cameraTransform.eulerAngles = new Vector3(pitch,yawn,0f);


    }
}
