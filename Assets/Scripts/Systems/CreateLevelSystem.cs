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
         var elementConfig = Config.ElementConfigs.FirstOrDefault(x => x.Type == type);
         if (elementConfig == null) return null;
         
         var element = Instantiate(elementConfig.Prefab, Vector2.zero, quaternion.identity);
         element.type = elementConfig.Type;
         return element;
      }
   }
}
