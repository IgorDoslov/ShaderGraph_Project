using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastToButton : MonoBehaviour
{
    private Camera fpsCam;
    public float buttonRange = 1000.0f;
    public LayerMask buttonLayer;

    // Start is called before the first frame update
    void Start()
    {
        fpsCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, buttonRange, buttonLayer))
                hit.transform.GetComponent<Button>().onClick.Invoke();
        }
    }
}
