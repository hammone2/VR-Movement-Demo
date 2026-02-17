using UnityEngine;

public class GrappleController : MonoBehaviour
{
    public GameObject locomotion;
    public float deactivationDistance = 1f;
    public float grappleSpeed = 7f;
    private Rigidbody rb;
    private bool isGrappled = false;
    private Transform hookPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        GrappleMovement();
    }

    private void GrappleMovement()
    {
        if (!isGrappled)
            return;

        transform.position = Vector3.MoveTowards(transform.position, hookPos.position, Time.deltaTime * grappleSpeed);
        if (Vector3.Distance(transform.position, hookPos.position) <= deactivationDistance)
            EndGrapple();
    }

    public void BeginGrapple(Transform hookPos)
    {
        rb.useGravity = false;
        locomotion.SetActive(false);
        isGrappled = true;
        this.hookPos = hookPos;
    }

    public void EndGrapple()
    {
        isGrappled = false;
        rb.useGravity = true;
        locomotion?.SetActive(true);
        hookPos.GetComponent<Hook>().Retract();
    }
}
