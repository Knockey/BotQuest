using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    private const float MaxFillAmount = 1f;
    private const float MinFillAmount = 0f;
    private const float StopTimerAnimationTime = 0.2f;

    [SerializeField] private Image _image;

    private Coroutine _fillingCoroutine;

    public void StartTimer(int time)
    {
        if (_fillingCoroutine != null)
            StopCoroutine(_fillingCoroutine);

        _fillingCoroutine = StartCoroutine(FillTimerImage(time, MaxFillAmount));
    }

    public void StopTimer()
    {
        if(_fillingCoroutine != null)
            StopCoroutine(_fillingCoroutine);

        _fillingCoroutine = StartCoroutine(FillTimerImage(StopTimerAnimationTime, MinFillAmount));
    }

    private IEnumerator FillTimerImage(float time, float targetValue)
    {
        float elapsedTime = 0;
        float startValue = _image.fillAmount;

        while (elapsedTime < time)
        {
            _image.fillAmount = Mathf.Lerp(startValue, targetValue, elapsedTime / time);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _image.fillAmount = targetValue;
    }
}
