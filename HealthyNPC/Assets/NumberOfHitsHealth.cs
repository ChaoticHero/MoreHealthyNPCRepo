using System;
using System.Collections;
using UnityEngine;

public class NumberOfHitsHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int healthInHits = 5;

    [SerializeField]
    private float invulnerabilityTimeAfterEachHit = 5f;

    private int hitsRemaining;
    private bool canTakeDamage = true;

    public event Action<float> OnHPPctChanged = delegate (float f) { };
    public event Action OnDied = delegate { };

    public float CurrentHpPct
    {
        get { return (float)hitsRemaining / (float)healthInHits; }
    }

    private void Start()
    {
        hitsRemaining = healthInHits;
    }

    public void TakeDamage(int amount)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canTakeDamage)
            {
                StartCoroutine(InvunlerabilityTimer());

                hitsRemaining--;

                OnHPPctChanged(CurrentHpPct);

                if (hitsRemaining <= 0)
                    Die();
            }
        }
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }

    private IEnumerator InvunlerabilityTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invulnerabilityTimeAfterEachHit);
        canTakeDamage = true;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(healthInHits);
        }
    }
}