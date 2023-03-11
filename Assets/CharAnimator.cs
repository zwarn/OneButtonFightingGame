using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimator : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public Animator animator;
    [SerializeField] Transform ball;
    private float ballScale;



    private void Start()
    {
        animator = GetComponent<Animator>();
        ballScale = ball.localScale.x;
    }

    void Update()
    {
        animator.SetFloat("Forwards", playerController.HorizontalVelocity());
        animator.SetFloat("Vertical", playerController.VerticalVelocity());
        ball.localScale = new Vector3(ballScale * (playerController.right ? 1 : -1),ballScale,ballScale);

    }
}
