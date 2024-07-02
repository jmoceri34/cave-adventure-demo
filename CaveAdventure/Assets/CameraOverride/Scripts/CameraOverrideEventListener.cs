namespace CaveAdventure.CameraOverride
{
    using CaveGuy;
    using UnityEngine;

    public class CameraOverrideEventListener : MonoBehaviour
    {
        // adjust the cameras Y position relative to another object
        public bool SetCameraOffsetYRelativeToObject = true;

        // set a manual x offset
        public bool SetCameraOffsetX;

        // set a manual y offset
        public bool SetCameraOffsetY;
        
        // the offset value to use
        public Vector2 NewOffset;

        // the relative objects y position to use
        public GameObject RelativeObject;

        // Not sure which is better, stay or enter, we'll see
        void OnTriggerStay2D(Collider2D collider)
        {
            var bll = collider.GetComponentInParent<CaveGuyBll>();
            if (bll != null)
            {
                if (SetCameraOffsetYRelativeToObject)
                    bll.SetYPosition(RelativeObject.transform.position);

                if (SetCameraOffsetX)
                    bll.SetCameraOffset(NewOffset.x, null);

                if (SetCameraOffsetY)
                    bll.SetCameraOffset(null, NewOffset.y);
            }
        }
    }
}
