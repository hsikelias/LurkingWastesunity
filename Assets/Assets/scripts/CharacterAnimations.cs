using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;
    void Awake () {
        anim = GetComponent<Animator>();
    }
   
   public void Walk(bool Walk) {
       anim.SetBool(AnimationTags.WALK_PARAMETER,Walk);
   }
       public void Defend(bool Defend) {
        anim.SetBool(AnimationTags.DEFEND_PARAMETER,Defend);
       }

       public void Attack1() {
           anim.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
       }

       public void HeavyAttack() {
            anim.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
       }

}
   