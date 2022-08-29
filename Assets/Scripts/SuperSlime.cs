using UnityEngine;

namespace Dan
{
    public class SuperSlime : Slime
    {
        [SerializeField] private GameObject _slimePrefab;
        
        private void OnDestroy()
        {
            var position = transform.position;
            Instantiate(_slimePrefab, position + Vector3.right, Quaternion.identity);
            Instantiate(_slimePrefab, position + Vector3.left, Quaternion.identity);
        }
    }
}
