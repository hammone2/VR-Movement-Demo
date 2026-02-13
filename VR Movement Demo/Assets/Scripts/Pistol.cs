using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;


    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(muzzle.forward * 13f, ForceMode.Impulse);
        Destroy(bullet, 3f);
    }
}
