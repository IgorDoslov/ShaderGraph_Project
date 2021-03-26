using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<Animator>().gameObject.SetActive(false);

    }
}
