using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaycastShoot : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = 0.125f;
    public float weaponRange = 50f;
    public float hitForce = 20000f;
    public Transform gunEnd;
    public Color tintColour = Color.yellow;
    public GameObject child;
    public Transform parent;
    public GameObject shotEffect;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
    private LineRenderer laserLine;
    private float nextFire;


    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<ThirdPersonCharacterController>().transform.gameObject.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RayShoot();
    }

    public void RayShoot()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (PauseMenu.gameIsPaused == true)
                return;

            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                Instantiate(shotEffect, hit.point, Quaternion.identity);

                ShootableBox health = hit.collider.GetComponentInParent<ShootableBox>();

                if (health != null)
                {
                    health.Damage(gunDamage, hit, hitForce);

                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);

                }

            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange, layerMask))
            {
                    child.transform.position = parent.position;
                    child.transform.SetParent(parent);
            }
        }
    }


    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

}
