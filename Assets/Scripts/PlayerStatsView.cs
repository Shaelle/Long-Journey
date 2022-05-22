using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsView : MonoBehaviour
{

    [SerializeField] StatPanel health;
    [SerializeField] StatPanel food;
    [SerializeField] StatPanel water;

    private void OnEnable()
    {
        PlayerConditions.OnHealthChanged += HealthChanged;
        PlayerConditions.OnFoodChanged += FoodChanged;
        PlayerConditions.OnWaterChanged += WaterChanged;
    }


    private void OnDisable()
    {
        PlayerConditions.OnHealthChanged -= HealthChanged;
        PlayerConditions.OnFoodChanged -= FoodChanged;
        PlayerConditions.OnWaterChanged -= WaterChanged;
    }

    private void HealthChanged(float maxValue, float value) => health.SetValue(maxValue, value);

    private void FoodChanged(float maxValue, float value) => food.SetValue(maxValue, value);

    private void WaterChanged(float maxValue, float value) => water.SetValue(maxValue, value);

}
