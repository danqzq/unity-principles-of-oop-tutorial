using System.Collections;
using UnityEngine;

namespace Dan
{
    public class InteractableManager : MonoBehaviour
    {
        public void TriggerAll()
        {
            foreach (var interactable in FindObjectsOfType<Interactable>())
            {
                interactable.Trigger();
            }
        }
    }
}
