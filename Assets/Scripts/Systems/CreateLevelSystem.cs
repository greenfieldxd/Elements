using System.Linq;
using Components;
using Core;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;

namespace Systems
{
   public class CreateLevelSystem : GameSystem
   {
      [SerializeField] private Vector2 levelSpawnPos;
      
      public override void OnInit()
      {
         CreateLevel();
      }

      private void CreateLevel()
      {
         var levelIndex = 0;
         var level = Instantiate(Config.Levels[levelIndex], levelSpawnPos, Quaternion.identity);
         var cells = level.GetComponentsInChildren<CellComponent>();

         foreach (var cell in cells)
         { 
            var element = CreateElement(cell.Type); 
            if (element != null) cell.SetElement(element);
         }
      }

      private ElementComponent CreateElement(ElementType type)
      {
         var prefab = Config.ElementPrefabs.FirstOrDefault(x => x.Type == type);
         if (prefab == null) return null;
         
         var element = Instantiate(prefab, Vector2.zero, quaternion.identity);
         return element;
      }
   }
}
