using System.Collections;
using UnityEngine;

namespace Dan
{
    public class Interactable : MonoBehaviour
    {
        protected virtual void Start() { }

        private void OnMouseDown()
        {
            Trigger();
        }

        public virtual void Trigger()
        {
            StartCoroutine(PressEffect());
        }
        
        private IEnumerator PressEffect()
        {
            const float maxTime = 0.125f;
            var time = 0f;
            var startScale = Vector3.one;
            var endScale = Vector3.one * 0.75f;
            while (time < maxTime)
            {
                time += Time.deltaTime;
                transform.localScale = Vector3.Lerp(startScale, endScale, time / maxTime);
                yield return new WaitForEndOfFrame();
            }
            time = 0f;
            while (time < maxTime)
            {
                time += Time.deltaTime;
                transform.localScale = Vector3.Lerp(endScale, startScale, time / maxTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}