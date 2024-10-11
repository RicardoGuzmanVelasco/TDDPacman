using System.Diagnostics;

namespace Pacman.Domain.Tests;

public readonly struct Size
{
    public int Cols { get; }
    public int Rows { get; }
    
    public Size(int rows, int cols)
    {
        Debug.Assert(rows > 0);
        Debug.Assert(cols > 0);
        
        Rows = rows;
        Cols = cols;
    }
    
    public int DistanceFromCenterToVerticalBound() => Rows / 2 + 1;
    public int DistanceFromCenterToHorizontalBound() => Cols / 2 + 1;
}