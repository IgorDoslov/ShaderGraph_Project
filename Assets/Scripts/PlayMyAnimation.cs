using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMyAnimation : MonoBehaviour
{
    public Animator anim;
    public string trigger;
    public string tagKeyword;
    public GameObject triggerEffect;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagKeyword))
        {
            Instantiate(triggerEffect, transform.position, Quaternion.identity);

            anim.SetBool(trigger, true);
        }
    }


}
