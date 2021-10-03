using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public int dragSpeed = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag(){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        rb.velocity = (mousePos - new Vector2(transform.position.x, transform.position.y)) * dragSpeed;
    }
}
