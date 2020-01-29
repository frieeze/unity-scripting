using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDummies : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;

    [SerializeField] private int dummiesNumber = 20;
    [SerializeField] private float spawningTime = 1f;

    [SerializeField] private GameObject dummiePrefab = default;

    private Transform dummiesParentTransform = default;

    private void Awake() {
        dummiesParentTransform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawningTime);
            if(dummiesParentTransform.childCount < dummiesNumber){
                Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

                GameObject Dummie = Instantiate(dummiePrefab,
                                                pos,
                                                Quaternion.identity,
                                                dummiesParentTransform);
            }   
        }
    }
}
