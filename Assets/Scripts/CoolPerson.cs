using UnityEngine;

namespace Dan
{
    public class CoolPerson : Person
    {
        [SerializeField] private int _coolness;

        public void SaySomethingCool()
        {
            _coolness++;
            Debug.Log("I'm cool!");
        }
    }
}