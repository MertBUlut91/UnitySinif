using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float duration;
    private float dashCooldown;
    public Image cooldownImage;

    void Start()
    {
        cooldownImage.fillAmount = 0f;
        dashCooldown = Movement.dashCooldown;
    }

    void Update()
    {
        Timer();
    }
    public void Timer()
    {
        if (Movement.dashed)
        {
            duration -= Time.deltaTime;
            cooldownImage.fillAmount = Mathf.InverseLerp(dashCooldown, 0, duration);
        }
        else
        {
            cooldownImage.fillAmount = 0;
            duration = 2.5f;
        }
    }
}
