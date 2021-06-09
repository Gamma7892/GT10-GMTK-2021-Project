using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{

    [SerializeField] UnityEvent thingToTrigger;

    [Tooltip("Never activates at 0, always active at 1.")]
    [SerializeField] float DecimalTriggerRate = 0;

    void OnTriggerEnter(Collider bruh)
    {
        if (Random.Range(0f, 1f) > DecimalTriggerRate)
            thingToTrigger.Invoke();
    }
}
