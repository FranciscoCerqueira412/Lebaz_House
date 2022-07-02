using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookAtTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Quaternion off;
    private void Update()
    {
        var point = target.position;
        
        transform.LookAt(point);
        transform.rotation *= Quaternion.Euler(off.eulerAngles);


    }
}
