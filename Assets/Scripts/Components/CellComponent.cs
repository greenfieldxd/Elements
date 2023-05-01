using System;
using DefaultNamespace;
using UnityEngine;

namespace Components
{
    public class CellComponent : MonoBehaviour
    {
        [SerializeField] private ElementType type;
        [SerializeField] private int spriteLayerIndex;

        public ElementType Type => type;
        public ElementComponent Element { get; private set; }

        public void SetElement(ElementComponent elementComponent)
        {
            Element = elementComponent;
            Element.SpriteRenderer.sortingOrder = spriteLayerIndex;
            var trElement = Element.transform;
            trElement.SetParent(transform);
            trElement.localPosition = Vector3.zero;
        }

        public void SetSpriteLayer(int value)
        {
            spriteLayerIndex = value;
        }

        private Color GetGizmosColor()
        {
            switch (type)
            {
                case ElementType.None:
                    return Color.gray;
                
                case ElementType.Fire:
                    return Color.red;
                
                case ElementType.Water:
                    return Color.blue;
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
