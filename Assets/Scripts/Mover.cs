using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Transform obj, Vector3 destination) =>
        obj.position = Vector3.MoveTowards(obj.position, destination, _speed * Time.deltaTime);
}