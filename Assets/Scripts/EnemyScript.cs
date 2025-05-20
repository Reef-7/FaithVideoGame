using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 7;
    private WinScript winManager;
    public EnemyHearts enemyHearts;
    private void Start()
    {
        
        winManager = FindObjectOfType<WinScript>();
    }
    public void TakeHit()
    {
        health--;
        Debug.Log("Enemy hit! Health left: " + health);

        if (enemyHearts != null)
            enemyHearts.Update(); // לא חובה – יש Update קבוע


        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy defeated!");
        Destroy(gameObject);
        winManager.ShowWinScreen();
    }
}
