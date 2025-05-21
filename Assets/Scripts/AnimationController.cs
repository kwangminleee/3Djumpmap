using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private bool lastMove = false;
    private bool lastJump = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMove(bool isMoving)
    {
        if (isMoving != lastMove)
        {
            animator.SetBool("Move", isMoving);
            Debug.Log($"{isMoving} ?");
            lastMove = isMoving;
        }
    }

    public void SetJump(bool jump)
    {
        if (jump != lastJump)
        {
            animator.SetBool("Jump", jump);
            Debug.Log($"{jump} !");
            lastJump = jump;
        }
    }

    public void OnLanded()
    {
        SetJump(false);
    }
}
