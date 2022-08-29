using System.Collections;
using UnityEngine;

namespace Dan
{
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private float _spriteChangeTime = 0.5f;
        
        private SpriteRenderer _spriteRenderer;
        
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine(SpriteCycle());
        }
        
        private IEnumerator SpriteCycle()
        {
            foreach (var sprite in _sprites)
            {
                _spriteRenderer.sprite = sprite;
                yield return new WaitForSeconds(_spriteChangeTime);
            }
            StartCoroutine(SpriteCycle());
        }
    }
}