using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dan
{
    public class Player : MonoBehaviour 
    {
        [SerializeField] private float _healthMax, _speed, _jumpSpeed;

        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckRadius;
        
        [SerializeField] private Transform _hand;
        [SerializeField] private Image _healthBarFill;
        
        [SerializeField] private GameObject _bullet;

        private float _health;
        private bool _isInvincible;
        
        private Rigidbody2D _rb;
        private Camera _cam;

        private bool IsGrounded =>
            Physics2D.OverlapCircle(transform.position + Vector3.down * 0.5f, _groundCheckRadius,
                _groundLayer);

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cam = Camera.main;

            _health = _healthMax;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_isInvincible || !collision.collider.CompareTag("Enemy")) return;
            OnTakeDamage(new Damage(1f, collision.transform));
        }
        
        private void Shoot()
        {
            var bullet = Instantiate(_bullet, _hand.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Init(1, _hand.right);
        }

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            
            _healthBarFill.fillAmount = _health / _healthMax;

            if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
                _rb.AddForce(new Vector2(0, _jumpSpeed * 100));
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Shoot();

            var dir = Input.mousePosition - _cam.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            _hand.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                _hand.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                _hand.transform.localScale = new Vector3(-1, 1, 1);
            }

            var rotation = _hand.rotation;
            _hand.transform.localScale = new Vector3(transform.localScale.x, 
                rotation.z > -0.7 && rotation.z < 0.7 ? 1 : -1, 1);
        }

        private void FixedUpdate()
        {
            var horizontal = Input.GetAxis("Horizontal");
            _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y + (IsGrounded ? 0 : -0.75f));
        }

        private IEnumerator Invincibility()
        {
            _isInvincible = true;
            yield return new WaitForSeconds(1);
            _isInvincible = false;
        }

        private void OnTakeDamage(Damage damage)
        {
            _health -= damage.amount;
            _rb.AddForce(new Vector2(500 * (damage.damageDealer.position.x < transform.position.x ? 1 : -1), 100));
            StartCoroutine(Invincibility());
        }
    }
}
