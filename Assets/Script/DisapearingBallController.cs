using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearingBallController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name =="Plane") Destroy(gameObject);
        
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
