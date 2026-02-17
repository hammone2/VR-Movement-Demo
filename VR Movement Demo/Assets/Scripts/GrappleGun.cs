using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public GameObject hook;
    public GameObject muzzle;
    public LineRenderer line;
    public GrappleController controller;

    private void Start()
    {
        line.positionCount = 2;
    }

    private void Update()
    {
        line.SetPosition(0,muzzle.transform.position);
        line.SetPosition(1, hook.transform.position);
    }

    public void Shoot()
    {
        Hook hookScript = hook.GetComponent<Hook>();

        if (!hookScript.isActive)
        {
            hookScript.Shoot(controller);
        }
        else
        {
            hookScript.Retract();
        }
    }


}
