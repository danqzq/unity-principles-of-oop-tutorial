using UnityEngine;

namespace Dan
{
    public class SuperCoolPerson : CoolPerson
    {
        [SerializeField] private int _superCoolness;

        public void SaySomethingSuperCool()
        {
            _superCoolness++;
            Debug.Log("I'm super cool!");
        }
    }
}