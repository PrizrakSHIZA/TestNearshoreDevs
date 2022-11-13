using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;
    public PlayerAnimationController playerAnimationController;
    public FixedJoystick joystick;

    public bool disableInput = false;

    public float runSpeed = 40f;
    public float attackDelay = 0.5f;

    [HideInInspector] public float InputMovement = 0f;

    float horizontalMove = 0f;
    bool useJoystick = true;
    bool jump = false;
    bool canAttack = true;

    void Update()
    {
        // This hole Update method should be move to some InputManager script, like InputManagerPC, InputmanMagerMobile and etc. 
        if (disableInput) return;

        if (useJoystick)
            InputMovement = joystick.Horizontal;

        horizontalMove = InputMovement * runSpeed;
        #region PCInput
        /*
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
            jump = true;

        if (Input.GetKeyDown(KeyCode.F))
            AttackSword();

        if(Input.GetKeyDown(KeyCode.R))
            AttackBow();
        */
        #endregion
    }

    public void SetInputMovement(float val)
    {
        InputMovement = val;
    }

    public void Jump()
    {
        jump = true;
    }

    public void AttackSword()
    {
        if (!canAttack) return;
        StartCoroutine(AttackCoooldown(attackDelay));
        playerAnimationController.SwordAttack();
        // Some attack logic here
    }

    public void AttackBow()
    {
        if (!canAttack) return;
        StartCoroutine(AttackCoooldown(attackDelay));
        playerAnimationController.BowAttack();
        // Some attack logic here
    }

    IEnumerator AttackCoooldown(float time)
    { 
        canAttack = false;
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    public void ToggleInput(bool val)
    { 
        useJoystick = val;
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
