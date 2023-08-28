using System.Collections.Generic;

public class DistanceToAimComparer : IComparer<IDistanceToAimsComparable>
{
    public int Compare(IDistanceToAimsComparable x, IDistanceToAimsComparable y)
    {
        if (x.DistancePlayerToAim > y.DistancePlayerToAim)
            return 1;
        if (x.DistancePlayerToAim < y.DistancePlayerToAim)
            return -1;
        else
            return 0;
    }
}
