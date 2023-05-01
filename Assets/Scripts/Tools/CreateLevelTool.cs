using Components;
using NaughtyAttributes;
using UnityEngine;

namespace Tools
{
    [RequireComponent(typeof(LevelComponent))]
    public class CreateLevelTool : MonoBehaviour
    {
        [SerializeField] private CellComponent cell;
        [SerializeField] private int height;
        [SerializeField] private int width;
        [SerializeField] private float offsetPosModifier;
        
    
        [Button]
        private void CreateField()
        {
            var count = 0;
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var position = new Vector2(x, y) * offsetPosModifier;
                    var newCell = Instantiate(cell, position, Quaternion.identity, transform);
                    newCell.SetSpriteLayer(count);
                    count++;
                }
            }
        }

        [Button]
        private void Clear()
        {
            var cells = GetComponentsInChildren<CellComponent>();
            foreach (var cellComponent in cells) DestroyImmediate(cellComponent.gameObject);
        }
    }
}
