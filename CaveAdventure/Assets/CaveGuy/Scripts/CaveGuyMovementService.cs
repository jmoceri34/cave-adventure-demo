namespace CaveAdventure.CaveGuy
{
    using APPack;
    using System.Collections;
    using System.Linq;
    using UnityEngine;

    // TODO: Look into easing into the jump in the beginning

    public class CaveGuyMovementService : MonoBehaviour
    {
        public void OnAwake()
        {

        }

        public void OnStart()
        {

        }

        #region Jumping
        private IEnumerator DoJumpTimer(CaveGuyModel model)
        {
            model.Jumping = true;
            yield return new WaitForSeconds(0.3f); // 0.3 second max jump duration
            model.Jumping = false;
        }

        private IEnumerator ReduceJumpForce(CaveGuyModel model)
        {
            model.CurrentJumpForce = model.MaxJumpForce;

            while (model.CurrentJumpForce > 0f) // reduce the jump force over time
            {
                var reduction = model.CurrentJumpForce / 10f; // exponential decay with 2f
                model.CurrentJumpForce = Mathf.Clamp(model.CurrentJumpForce - reduction - 0.05f, 0f, int.MaxValue); // Subtract 0.05f to always reach zero eventually
                yield return new WaitForFixedUpdate();
            }
        }

        public void AddForceToJump(CaveGuyModel model)
        {
            var velocity = model.CaveGuyRigidbody.velocity;
            model.CaveGuyRigidbody.velocity = new Vector2(velocity.x, model.CurrentJumpForce); // Set velocity directly for more control
        }

        public void Jump(CaveGuyModel model)
        {
            model.Jumping = true;
            model.Grounded = false;
            model.CaveGuyRigidbody.velocity = Vector2.zero;
            StartCoroutine("ReduceJumpForce", model);
            StartCoroutine("DoJumpTimer", model);
        }

        public void StopJumping(CaveGuyModel model)
        {
            StopCoroutine("ReduceJumpForce");
            StopCoroutine("DoJumpTimer");
            model.CurrentJumpForce = 0f;
            AddForceToJump(model); // Set the velocity back to zero
            model.Jumping = false;
        }
        #endregion

        public void Move(CaveGuyModel model, float xAxis)
        {
            var velocity = model.CaveGuyRigidbody.velocity;
            model.CaveGuyRigidbody.velocity = new Vector2(model.Speed * xAxis, velocity.y);
        }

        public bool OnGround(CaveGuyModel model)
        {
            foreach (var ground in model.GroundPoints)
            {
                var colliders = Physics2D.OverlapCircleAll(ground.position, 0.05f, model.GroundLayers);
                if (colliders.FirstOrDefault(c => c.gameObject != gameObject) != null)
                    return true;
            }
            return false;
        }
    }
}