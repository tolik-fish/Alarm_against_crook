using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Rigidbody))]
public class Thief : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Transform _escapeZone;

    private Vector3 _direction;
    private Mover _mover;

    private void Awake()
    {
        _direction = _cube.transform.position;
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _cube.Destroyed += GetEscapeZonePosition;
    }

    private void OnDisable()
    {
        _cube.Destroyed -= GetEscapeZonePosition;
    }

    private void Update()
    {
        _mover.Move(transform, _direction);
    }

    public void Activate() =>
        gameObject.SetActive(true);

    public void Deactivate() =>
        gameObject.SetActive(false);

    private void GetEscapeZonePosition() =>
        _direction = _escapeZone.position;
}