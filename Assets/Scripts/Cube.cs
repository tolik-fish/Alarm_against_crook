using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Cube : MonoBehaviour
{
    public event Action Destroyed;

    private void OnCollisionEnter()
    {
        Destroyed?.Invoke();

        Destroy(gameObject);
    }
}