using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text bulletsText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Image reloadTimer;

    public void SetBulletsText(int value)
    {
        bulletsText.text = value.ToString();
    }

    public void SetHealthText(float value)
    {
        healthText.text = value.ToString();
    }

    public void ChangeReloadTimer(float time, float maxTime)
    {
        reloadTimer.fillAmount = time / maxTime;
    }
}
