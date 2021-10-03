using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalMouse : MonoBehaviour
{
    public static PhysicalMouse instance;

    [HideInInspector]
    public HingeJoint2D hj;
    [HideInInspector]
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        hj = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnValidate()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = GetMousePos();
        rb.velocity = (GetMousePos() - new Vector2(instance.transform.position.x, instance.transform.position.y)) * 10;
        transform.position = rb.position;
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    public Vector2 GetPos()
    {
        return (Vector2)transform.position;
    }

}
