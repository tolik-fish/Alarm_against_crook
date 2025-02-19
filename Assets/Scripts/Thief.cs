using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Rigidbody))]
public class Thief : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Transform _escapeZone;

    private Vector3 _destination;
    private Mover _mover;

    private void Awake()
    {
        _destination = _cube.transform.position;
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
        _mover.Move(transform, _destination);
    }

    public void Activate() =>
        gameObject.SetActive(true);

    public void Deactivate() =>
        gameObject.SetActive(false);

    private void GetEscapeZonePosition() =>
        _destination = _escapeZone.position;
}