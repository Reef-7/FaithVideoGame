using UnityEngine;

public class PickUpSword : MonoBehaviour
{
  
        public Transform handTransform;  
        private bool pickedUp = false;  
        private bool playerInRange = false;
        public static bool isPickedUp = false;


    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true; 
                Debug.Log("Player is in range of the sword");
            }
        }

        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false; 
                Debug.Log("Player exited the range of the sword");
            }
        }

        
        private void Update()
        {
            
            if (playerInRange && !pickedUp && Input.GetKeyDown(KeyCode.Z))
            {
                PickUp();  
            }
        }

        
        private void PickUp()
        {
            
            transform.SetParent(handTransform);


        transform.localPosition = new Vector3(0f, 0f, 0.2f);
        transform.localRotation = Quaternion.identity;

            
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;  
                rb.detectCollisions = true;  
            }

            
            Collider col = GetComponent<Collider>();
            if (col != null)
            {
            col.enabled = true;
            col.isTrigger = true;
            }

            pickedUp = true;
            isPickedUp = true;

        Debug.Log("Sword picked up!");
        }
    }

