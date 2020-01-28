using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDummies : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;

    [SerializeField] private float spawningTime = 1f;

    [SerializeField] private GameObject dummiePrefab = default;

    [SerializeField] private Transform dummiesParentTransform = default;


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
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

            GameObject Dummie = Instantiate(dummiePrefab,
                                            pos,
                                            Quaternion.identity,
                                            dummiesParentTransform);
        }
    }
}
