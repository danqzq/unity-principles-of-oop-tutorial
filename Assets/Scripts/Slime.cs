using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dan
{
    public class Slime : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth = 10;
        [SerializeField] private float _speed = 50f, _jumpForce = 175f;
        [SerializeField] private float _playerDetectionRange = 2f, _detectionYPos = -0.5f;
        [SerializeField] private Image _healthBar;
        
        private int _health;
        private bool _isFacingRight;
        private bool _isAnticipatingJump;
        
        private Rigidbody2D _rigidbody;
 
        private Player _player;
        
        private float GetSpeed => _isFacingRight ? _speed : -_speed;
        
        private void Start()
        {
            _health    = _maxHealth;
            _rigidbody = GetComponent<Rigidbody2D>();
            _player    = FindObjectOfType<Player>();
            StartCoroutine(MovementCoroutine());
        }
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            _healthBar.fillAmount = (float) _health / _maxHealth;
            if (_health <= 0) Destroy(gameObject);
        }

        private IEnumerator MovementCoroutine()
        {
            yield return new WaitUntil(IsPlayerNearby);
            _isAnticipatingJump = true;
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            yield return new WaitForSeconds(0.625f);
            _isAnticipatingJump = false;
            _rigidbody.AddForce(Vector2.up * _jumpForce * 2 + Vector2.right * GetSpeed);
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(MovementCoroutine());
        }

        private void FixedUpdate()
        {
            _isFacingRight = _player.transform.position.x > transform.position.x;
            if (_isAnticipatingJump) return;
            _rigidbody.velocity = new Vector2(GetSpeed, _rigidbody.velocity.y);
        }

        private bool IsPlayerNearby() => 
            Physics2D.Raycast(transform.position + Vector3.up * _detectionYPos, 
                Vector2.right * GetSpeed, _playerDetectionRange, 1 << LayerMask.NameToLayer("Player"));
    }
}
