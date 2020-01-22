using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseController : MonoBehaviour
{
   private Transform shapeHolder;
   [SerializeField] private GameObject prefab = default;
   [SerializeField] private Vector3 rotationCenter = default;
   [SerializeField] private float width = 2f;
   [SerializeField] private float height = 5f;
   [SerializeField] private int numberOfPoints = 6;
   [SerializeField] private Vector3 rotationSpeed = new Vector3(1,1,1);

   private Vector3 rotationAngle = default;

   private void Awake()
   {
      shapeHolder = transform;
   }
   // Start is called before the first frame update
   void Start()
   {
      StartCoroutine(UpdateShapes());
   }

   private IEnumerator UpdateShapes()
   {
      while (true)
      {
         yield return new WaitForSeconds(0.01f);

         // Retrieve circle points
         List<Vector3> circlePoints = GetEllipsePoints();


         // Rotate the cube by converting the angles into a quaternion.
         Quaternion target = Quaternion.Euler(rotationAngle);

         // Remove previously instantiated spheres
         foreach (Transform child in shapeHolder) Destroy(child.gameObject);

         // Instantiate new spheres
         foreach (Vector3 circlePoint in circlePoints)
            Instantiate(prefab, circlePoint, target, shapeHolder);

         rotationAngle = new Vector3( 
            (rotationAngle.x + rotationSpeed.x*0.1f)%360,
            (rotationAngle.y + rotationSpeed.y*0.1f)%360,
            (rotationAngle.z + rotationSpeed.z*0.1f)%360 
            );

      }
   }

   private List<Vector3> GetEllipsePoints()
   {
      List<Vector3> circlePoints = new List<Vector3>();

      for (int i = 0; i < numberOfPoints; i++)
      {
         float rad = 2 * Mathf.PI * i / numberOfPoints;
         circlePoints.Add(new Vector3(
             rotationCenter.x + width * Mathf.Cos(rad),
             rotationCenter.y + height * Mathf.Sin(rad),
             rotationCenter.z));
      }

      return circlePoints;
   }
}