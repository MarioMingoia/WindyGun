using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public newMoveandRotate mr;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("floor"))
            return;

        mr.setGrounded(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("floor"))
            return;
        mr.setGrounded(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("floor"))
            return;
        mr.setGrounded(true);
    }
}
