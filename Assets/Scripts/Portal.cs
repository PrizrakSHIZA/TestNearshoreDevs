using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Rigidbody2D rb;
    public SkeletonAnimation skeleton;
    public PlayerMovement pm;

    public void FreePlayer()
    {
        pm.disableInput = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        skeleton.maskInteraction = SpriteMaskInteraction.None;
    }

    public void DestroyPortal()
    {
        Destroy(gameObject);
    }
}
