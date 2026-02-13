using UnityEngine;
using System.Collections;

public class ResetAfterDelay : MonoBehaviour
{
    public float delaySeconds = 5f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void Reset()
    {
        StartCoroutine(AfterDelay());
    }

    IEnumerator AfterDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        transform.position = startPosition;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}