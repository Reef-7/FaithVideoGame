using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    public GameObject targetCube;  
    private Renderer cubeRenderer;
    private Color originalColor;

    private void Start()
    {
        if (targetCube != null)
        {
            cubeRenderer = targetCube.GetComponent<Renderer>();
            if (cubeRenderer != null)
            {
                originalColor = cubeRenderer.material.color; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cubeRenderer != null)
        {
            cubeRenderer.material.color = Color.red;  
            Debug.Log("Player entered trigger, cube turned red.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && cubeRenderer != null)
        {
            cubeRenderer.material.color = originalColor; 
            Debug.Log("Player exited trigger, cube color restored.");
        }
    }
}
