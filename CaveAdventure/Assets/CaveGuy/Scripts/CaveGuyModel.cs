namespace CaveAdventure.CaveGuy
{
    using APPack;
    using UnityEngine;

    public class CaveGuyModel : MonoBehaviour
    {
        [SerializeField]
        private float MovementSpeed;
        [SerializeField]
        private float SprintMovementSpeed;

        public bool Grounded;
        public bool Sprinting;
        public float Speed { get { return Sprinting ? SprintMovementSpeed : MovementSpeed; } }
        public Transform CaveGuyTransform { get; private set; }
        public Rigidbody2D CaveGuyRigidbody { get; private set; }
        public Transform[] GroundPoints;
        public LayerMask GroundLayers;
        public bool Jumping;
        public float MaxJumpForce;
        public float CurrentJumpForce;

        public void OnAwake()
        {
            CaveGuyTransform = GetComponent<Transform>();
            CaveGuyRigidbody = GetComponent<Rigidbody2D>();
        }

        public void OnStart()
        {

        }
    }
}