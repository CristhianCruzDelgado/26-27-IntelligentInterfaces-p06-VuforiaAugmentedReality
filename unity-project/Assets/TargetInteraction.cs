using UnityEngine;

public class TargetInteraction : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnTargetFound()
    {
        if (animator != null)
        {
            animator.SetBool("isDetected", true);
        }
    }
    public void OnTargetLost()
    {
        if (animator != null)
        {
            animator.SetBool("isDetected", false);
        }
    }
}
