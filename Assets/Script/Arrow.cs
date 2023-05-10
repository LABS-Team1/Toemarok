using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Arrow : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 1f;
    public float range = 5f;

    public Vector3 SpawnPosition { get; set; }

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        float distance = Vector2.Distance(transform.position, SpawnPosition);
        if (distance >= range)
        {
            Destroy(gameObject);
        }
    }
}
