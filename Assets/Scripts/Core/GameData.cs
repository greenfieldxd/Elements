using System;
using System.Collections.Generic;
using Components;

namespace Core
{
    [Serializable]
    public class GameData
    {
        public bool haveInput;
        public CellComponent currentClickedCell;
        public CellComponent[] levelCells;
        public List<ElementComponent> elements;
    }
}