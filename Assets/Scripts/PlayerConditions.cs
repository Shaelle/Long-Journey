using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerConditions : MonoBehaviour
{
    private enum ParameterType { Health, Food, Water}

    public static Action<float, float> OnHealthChanged;
    public static Action<float, float> OnFoodChanged;
    public static Action<float, float> OnWaterChanged;

   // private delegate 

    public static Action OnGameOver;

    [Header("Health")]
    [SerializeField] [Range(1, 100)] float startHealth = 30;
    [SerializeField] [Range(1, 300)] float maxHealth = 100;

    [Header("Food")]
    [SerializeField] [Range(1, 100)] float startFood = 40;
    [SerializeField] [Range(1, 300)] float maxFood = 100;

    [SerializeField] [Range(1, 5)] float hungerSpeed = 1.2f;

    [Header("Water")]
    [SerializeField] [Range(1, 100)] float startWater = 40;
    [SerializeField] [Range(1, 300)] float maxWater = 100;

    [SerializeField] [Range(1, 5)] float dehydrationSpeed = 2;
    [SerializeField] [Range(1, 50)] float drinkSpeed = 10;

    float _health;
    float health
    {
        get
        {
            return _health;
        }      
        set
        {
            _health =  SetParameter(maxHealth,value,ParameterType.Health);
        }
    }

    float _food;
    float food
    {
        get
        {
            return _food;
        }

        set
        {          
            _food = SetParameter(maxFood,value,ParameterType.Food);
        }
    }

    float _water;
    float water
    {
        get
        {
            return _water;
        }

        set
        {
            _water = SetParameter(maxWater,value,ParameterType.Water);
        }
    }

    bool isDrinking = false;


    
    private float SetParameter(float maxValue, float value, ParameterType type)
    {
        value = Mathf.Clamp(value, 0, maxWater);

        switch (type)
        {
            case ParameterType.Health:
                OnHealthChanged?.Invoke(maxValue, value);
                break;

            case ParameterType.Food:
                OnFoodChanged?.Invoke(maxValue, value);
                break;

            case ParameterType.Water:
                OnWaterChanged?.Invoke(maxValue, value);
                break;

            default:
                break;
        }

       if (value == 0) OnGameOver?.Invoke();
        return value;
    }
    



    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        food = startFood;
        water = startWater;
    }

    // Update is called once per frame
    void Update()
    {
        if (food > 0) food -= hungerSpeed * Time.deltaTime;

        if (isDrinking) water += drinkSpeed * Time.deltaTime;
        else if (water > 0) water -= dehydrationSpeed * Time.deltaTime;
    }


    public void Eat(float amount)
    {
        food += amount;
    }


    public void Drink()
    {
        isDrinking = true;
    }

    public void StopDrink()
    {
        isDrinking = false;
    }
}
