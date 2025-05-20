using UnityEngine;
using UnityEngine.UIElements;

public class SwordHitScript : MonoBehaviour
{
    private GameObject currentEnemy = null;
    private void OnTriggerStay(Collider other)
    {
        /*
        Debug.Log("OnTriggerStay entered with: " + other.name); 

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Detected object with tag Enemy");

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse button clicked");

                EnemyScript enemy = other.GetComponent<EnemyScript>();
                if (PickUpSword.isPickedUp && enemy != null)
                {
                    Debug.Log("EnemyScript component found");
                    enemy.TakeHit();
                }
                else
                {
                    Debug.LogWarning("EnemyScript component NOT found on Enemy object");
                }
            }
        }
        */


        
            if (other.CompareTag("Enemy") && PickUpSword.isPickedUp)
            {
                currentEnemy = other.gameObject;
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && currentEnemy != null)
            {
                EnemyScript enemy = currentEnemy.GetComponent<EnemyScript>();
                if (enemy != null)
                {
                    enemy.TakeHit();
                    currentEnemy = null; // כדי לא להרביץ לו שוב בטעות
                }
            }
        }
    


}


