using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private bool isJumping = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // 이동 상태 전달
    public void SetMove(bool isMoving)
    {
        animator.SetBool("Move", isMoving);  // 파라미터 이름 'Move'
    }

    // 점프 상태 전달
    public void SetJump(bool jump)
    {
        isJumping = jump;
        animator.SetBool("Jump", isJumping);  // 파라미터 이름 'Jump'
    }

    // 착지 시 호출
    public void OnLanded()
    {
        isJumping = false;
        animator.SetBool("Jump", false);
    }
}
