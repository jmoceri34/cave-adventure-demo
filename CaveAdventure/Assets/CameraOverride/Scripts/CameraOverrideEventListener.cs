namespace CaveAdventure.CameraOverride
{
    using CaveGuy;
    using UnityEngine;

    public class CameraOverrideEventListener : MonoBehaviour
    {
        public bool SetCameraOffsetRelativeToObject;
        public bool SetCameraOffset;
        public bool SetCameraOffsetX;
        public bool SetCameraOffsetY;
        public bool FollowY;
        public bool UnfollowY;

        public Vector2 NewOffset;
        public GameObject RelativeObject;

        void OnTriggerEnter2D(Collider2D collider)
        {
            
        }

        // Not sure which is better, stay or enter, we'll see
        void OnTriggerStay2D(Collider2D collider)
        {
            var bll = collider.GetComponentInParent<CaveGuyBll>();
            if (bll != null)
            {
                if (SetCameraOffsetRelativeToObject)
                    bll.SetYPosition(RelativeObject.transform.position);

                if (SetCameraOffset)
                    bll.SetCameraOffset(NewOffset.x, NewOffset.y);

                if (SetCameraOffsetX)
                    bll.SetCameraOffset(NewOffset.x, null);

                if (SetCameraOffsetY)
                    bll.SetCameraOffset(null, NewOffset.y);

                if (FollowY)
                    bll.SetCameraFollowY(true);

                if (UnfollowY)
                    bll.SetCameraFollowY(false);
            }
        }

        void OnTriggerExit2D(Collider2D collider)
        {

        }
    }
}
