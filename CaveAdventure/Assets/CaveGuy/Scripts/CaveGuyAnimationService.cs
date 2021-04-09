namespace CaveAdventure.CaveGuy
{
    using APPack;
    using UnityEngine;

    public class CaveGuyAnimationService : MonoBehaviour
    {
        public Animator CaveGuyAnimator;

        public void OnAwake()
        {
            CaveGuyAnimator = GetComponent<Animator>();
        }

        public void OnStart()
        {

        }

        public void SetAnimatorMovementSpeed(float speed)
        {
            CaveGuyAnimator.SetFloat("Speed", speed);
        }

        public void SetAnimatorJumpTrigger()
        {
            CaveGuyAnimator.ResetTrigger("Jump");
            CaveGuyAnimator.SetTrigger("Jump");
        }

        public void SetLanding(bool state)
        {
            CaveGuyAnimator.SetBool("Landing", state);
        }

        public void SetLayerWeight(int layer, float weight)
        {
            CaveGuyAnimator.SetLayerWeight(layer, weight);
        }
    }
}