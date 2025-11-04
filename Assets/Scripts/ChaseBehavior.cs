using UnityEngine;

public class ChaseBehavior : StateMachineBehaviour
{
    Rigidbody2D rigidbody;
    public Transform Player { get; set; }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigidbody = animator.gameObject.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Vector2 direction = (Player.position - animator.gameObject.transform.position).normalized;
        float directionX = Player.position.x - animator.gameObject.transform.position.x;
        Vector2 scale = animator.transform.localScale;
        if (directionX > 0)
        {
            rigidbody.linearVelocityX = 1;
            scale.x = 1;
        }
        else
        {
            rigidbody.linearVelocityX = -1;
            scale.x = -1;
        }
        animator.transform.localScale = scale;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigidbody.linearVelocityX = 0;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
