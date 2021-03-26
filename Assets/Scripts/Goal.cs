using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Material awakeMat = null, sleepingMat = null;
    Color currentColour;
    public GameObject goalEffect;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = sleepingMat;
        currentColour = Camera.main.backgroundColor;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (awakeMat != null)
                GetComponent<MeshRenderer>().material = awakeMat;
            Camera.main.backgroundColor = Color.green;
            Instantiate(goalEffect, transform.position, Quaternion.identity);

            ScoreControl.goalScore++;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (sleepingMat != null)
            GetComponent<MeshRenderer>().material = sleepingMat;
        Camera.main.backgroundColor = currentColour;


    }
}
