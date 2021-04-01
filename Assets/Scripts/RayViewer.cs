using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{

    public float weaponRange = 200.0f;
    private Camera fpsCam;
    RaycastHit hit;
    public GameObject target;
    public float lerpSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //fpsCam = GetComponentInParent<ThirdPersonCharacterController>().transform.gameObject.GetComponentInChildren<Camera>();
        fpsCam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lastPos = target.transform.position;

        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        { target.transform.position = Vector3.Lerp(lastPos, hit.point, lerpSpeed * Time.fixedDeltaTime); }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, weaponRange);
            target.transform.position = Vector3.Lerp(lastPos, ray.GetPoint(weaponRange), lerpSpeed * Time.fixedDeltaTime);
        }
    }
}
