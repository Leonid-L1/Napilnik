using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformModel 
{ 
    private List<CellView> _cells;
    private List<BlockView> _blocksOnPlatform = new List<BlockView>();

    public event Action<List<BlockView>,int, int> IsFull;

    private int _meleeCubesCount;
    private int _rangeCubesCount;

    public PlatformModel(List<CellView> cells, Timer timer)
    {
        _cells = cells;

        foreach (var cell in cells)
            cell.GetComponent<CellSetup>().Init(timer);
    }

    public bool GetIsAbleToTake(BlockView block)
    {
        if(block == null)
            return false;
        
        if(UsingCellsCount() == block.CubesCount)
            return true;
        else
            return false;
    }

    public void PutBlock(BlockView block)
    {
        _blocksOnPlatform.Add(block);

        foreach (CellView cell in _cells)
            if (cell.CubeAbove != null)
                cell.PutCube();

        CountCubeTypes(block);
        CountEmptyCells();
    }
    
    private int UsingCellsCount()
    {
        int usingCellsCount = 0;

        foreach (CellView cell in _cells)
            if (cell.IsEmpty && cell.CubeAbove != null )
                usingCellsCount++;

        return usingCellsCount;
    }

    private void CountEmptyCells()
    {
        int emptyCells = _cells.Count;

        foreach (var cell in _cells)
            if (!cell.IsEmpty)
                emptyCells--;

        if (emptyCells == 0)
        {
            IsFull?.Invoke(_blocksOnPlatform, _meleeCubesCount,_rangeCubesCount);

            _blocksOnPlatform.Clear();
            _meleeCubesCount = 0;
            _rangeCubesCount = 0;

            foreach (var cell in _cells)
                cell.Reset();
        }
    }

    private void CountCubeTypes(BlockView block)
    {
        foreach (CubeView cube in block.Cubes)
        {
            if(cube.gameObject.GetComponent<MeleeCube>() != null)
            {
                _meleeCubesCount++;
            }
            else if(cube.gameObject.GetComponent<RangerCube>() != null)
            {
                _rangeCubesCount++;
            }
        }
    }
}
    

