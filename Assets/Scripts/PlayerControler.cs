using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float deathRotation = 40;
    public float deathForce = .5f;
    public float fallDistance = .5f;
    public float fallDelay = .3f;
    public Rigidbody2D torso;
    public Rigidbody2D head;
    public Transform leftFoot;
    public Transform rightFoot;
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
        int layerMask = LayerMask.NameToLayer("Player");
        RaycastHit2D left = Physics2D.Raycast((Vector2)leftFoot.position, new Vector2(0.0f, -1.0f), fallDistance, layerMask);
        RaycastHit2D right = Physics2D.Raycast((Vector2)rightFoot.position, new Vector2(0.0f, -1.0f), fallDistance, layerMask);
        if (!left || !right)
            StartCoroutine(Fall());

        if (Mathf.Abs(torso.rotation) > deathRotation || Mathf.Abs(head.rotation) > deathRotation)
            Die();
    }

    public void Die()
    {
        dead = true;
        foreach (PlayerBalance b in balance)
            b.force = deathForce;
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        Die();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(leftFoot.position, new Vector3(0, -fallDistance, 0) + leftFoot.position);
        Gizmos.DrawLine(rightFoot.position, new Vector3(0, -fallDistance, 0) + rightFoot.position);
    }
}
