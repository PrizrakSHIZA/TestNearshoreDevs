using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    public PlayerAnimationController playerAnimationController;

    public bool disableInput = false;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        if (disableInput) return;

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
            jump = true;

        if (Input.GetKeyDown(KeyCode.F))
            AttackSword();

        if(Input.GetKeyDown(KeyCode.R))
            AttackBow();
    }

    public void AttackSword()
    {
        // some delay logic, if its needed
        playerAnimationController.SwordAttack();
        // Some attack logic here
    }

    public void AttackBow()
    {
        // some delay logic, if its needed
        playerAnimationController.BowAttack();
        // Some attack logic here
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
