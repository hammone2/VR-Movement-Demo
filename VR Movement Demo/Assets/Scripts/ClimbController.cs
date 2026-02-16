using UnityEngine;

public class ClimbController : MonoBehaviour
{
    public GameObject xrRig;

    private int grabCount;
    private Rigidbody rb;
    private float groundLevel;

    private void Start()
    {
        if (xrRig == null)
            xrRig = GameObject.Find("XR Origin (XR Rig)");

        grabCount = 0;
        rb = xrRig.GetComponent<Rigidbody>();
        groundLevel = xrRig.transform.position.y;
    }

    private void Update()
    {
        if (xrRig.transform.position.y <= groundLevel)
        {
            Vector3 pos = xrRig.transform.position;
            pos.y = groundLevel;
            xrRig.transform.position = pos;
            rb.isKinematic = true;
        }
    }

    public void Grab()
    {
        grabCount++;
        rb.isKinematic = true;
    }

    public void Pull(Vector3 distance)
    {
        xrRig.transform.Translate(distance);
    }

    public void Release()
    {
        grabCount--;
        if (grabCount == 0)
        {
            rb.isKinematic = false;
        }
    }
}
