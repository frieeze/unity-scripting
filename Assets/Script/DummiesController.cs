using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummiesController : MonoBehaviour
{
    private Rigidbody dummyRigidbody;
    [SerializeField] private float speedModifier = 0.1f;

    private void Awake() {
        dummyRigidbody = GetComponent<Rigidbody>();
        StartCoroutine(MoveDummy());
    }
    // Start is called before the first frame update
    private IEnumerator MoveDummy() {
            while (true) {
                float duration = Random.Range(1f, 4f);
                float timer = 0f;
                Vector3 movement = new Vector3(Random.Range(-1f, 1f)* speedModifier,
                                            Random.Range(-0.1f, 0.1f),
                                            Random.Range(-1f, 1f)) * speedModifier;

                while (timer < duration) {
                    timer += Time.deltaTime;
                    dummyRigidbody.position += movement;
                    yield return new WaitForEndOfFrame();
                }
            }
        }
}
