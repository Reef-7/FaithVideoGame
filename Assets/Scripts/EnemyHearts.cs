using UnityEngine;

public class EnemyHearts : MonoBehaviour
{
    public GameObject[] hearts; 
    private EnemyScript enemy;
    private Camera cam;

    void Start()
    {
        enemy = GetComponentInParent<EnemyScript>();
        cam = Camera.main;
    }

    public void Update()
    {
        
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);

        
        if (enemy != null)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].SetActive(i < enemy.health);
            }
        }
    }
}
