using UnityEngine;

[RequireComponent(typeof(Animator))]
public class KnightController : MonoBehaviour
{
    Animator _animator;

    [SerializeField]
    [Range(1, 10)]
    float speed = 1;

    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vx = Input.GetAxisRaw("Horizontal");
        if (vx != 0)
        {
            _animator.SetBool("IsMoving", true);
            gameObject.transform.Translate(speed * vx * Time.deltaTime, 0, 0);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        if (Input.GetButton("Fire1"))
        {
            _animator.SetTrigger("Attacking");
        }


        //_animator.SetTrigger("Death");
    }

    void LateUpdate()
    {

    }
}
