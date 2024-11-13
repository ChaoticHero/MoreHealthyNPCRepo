using System;
using UnityEngine;

public class Healththatregenerates : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;

    private int currentHealth;
    private float timer;
    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHpPct
    {
        get { return (float)currentHealth / (float)startingHealth; }
    }

    public void TakeDamage(int amount)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

            currentHealth -= amount;

            OnHPPctChanged(CurrentHpPct);
        }
        if ((currentHealth < 0))
        {

        }
        if (CurrentHpPct <= 0)
            Die();
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(startingHealth / 10);
        }
    }
}