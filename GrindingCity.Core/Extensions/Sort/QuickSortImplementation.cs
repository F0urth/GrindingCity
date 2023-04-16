using GrindingCity.Domain.Interfaces.Entities;

namespace GrindingCity.Core.Extensions.Sort
{
    public static class QuickSortImplementation
    {
        public static IEnumerable<IResource> CustomQuickSort(IResource[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex].Amount;

            while (i <= j)
            {
                while (array[i].Amount < pivot)
                {
                    i++;
                }

                while (array[j].Amount > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i].Amount;
                    array[i] = array[j];
                    array[j].Amount = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                CustomQuickSort(array, leftIndex, j);
            if (i < rightIndex)
                CustomQuickSort(array, i, rightIndex);
            return array;
        }
    }
}
