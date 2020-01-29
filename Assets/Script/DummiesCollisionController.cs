using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummiesCollisionController : MonoBehaviour
{
    private LayerMask sphereLayer;
    private Transform parent;

    private void Awake() {
        parent = transform.parent;
        sphereLayer = LayerMask.NameToLayer("Projectile");
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == sphereLayer){
            Destroy(other.gameObject);
            if(parent.name == "MisterBean_v2(Clone)"){
                Destroy(parent.gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
}
