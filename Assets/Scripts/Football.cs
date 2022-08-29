using System.Collections;
using UnityEngine;

namespace Dan
{
    public class Football : Interactable
    {
        [SerializeField] private float _jumpForce = 500f;
        
        private Rigidbody2D _rigidbody2D;

        protected override void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public override void Trigger()
        {
            base.Trigger();
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}