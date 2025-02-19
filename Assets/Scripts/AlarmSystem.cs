using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _volumeStep;
    [SerializeField] private float _delay;
    [SerializeField] private Zone _zone;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private AudioSource _audioSource;
    private Coroutine _coroutineIncreaseVolume;
    private Coroutine _coroutineDecreaseVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _zone.Entered += Activate;
        _zone.Leaved += Deactivate;
    }

    private void OnDisable()
    {
        _zone.Entered -= Activate;
        _zone.Leaved -= Deactivate;
    }

    private void Activate()
    {
        if (_coroutineDecreaseVolume != null)
            StopCoroutine(_coroutineDecreaseVolume);

        _audioSource.Play();
        _audioSource.volume = _minVolume;

        _coroutineIncreaseVolume = StartCoroutine(ChangeValueVolume(_maxVolume));
    }

    private void Deactivate()
    {
        if (_coroutineIncreaseVolume != null)
            StopCoroutine(_coroutineIncreaseVolume);

        _coroutineDecreaseVolume = StartCoroutine(ChangeValueVolume(_minVolume));
    }

    private IEnumerator ChangeValueVolume(float target)
    {
        var wait = new WaitForSeconds(_delay);

        while (Mathf.Approximately(_audioSource.volume, target) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _volumeStep);
            yield return wait;
        }

        if (_audioSource.isPlaying && _audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}