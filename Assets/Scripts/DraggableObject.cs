using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 mouseOffset;
    Transform previousParent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void OnMouseDown()
    {
        mouseOffset = rb.position - PhysicalMouse.instance.GetPos();
        previousParent = transform.parent;
        transform.SetParent(PhysicalMouse.instance.transform);
        PhysicalMouse.instance.hj.connectedBody = rb;
    }

    private void OnMouseUp()
    {
        transform.SetParent(previousParent);
        PhysicalMouse.instance.hj.connectedBody = null;
    }
}
