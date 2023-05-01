using Components;
using DefaultNamespace;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu (menuName = "Configs/ElementConfig", fileName = "ElementConfig")]

    public class ElementConfig : ScriptableObject
    {
        [field:SerializeField] public ElementType Type { get; private set; }
        [field:SerializeField] public ElementComponent Prefab { get; private set; }
    }
}