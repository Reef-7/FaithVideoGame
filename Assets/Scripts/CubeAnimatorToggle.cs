using UnityEngine;

public class CubeAnimatorToggle : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool current = animator.GetBool("IsPulsing");
            animator.SetBool("IsPulsing", !current);
        }
    }
}
