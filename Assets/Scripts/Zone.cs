using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Zone : MonoBehaviour
{
    public event Action Entered;
    public event Action Leaved;

    public Collider Collider { get; private set; }

    private void Awake()
    {
        Collider = GetComponent<Collider>();
        Collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out _))
            Entered?.Invoke();
    }

    private void OnTriggerExit()
    {
        Leaved?.Invoke();
    }
}