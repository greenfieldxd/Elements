using System;
using DefaultNamespace;
using UnityEngine;

namespace Components
{
    public class CellComponent : MonoBehaviour
    {
        [SerializeField] private ElementType type;

        public ElementType Type => type;
        public ElementComponent Element { get; private set; }

        public void SetElement(ElementComponent elementComponent)
        {
            Element = elementComponent;
            var trElement = Element.transform;
            trElement.SetParent(transform);
            trElement.localPosition = Vector3.zero;
        }

        private Color GetGizmosColor()
        {
            switch (type)
            {
                case ElementType.None:
                    return Color.gray;
                    break;
                case ElementType.Fire:
                    return Color.red;
                    break;
                case ElementType.Water:
                    return Color.blue;
                    break;
            }
            return Color.gray;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = GetGizmosColor();
            Gizmos.DrawCube(transform.position, Vector2.one);
        }
    }
}
