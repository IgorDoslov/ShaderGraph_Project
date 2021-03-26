using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysObject : MonoBehaviour
{

    public Material awakeMat = null, sleepingMat = null;

    private Rigidbody rb = null;

    private bool wasAsleep = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.IsSleeping() && !wasAsleep && sleepingMat != null)
        {
            wasAsleep = true;
            GetComponent<MeshRenderer>().material = sleepingMat;
        }
        if (!rb.IsSleeping() && wasAsleep && awakeMat != null)
        {
            wasAsleep = false;
            GetComponent<MeshRenderer>().material = awakeMat;
        }
    }
}
