using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = health;
    }

    private void OnTargetHit(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth < 0) Destroy(gameObject);
    }
}
