using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityToDestroy : MonoBehaviour
{
    public bool canDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("WindArea"))
        {
            canDestroy = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Contains("WindArea"))
        {
            canDestroy = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("WindArea"))
        {
            StartCoroutine(waittillDestroyed());
        }
    }

    IEnumerator waittillDestroyed()
    {
        yield return new WaitForSeconds(0.5f);
        canDestroy = false;
    }
}
