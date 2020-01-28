using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    [SerializeField] private GameObject prefab = default;
    [SerializeField] private Transform ballsParentTransform = default;
    private Transform cameraTransform;
    [SerializeField] private float spawningSpeed = 0.5f;
    [SerializeField] private float spawningForce = 10f;


    private void Awake()
    {
        cameraTransform = transform;

    }


    // Start is called before the first frame update
    private IEnumerator DoSpawnBalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawningSpeed);
            GameObject ball = Instantiate(
                                prefab,
                                cameraTransform.position,
                                Quaternion.identity,
                                ballsParentTransform);
            ball.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * spawningForce);
        }
    }

    public void SpawnBall()
    {
        GameObject ball = Instantiate(
                               prefab,
                               cameraTransform.position,
                               Quaternion.identity,
                               ballsParentTransform);
        ball.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * spawningForce);
    }
}
