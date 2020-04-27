using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public static float health;
    public GameObject LoosingScreen;

    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            LoosingScreen.SetActive(true);
        }
    }
}
