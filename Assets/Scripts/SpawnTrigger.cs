using UnityEngine;
using System.Collections;

public class SpawnTrigger : MonoBehaviour
{
    [HideInInspector]
    public bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            triggered = true;
            GetComponentInParent<HazardSpawner>().SpawnHazard();
        }
    }

    
}
