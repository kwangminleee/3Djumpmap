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

    // �̵� ���� ����
    public void SetMove(bool isMoving)
    {
        animator.SetBool("Move", isMoving);  // �Ķ���� �̸� 'Move'
    }

    // ���� ���� ����
    public void SetJump(bool jump)
    {
        isJumping = jump;
        animator.SetBool("Jump", isJumping);  // �Ķ���� �̸� 'Jump'
    }

    // ���� �� ȣ��
    public void OnLanded()
    {
        isJumping = false;
        animator.SetBool("Jump", false);
    }
}
