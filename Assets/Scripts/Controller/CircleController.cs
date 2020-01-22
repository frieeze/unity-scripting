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


   private float smooth = 5.0f;
   private float tiltAngle = 60.0f;

   private void Awake()
   {
      shapeHolder = transform;
   }
   // Start is called before the first frame update
   void Start()
   {
      StartCoroutine(UpdateSpheres());
   }
   // Update is called once per frame
   void Update()
   {

   }


   private IEnumerator UpdateSpheres()
   {
      while (true)
      {
         yield return new WaitForSeconds(0.1f);

         // Retrieve circle points
         List<Vector3> circlePoints = GetCirclePoints();

         // Smoothly tilts a transform towards a target rotation.
         float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
         float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;


         // Rotate the cube by converting the angles into a quaternion.
         Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);


         // Remove previously instantiated spheres
         foreach (Transform child in shapeHolder) Destroy(child.gameObject);

         // Instantiate new spheres
         foreach (Vector3 circlePoint in circlePoints)
            Instantiate(prefab, circlePoint, target, shapeHolder);
      }
   }

   private List<Vector3> GetCirclePoints()
   {
      List<Vector3> circlePoints = new List<Vector3>();

      for (int i = 0; i < numberOfPoints; i++)
      {
         float rad = 2 * Mathf.PI * i / numberOfPoints;
         circlePoints.Add(new Vector3(
             rotationCenter.x + radius * Mathf.Cos(rad),
             rotationCenter.y + radius * Mathf.Sin(rad),
             rotationCenter.z));
      }

      return circlePoints;
   }
}
