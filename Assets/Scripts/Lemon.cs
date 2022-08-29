using System.Collections;
using UnityEngine;

namespace Dan
{
    public class Lemon : Interactable
    {
        private ParticleSystem _lemonBurst;
        
        protected override void Start()
        {
            _lemonBurst = transform.GetComponentInChildren<ParticleSystem>();
        }
        
        public override void Trigger()
        {
            base.Trigger();
            _lemonBurst.Play();
        }
    }
}