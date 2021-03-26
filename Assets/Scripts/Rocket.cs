using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 10;
    Rigidbody rb;
    public int damageAmount = 100;
    public float radius = 5.0f;
    public float explosionForce = 10000.0f;
    Vector3 targetPoint;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);


        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            ShootableBox sb = nearbyObject.GetComponent<ShootableBox>();
            if (rb != null && sb != null)
            {
                sb.Damage(damageAmount);
                rb.AddExplosionForce(explosionForce, transform.position, radius);
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
        }

        if (collision.rigidbody != null)
            collision.rigidbody.AddForce(-collision.contacts[0].normal * 1000);

        gameObject.SetActive(false);
    }

    public void SetTarget(Vector3 target)
    {
        targetPoint = target;
    }
}
