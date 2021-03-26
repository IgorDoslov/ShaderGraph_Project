using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour
{

    public int currentHealth = 1;
    public float forceMultiplier = 5.0f;
    Ragdoll r;
    [SerializeField]
    bool isAlreadyDead = false;
    public bool isScoreAttack = false;

    public void Damage(int damageAmount, RaycastHit hit, float hitForce)
    {
        r = gameObject.GetComponentInParent<Ragdoll>();
        if (hit.rigidbody == r.rigidbodies[10])
        {
            currentHealth -= damageAmount;

            Destroy(hit.rigidbody.GetComponent<CharacterJoint>());

        }
        else
            currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            hit.rigidbody.AddForce(-hit.normal * hitForce);
            //gameObject.SetActive(false);
            RagDoll();
            if (isAlreadyDead == false)
            {
                if (isScoreAttack == true)
                    ScoreControl.shooterScore++;
                isAlreadyDead = true;
            }
        }
    }

    public void Damage(int damageAmount)
    {
        r = gameObject.GetComponentInParent<Ragdoll>();

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {

            //gameObject.SetActive(false);
            RagDoll();
            if (isAlreadyDead == false)
            {
                if (isScoreAttack == true)
                    ScoreControl.shooterScore++;
                isAlreadyDead = true;
            }
        }
    }

    public void RagDoll()
    {
        if (r != null)
        {
            r.RagdollOn = true;
        }
    }

}
