using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StatBar : MonoBehaviour
{
    [SerializeField]
    private Image statBarBase;
    [SerializeField]
    private Image statBarAmount;
    [SerializeField]
    private float statBarSpeed = 0.3f;

    public virtual void IncreaseStat(int currentStat, int maxStat)
    {
        if (statBarAmount.fillAmount >= 1) return;

        float statValue = (float)currentStat / (float)maxStat;

        StartCoroutine(AnimateHealthBar(statValue));
    }

    public virtual void DecreaseStat(int currentStat, int maxStat)
    {
        if (statBarAmount.fillAmount <= 0) return;

        float statValue = (float)currentStat / (float)maxStat;

        StartCoroutine(AnimateHealthBar(statValue));
    }

    private IEnumerator AnimateHealthBar(float endStat)
    {
        float timer = 0f;
        float startStat = statBarAmount.fillAmount;

        while (timer < 1f)
        {
            timer += Time.deltaTime / statBarSpeed;
            statBarAmount.fillAmount = Mathf.Lerp(startStat, endStat, timer);
            yield return null;
        }
    }
}