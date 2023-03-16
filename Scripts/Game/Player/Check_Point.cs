using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Point : MonoBehaviour
{
    public Transform[] checkPoints;
    public List<GameObject> pos;
    private void Update()
    {
        if(transform.position.y < 20f)
        {
            transform.position = checkPoints[0].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == checkPoints[0].gameObject.tag)
        {
            checkPoints[0].transform.position = transform.position;

        }
    }
}
