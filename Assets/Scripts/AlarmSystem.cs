using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Timer))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _volumeStep;
    [SerializeField] private Zone _zone;

    private float _minVolume = 0.01f;

    private AudioSource _audioSource;
    private Timer _timer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _zone.Entered += Activate;
        _zone.Leaved += ReverseStep;
    }

    private void OnDisable()
    {
        _zone.Entered -= Activate;
        _zone.Leaved -= ReverseStep;
    }

    private void Activate()
    {
        PlaySound();

        _timer.DelayArrived += ChangeVolume;

        _timer.StartTimer();
    }

    private void PlaySound()
    {
        _audioSource.Play();
        _audioSource.volume = _minVolume;
    }

    private void ChangeVolume()
    {
        _audioSource.volume += _volumeStep;

        if (_audioSource.volume == 0f)
        {
            _timer.Stop();

            _timer.DelayArrived -= ChangeVolume;
        }
    }

    private void ReverseStep() =>
        _volumeStep *= -1f;
}