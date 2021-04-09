using UnityEngine;

namespace CaveAdventure
{
    public class ColliderCameraVisibility : MonoBehaviour 
    {    
        void OnBecameVisible()
        {
            var collider = GetComponent<Collider2D>();
            if (collider != null)
                collider.enabled = true;
        }
    
        void OnBecameInvisible()
        {       
            var collider = GetComponent<Collider2D>();        
            if (collider != null)
                collider.enabled = false;
        }
    }
}
