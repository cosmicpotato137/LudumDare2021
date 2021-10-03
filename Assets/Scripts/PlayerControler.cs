using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float deathRotation = 40;
    public Rigidbody2D torso;
    public CircleCollider2D head;
    public bool dead = false;

    Animator anim;
    PlayerBalance[] balance;

    bool idle = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        balance = GetComponentsInChildren<PlayerBalance>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(balance.Length);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!idle)
            {
                anim.speed = walkSpeed;
                anim.SetBool("Idle", false);
                idle = true;
            }
            else
            {
                anim.speed = 1.0f;
                anim.SetBool("Idle", true);
                idle = false;
            }
        }

    }

    private void FixedUpdate()
    {
        if (torso.rotation > deathRotation || torso.rotation < -1 * deathRotation)
        {
            Die();
        }

    }

    public void Die()
    {
        dead = true;
        foreach (PlayerBalance b in balance)
            b.enabled = false;
    }

    public void Live()
    {
        dead = false;
        foreach (PlayerBalance b in balance)
            b.enabled = false;
    }
}
