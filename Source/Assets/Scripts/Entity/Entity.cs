using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class Entity : NetworkBehaviour
{
    [SyncVar(hook = nameof(SetUI))]
    public float health = 100;

    public TextMeshPro healthText;

    public void HealthMinus(float damage)
    {
        health -= damage;
        if (health <= damage)
            Destroy(gameObject);
    }

    public void SetUI(float oldValue, float newValue)
    {
        if (healthText == null) return;

        healthText.text = newValue.ToString();
    }

    public void Hurt(float damage)
    {
        HealthMinus(damage);
    }
}
