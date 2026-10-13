using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private Movement actions;
    private Vector2 moveDirection;
    private Rigidbody2D rigidBody;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        actions = new Movement();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ReadMovement();
    }


    private void OnEnable()
    {
        actions.Enable();

    }
    private void OnDisable()
    {
        actions.Disable();

    }
    private void ReadMovement()
    {

        moveDirection = actions.Movement2.Move.ReadValue<Vector2>().normalized;

        animator.SetBool("Moving", false);
        if (moveDirection == Vector2.zero) return;
        animator.SetBool("Moving", true);
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);

    }
    private void Move()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void FixedUpdate()
    {
        Move();
    }
}
