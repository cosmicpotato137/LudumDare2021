using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsibleFloor : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool drop;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(drop){
            dropFloor();
        }
    }

    public void dropFloor(){
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
