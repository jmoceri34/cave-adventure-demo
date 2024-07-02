namespace CaveAdventure.CaveGuy
{
    using APPack;
    using System.Collections;
    using UnityEngine;
    
    public class CaveGuyCameraService : MonoBehaviour
    {        
        private Vector2 Velocity;
        private Vector2 OriginalOffset;
        private float? LastCaveGuyXPositionLeft;
        private float? LastCaveGuyXPositionRight;

        public Vector2 Offset;
        public float SmoothTimeX;
        public float SmoothTimeY;
        private bool FollowTargetX;
        private bool FollowTargetY;
        private float XDistance;

        private float NewY;
        private Transform CameraTransform;
        private Camera Cam;
        private Coroutine UnfollowYCouroutine;

        public void OnAwake()
        {
            CameraTransform = GetComponent<Transform>();
            var entityPosition = GetComponentInParent<CaveGuyController>().transform.position;
            CameraTransform.position = new Vector3(entityPosition.x, entityPosition.y, CameraTransform.position.z);
            Cam = GetComponent<Camera>();
            transform.parent = null;
            OriginalOffset = Offset;
        }

        public void OnStart()
        {

        }
        
        #region Camera Follow Methods        
        public void ActivateDeadzoneX(CaveGuyModel model)
        {
            FollowTargetX = false;
            if ((int)Mathf.Sign(model.CaveGuyTransform.localScale.x) == 1)
                LastCaveGuyXPositionLeft = model.CaveGuyTransform.position.x;
            else
                LastCaveGuyXPositionRight = model.CaveGuyTransform.position.x;
        }
        
        public void FollowTarget(CaveGuyModel model)
        {
            // set the orthographic size to the desired size
            Cam.orthographicSize = (Screen.height / 100f) / 4f;

            var x = CameraTransform.position.x;
            var y = CameraTransform.position.y;

            var offsetX = (Offset.x * Mathf.Sign(model.CaveGuyTransform.localScale.x)); // scale determines direction, and creates an implicit deadzone based on it's sign

            // get the viewport position of the player
            var caveGuyViewportPosition = Camera.main.WorldToViewportPoint(model.CaveGuyTransform.position);

            // get the updated x position accounting for the x offset
            var newX = Mathf.MoveTowards(CameraTransform.position.x, model.CaveGuyTransform.position.x + offsetX, SmoothTimeX);
            
            // if we're not inside a dead zone, check to see if we need to be
            if (!FollowTargetX)
            {
                // keep the player within the middle 50% of the screen
                if(caveGuyViewportPosition.x <= 0.25f || model.CaveGuyTransform.position.x < LastCaveGuyXPositionLeft) // Don't do equals otherwise it'll snap every direction change
                {
                    FollowTargetX = true;
                }
                else if(caveGuyViewportPosition.x >= 0.75f || model.CaveGuyTransform.position.x > LastCaveGuyXPositionRight) // Same as above
                {
                    FollowTargetX = true;
                }
            }
            
            // if we're at the dead zone boundary, update x
            if (FollowTargetX) // apply the new x transformation
            {
                x = newX;
            }

            if (FollowTargetY) // apply the new y transformation
            {
                y = Mathf.MoveTowards(CameraTransform.position.y, NewY, SmoothTimeY);
            }

            CameraTransform.position = new Vector3(x, y, CameraTransform.position.z); // finally, update the cameras position regardless
        }
        #endregion

        #region Camera Transformation Methods 
        public void SetCameraOffset(float? x, float? y)
        {
            Offset = new Vector2(x ?? Offset.x, y ?? Offset.y);
        }

        public void SetYPosition(CaveGuyModel model, Vector2? relativeTo)
        {
            NewY = Offset.y;

            if (relativeTo != null)
            {
                NewY += relativeTo.Value.y;
            }

            if(UnfollowYCouroutine != null)
                StopCoroutine(UnfollowYCouroutine);

            UnfollowYCouroutine = StartCoroutine(UnfollowYAfterReset());
        }

        private IEnumerator UnfollowYAfterReset()
        {
            yield return new WaitForFixedUpdate();
            
            while(CameraTransform.position.y != NewY)
            {
                FollowTargetY = true;
                yield return null;
            }
            FollowTargetY = false;
        }
        #endregion


    }
}