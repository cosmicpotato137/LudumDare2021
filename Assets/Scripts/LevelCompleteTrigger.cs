using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    [HideInInspector]
    public bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            triggered = true;
            GetComponentInParent<GameControler>().levelComplete = true;
            Debug.Log("triggered");
        }
    }
}
