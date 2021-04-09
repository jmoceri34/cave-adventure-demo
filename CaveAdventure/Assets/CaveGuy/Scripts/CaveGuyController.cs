namespace CaveAdventure.CaveGuy
{
    using UnityEngine;

    public class CaveGuyController : MonoBehaviour
    {
        public CaveGuyBll Bll;

        // Only update per entity

        void Update()
        {
            Bll.CheckGround();

            if (Input.GetKeyDown(KeyCode.R))
            {
                Bll.Model.CaveGuyRigidbody.velocity = Vector2.zero;
                Bll.Model.CaveGuyTransform.position = Vector2.zero;
                //Bll.ResetCameraOffset();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Bll.SetSprintMovement(true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Bll.SetSprintMovement(false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Bll.SetJumpInput(true);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Bll.SetJumpInput(false);
            }
        }

        void FixedUpdate()
        {
            var xAxis = Input.GetAxisRaw("Horizontal");
            Bll.UpdateJumpForce();
            Bll.ChangeXDirection(xAxis);
            Bll.Move(xAxis);
            Bll.CameraFollow();
        }

        void LateUpdate()
        {
        }

    }
}