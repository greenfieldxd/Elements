using System.Collections;
using Components;
using Core;
using Signals;
using UnityEngine;

namespace Systems
{
    public class LevelNormalizationSystem : GameSystem
    {
        public override void OnInit()
        {
            Supyrb.Signals.Get<NormalizeSignal>().AddListener(NormalizeLevel);
        }

        private void NormalizeLevel()
        {
            StartCoroutine(NormalizeRoutine());
        }

        private IEnumerator NormalizeRoutine()
        {
            yield return new WaitForSeconds(0.1f);
            
            foreach (var cell in Data.levelCells)
            {
                if (cell.Element == null) continue;
                
                var needCheckNext = true;
                CellComponent cellToMove = null;
                var posToCheck = cell.transform.position;

                while (needCheckNext)
                {
                    Debug.Log("Check " + cell.name);
                    
                    var hit = Physics2D.Raycast(posToCheck + Vector3.down, Vector2.zero);

                    if (hit.transform != null)
                    {
                        var downCell = hit.transform.GetComponent<CellComponent>();
                        if (downCell != null)
                        {
                            if (downCell.Element == null)
                            {
                                cellToMove = downCell;
                                posToCheck = downCell.transform.position;
                            }
                            else
                            {
                                needCheckNext = false;
                                if (cellToMove != null)
                                {
                                    var element = cell.Element;
                                    cell.Clear();
                                    cellToMove.SetElement(element);
                                    yield return new WaitForSeconds(0.1f);
                                }
                            }
                        }
                    }
                    else
                    {
                        needCheckNext = false;
                        if (cellToMove != null)
                        {
                            var element = cell.Element;
                            cell.Clear();
                            cellToMove.SetElement(element);
                            yield return new WaitForSeconds(0.1f);
                        }
                    }
                }
            }
            
            Data.haveInput = true;
        }
    }
}