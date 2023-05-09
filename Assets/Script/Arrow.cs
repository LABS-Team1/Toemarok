using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 1f;

    private void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()    
    {
        Destroy(gameObject);
    }

}
