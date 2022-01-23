using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    Vector2 forward;
    private void Start()
    {
        forward = transform.TransformDirection(Vector2.up) * 5;
        
    }
    void Update()
    {
        Vector2 vector = new Vector2(transform.position.x, transform.position.y);
        Debug.DrawRay(vector, forward, Color.red);

        RectTransform rt = (RectTransform)transform;

        RaycastHit2D hit = Physics2D.Raycast(vector, Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {
            Debug.Log(string.Format("Collided with: {0}", hit.collider.name));
        }
    }
}
