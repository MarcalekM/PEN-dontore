using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{ 
    private PlayerController player;
    [SerializeField] private Image healthbar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI skillPointsText;

    private float health;
    private float targetFillAmount;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        health = player.HP;
        targetFillAmount = Normalize(health, 0,player.MaxHP, 0.322f, 1);
        healthbar.fillAmount = targetFillAmount;
    }

    private void Update()
    {
        if (health != player.HP)
        {
            health = player.HP;
        }
        targetFillAmount = Normalize(health, 0,player.MaxHP, 0.322f, 1);
        healthbar.fillAmount = Mathf.Lerp(healthbar.fillAmount, targetFillAmount, Time.deltaTime);
        healthText.text = $"{Math.Floor(player.HP)}/{player.MaxHP}";
        skillPointsText.text = $"Képességpont: {player.SP}";

    }
    float Normalize(float val, float valmin, float valmax, float min, float max) 
    {
        return (((val - valmin) / (valmax - valmin)) * (max - min)) + min;
    }
}