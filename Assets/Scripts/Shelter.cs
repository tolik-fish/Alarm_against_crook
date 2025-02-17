using UnityEngine;

public class Shelter : MonoBehaviour
{
    [SerializeField] private Zone _zone;
    [SerializeField] private Thief _thief;

    private void OnEnable()
    {
        _zone.Entered += Hide;
    }

    private void OnDisable()
    {
        _zone.Entered -= Hide;
    }

    private void Hide() =>
        _thief.Deactivate();
}