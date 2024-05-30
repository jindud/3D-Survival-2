using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageIbe
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour , IDamageIbe
{
    public UICondition uICondition;
    public PlayerController controller;

    Condition health { get { return uICondition.health; } }
    Condition hurger { get { return uICondition.hunger; } }
    Condition stamina { get { return uICondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;

    // Update is called once per frame
    void Update()
    {
        hurger.Subtract(hurger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if(hurger.curValue == 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if(health.curValue == 0f)
        {
            Die(); 
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hurger.Add(amount);
    }

    public void Die()
    {
        Debug.Log("ав╬З╢ы!");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if(stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Subtract(amount);
        return true;
    }
}
