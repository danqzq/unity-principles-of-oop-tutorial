using UnityEngine;

namespace Dan
{
    public class Bullet : MonoBehaviour
    {
        private int _damage;
        
        public void Init(int damage, Vector2 direction)
        {
            _damage = damage;
            GetComponent<Rigidbody2D>().velocity = direction * 10;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            Destroy(gameObject, 10f);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
    }
}