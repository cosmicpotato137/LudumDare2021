using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 mouseOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        mouseOffset = rb.position - PhysicalMouse.instance.GetPos();
        transform.SetParent(PhysicalMouse.instance.transform);
        PhysicalMouse.instance.hj.connectedBody = rb;
    }

    private void OnMouseUp()
    {
        transform.SetParent(null);
        PhysicalMouse.instance.hj.connectedBody = null;
    }
}
