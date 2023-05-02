using DefaultNamespace;
using Signals;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Components
{
    public class ElementComponent : MonoBehaviour
    {
        [field:SerializeField] public ElementType Type { get; private set; }
        [field:SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    }
}