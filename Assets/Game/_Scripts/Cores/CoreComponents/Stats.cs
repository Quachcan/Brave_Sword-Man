using System;
using UnityEngine;

namespace Game._Scripts.Cores.CoreComponents
{
    public class Stats : CoreComponent
    {
        public event Action OnHealthZero;
        
        [SerializeField] private float maxHealth;
        [SerializeField] private float currentHealth;

        protected override void Awake()
        {
            base.Awake();
            
            currentHealth = maxHealth;
        }

        public void DecreaseHealth(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            currentHealth -= amount;
            
            if (currentHealth > 0) return;
            currentHealth = 0;
            
            OnHealthZero?.Invoke();
            
            Debug.Log("Health zero");
        }
        
        public void IncreaseHealth(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            currentHealth += amount;
        }

        public void RestoreFullHealth()
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            currentHealth = maxHealth;
        }
    }
}
