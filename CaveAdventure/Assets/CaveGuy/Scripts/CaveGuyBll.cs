namespace CaveAdventure.CaveGuy
{
    using APPack;
    using UnityEngine;

    public class CaveGuyBll : MonoBehaviour
    {
        public CaveGuyAudioService AudioService;
        public CaveGuyAnimationService AnimationService;
        public CaveGuyCameraService CameraService;
        public CaveGuyEffectsService EffectsService;
        public CaveGuyUIService UIService;
        public CaveGuyModel Model;
        public CaveGuyMovementService MovementService;

        #region Initialization
        public void OnAwake()
        {

        }

        public void OnStart()
        {

        }

        // Only one of these per entity
        void Awake()
        {
            OnAwake();
            AudioService.OnAwake();
            AnimationService.OnAwake();
            CameraService.OnAwake();
            EffectsService.OnAwake();
            UIService.OnAwake();
            Model.OnAwake();
        }

        // Only one of these per entity
        void Start()
        {
            OnStart();
            AudioService.OnStart();
            AnimationService.OnStart();
            CameraService.OnStart();
            EffectsService.OnStart();
            UIService.OnStart();
            Model.OnStart();
        }
        #endregion

        #region Public Methods
        public void CameraFollow()
        {
            CameraService.FollowTarget(Model);
        }

        public void SetSprintMovement(bool state)
        {
            Model.Sprinting = state;
        }

        public void SetJumpInput(bool shouldJump)
        {
            if (Model.Grounded && !Model.Jumping && shouldJump) // Start a jump if the user says so, you're on the ground, and not currently jumping
            {
                // Jump: Entry
                AnimationService.SetAnimatorJumpTrigger();
                MovementService.Jump(Model); // If there are issues with this triggering multiple times, come here
            }
            // Irregardless of ground, stop a jump if user says so
            else if (Model.Jumping && !shouldJump) // To prevent repetitive jumps when held down; stop jumping if you are and the user says so
            {
                // Jump: Exit
                MovementService.StopJumping(Model);
            }

            AnimationService.SetLanding(!Model.Jumping);
        }

        public void UpdateJumpForce()
        {
            if (Model.Jumping) // Add force to the jump if the user says so and currently jumping
            {
                MovementService.AddForceToJump(Model);
            }
        }

        public void Move(float xAxis)
        {
            AnimationService.SetAnimatorMovementSpeed(Mathf.Abs(Model.Speed * xAxis));
            MovementService.Move(Model, xAxis);
        }

        public void ChangeXDirection(float xAxis)
        {
            if (xAxis != 0) // Retain direction when stopped
            {
                var scale = Model.CaveGuyTransform.localScale;
                Model.CaveGuyTransform.localScale = new Vector3(Mathf.Abs(scale.x) * Mathf.Sign(xAxis), scale.y, scale.z); // flip sprite
                if (Mathf.Sign(xAxis) != Mathf.Sign(scale.x)) // Activate camera deadzone when changing x direction
                {
                    CameraService.ActivateDeadzoneX(Model);
                }
            }
        }

        public void CheckGround()
        {
            Model.Grounded = MovementService.OnGround(Model);
            AnimationService.SetLayerWeight(1, Model.Grounded && Model.CaveGuyRigidbody.velocity.y == 0f ? 0f : 1f); // When jumping up through collider platform effector
        }
        #endregion

        #region Private Methods

        #endregion

        #region Event Methods
        public void SetCameraOffset(float? x, float? y)
        {
            CameraService.SetCameraOffset(x, y);
        }
        
        public void SetYPosition(Vector2? relativeTo)
        {
            // TODO: Make all camera offset changes be relative to some object and always unfollow Y after
            CameraService.SetYPosition(Model, relativeTo);
        }
        #endregion

        #region Callback Methods

        #endregion
    }
}