using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
        private Transform shapeHolder;
        [SerializeField] private GameObject prefab = default;
        [SerializeField] private Vector3 rotationCenter = default;
        [SerializeField] private float radius = 2f;
        [SerializeField] private int numberOfPoints = 6;

    private void Awake() {
        shapeHolder = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateSpheres());
    }

    private IEnumerator UpdateSpheres() {
        while (true) {
            yield return new WaitForSeconds(0.1f);

            // Retrieve circle points
            List<Vector3> circlePoints = GetCirclePoints();

            // Remove previously instantiated spheres
            foreach (Transform child in shapeHolder) Destroy(child.gameObject);

            // Instantiate new spheres
            foreach (Vector3 circlePoint in circlePoints)
                Instantiate(prefab, circlePoint, Quaternion.identity, shapeHolder);
        }
    }

    private List<Vector3> GetCirclePoints() {
        List<Vector3> circlePoints = new List<Vector3>();

        for (int i = 0; i < numberOfPoints; i++) {
            float rad = 2 * Mathf.PI * i / numberOfPoints;
            circlePoints.Add(new Vector3(
                rotationCenter.x + radius * Mathf.Cos(rad),
                rotationCenter.y + radius * Mathf.Sin(rad),
                rotationCenter.z));
        }

        return circlePoints;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
