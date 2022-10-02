using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = health;
        StartCoroutine(WaitUntilGameControllerSet());
    }

    public void OnTargetHit(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameControl.main.DeleteTargetFromList(this);
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitUntilGameControllerSet()
    {
        yield return new WaitUntil(() => GameControl.main != null);
        GameControl.main.AddTargetToList(this);
    }
}
