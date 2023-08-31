using System.Collections.Generic;

public class DistanceToAimComparer : IComparer<IDistanceToAimsComparable>
{
    public int Compare(IDistanceToAimsComparable x, IDistanceToAimsComparable y)
    {
        if (x.distancePlayerToAim > y.distancePlayerToAim)
            return 1;
        if (x.distancePlayerToAim < y.distancePlayerToAim)
            return -1;
        else
            return 0;
    }
}
