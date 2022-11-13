using Spine.Unity;
using UnityEngine;
using static EntityState;

public class PlayerAnimationController : MonoBehaviour
{
    #region Animations
    [Header("Animations")]
    [SpineAnimation, SerializeField] string idle;
    [SpineAnimation, SerializeField] string running;
    [SpineAnimation, SerializeField] string startJump;
    [SpineAnimation, SerializeField] string falling;
    [SpineAnimation, SerializeField] string attack_sword;
    [SpineAnimation, SerializeField] string attack_bow;
    [SpineAnimation, SerializeField] string die;
    #endregion

    SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimation;
    public Spine.Skeleton skeleton;

    //only for speed change
    public EntityState playerState;
    public PlayerMovement pm;

    bool jump = false;

    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimation = skeletonAnimation.AnimationState;
    }

    private void Update()
    {
        //Just thought if joystick could return not only -1 0 1 we could use it. Or given value could be forced to 1 or -1.
        if(playerState.CurrentState == States.running)
            spineAnimation.GetCurrent(0).TimeScale = Mathf.Abs(pm.InputMovement);
    }

    public void ChangeAnimation(States toState)
    {
        switch (toState)
        {
            case States.idle:
                spineAnimation.SetAnimation(0, idle, true);
                break;
            case States.running:
                spineAnimation.SetAnimation(0, running, true);
                break;
            case States.jump:
                spineAnimation.SetAnimation(0, startJump, false);
                spineAnimation.AddAnimation(0, falling, true, 0);
                // set variable jump to true, so when after jump state become 'inAir' animator will not set falling animation instantly
                // PS probably, I`ts better to use second track for doing 'Jump_Start' animation, but I`m not sure
                jump = true;
                break;
            case States.inAir:
                if (jump) { jump = false; return; }
                spineAnimation.SetAnimation(0, falling, true);
                break;
            case States.dead:
                spineAnimation.SetAnimation(0, die, false);
                break;
            default:
                break;
        }
    }

    public void SwordAttack()
    {
        spineAnimation.AddAnimation(1, attack_sword, false, 0);
        spineAnimation.AddEmptyAnimation(1, 0f, 0);
    }

    public void BowAttack()
    {
        spineAnimation.AddAnimation(1, attack_bow, false, 0);
        spineAnimation.AddEmptyAnimation(1, 0f, 0);
    }
}
