using UnityEngine;
using System.Collections;
public class Poppable : MonoBehaviour
{
    public GameObject popEffectPrefab;
    [HideInInspector] public bool popEnabled = false;

    void OnCollisionEnter(Collision collision)
    {
        if (transform.parent == null &&
          collision.gameObject.GetComponent<Poppable>() == null)
        {
            //PopBalloon();
            if (popEnabled)
                Destroy(gameObject);
        }
    }

    private void PopBalloon()
    {
        if (!popEnabled)
            return;

        if (popEffectPrefab != null)
        {
            GameObject effect = Instantiate(popEffectPrefab,
               transform.position, transform.rotation);
            Destroy(effect, 1f);
        }
        //Destroy(gameObject);
    }

    public void EnablePop()
    {
        StartCoroutine(PopTimer());
    }

    IEnumerator PopTimer()
    {
        yield return new WaitForSeconds(0.75f);
        popEnabled = true;
    }

    private void OnDestroy()
    {
        PopBalloon();
    }
}
