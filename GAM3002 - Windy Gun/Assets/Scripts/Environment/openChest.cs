using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{

    public int refillPoint;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        animator.enabled = true;

        refillPoint -= refillPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
