using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public static CountdownTimer Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private int _countdownTime;

    private bool _isRunning = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        StartCountdown();
    }

    public void StartCountdown()
    {
        if (!_isRunning)
            StartCoroutine(Countdown());
    }

    private void OnTimerEnd()
    {
        return;
    }

    private IEnumerator Countdown()
    {
        _isRunning = true;
        int remainingTime = _countdownTime;

        while (remainingTime > 0)
        {
            _timerText.text = string.Format("{0:00}:{1:00}", remainingTime / 60, remainingTime % 60);
            yield return new WaitForSeconds(1);
            --remainingTime;
        }

        _isRunning = false;
        OnTimerEnd();
    }
}
