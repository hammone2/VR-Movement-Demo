using UnityEngine;

public class Hook : MonoBehaviour
{

    public bool isActive = false;

    private Rigidbody rb;
    private GrappleController controller;
    private Transform muzzle;

    private bool _isHooked = false;
    public bool isHooked
    {
        set
        {
            _isHooked = value;
            if (_isHooked)
            {
                rb.useGravity = false;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                controller.BeginGrapple(transform);

            }
            else
            {
                rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        muzzle = transform.parent;
    }

    public void Shoot(GrappleController controller)
    {
        transform.SetParent(null);
        isActive = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(muzzle.forward * 13f, ForceMode.Impulse);
        this.controller = controller;
    }

    public void Retract()
    {
        transform.SetParent(muzzle);
        isActive = false;
        isHooked = false;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
            return;

        

        isHooked = true;
    }
}
