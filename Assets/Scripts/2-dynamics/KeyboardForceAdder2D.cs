using UnityEngine;
/**
 *  This component allows the player to add force to its object using the arrow keys.
 *  Works with a 2D RigidBody.
 */
[RequireComponent(typeof(Rigidbody2D))]
public class KeyboardForceAdder2D : MonoBehaviour
{
    [Tooltip("The magnitude of the force to add in each frame, in newtons.")]
    [SerializeField] float forceSize = 5f;
    [Tooltip("Force = continuous & mass; Acceleration = continuous & no mass; Impulse = instant & mass; VelocityChange = instant & no mass.")]
    [SerializeField] ForceMode2D forceMode = ForceMode2D.Force;
    private Animator _animator;
    private Rigidbody2D rb;
    private bool _facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Flip();
        AnimationControl();
    }

    /*
     * Note that updates related to the physics engine should be done in FixedUpdate and not in Update!
     */
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector3(horizontal * forceSize, 0, 0), forceMode);
    }

    private void Flip()
    {
        if (_facingRight && rb.velocity.x < 0)
        {
            _facingRight = !_facingRight;
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (!_facingRight && rb.velocity.x > 0)
        {
            _facingRight = !_facingRight;
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void AnimationControl()
    {
        if(rb.velocity.x > 0 || rb.velocity.x < 0) // case where character is moving
            _animator.SetBool("Run",true);
        else
            _animator.SetBool("Run",false);
    }
}