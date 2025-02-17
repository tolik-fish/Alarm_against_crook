using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    public event Action DelayArrived;

    public IEnumerator CountDown()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            DelayArrived.Invoke();

            yield return wait;
        }
    }

    public void StartTimer() =>
        _coroutine = StartCoroutine(CountDown());

    public void Stop() =>
            StopCoroutine(_coroutine);
}