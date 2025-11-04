using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DragonAI : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    Transform player;

    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ChaseBehavior chaseBehavior = animator.GetBehaviour<ChaseBehavior>();
        chaseBehavior.Player = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerIsVisible(bool isVisible)
    {
        animator.SetBool("PlayerIsVisible", isVisible);
    }
}
