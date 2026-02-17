using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public GameObject hook;
    public Transform muzzle;
    public GrappleController controller;

    private bool isShot = false;

    public void Shoot()
    {
        if (!isShot)
        {
            Rigidbody rb = hook.GetComponent<Rigidbody>();
            rb.AddForce(muzzle.forward * 13f, ForceMode.Impulse);
            hook.GetComponent<Hook>().Shoot(controller);
            isShot = true;
        }
        else
        {
            hook.GetComponent<Hook>().Retract();
            isShot = false;
        }
    }
}
