using System.Collections.Generic;
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
         Data.haveInput = true;
      }

      private void CreateLevel()
      {
         var levelIndex = 0;
         var level = Instantiate(Config.Levels[levelIndex], levelSpawnPos, Quaternion.identity);
         Data.levelCells = level.GetComponentsInChildren<CellComponent>();
         Data.elements ??= new List<ElementComponent>();

         foreach (var cell in Data.levelCells)
         { 
            var element = CreateElement(cell.Type);
            if (element != null)
            {
               Data.elements.Add(element);
               cell.SetElement(element);
            }
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
