using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazard;
    public Vector2 velocity;
    public SpawnTrigger spawnTrigger;

    public void ResetTrigger()
    {
        spawnTrigger.triggered = false;
    }

    public void SpawnHazard()
    {
        GameObject hazardInstance = Instantiate(hazard, transform);
        hazardInstance.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, velocity + (Vector2)transform.position);
    }
}
