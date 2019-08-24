using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashMachineApp.Utils
{
    public static class ArrayUtils
    {

        public static void SortDesc(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            QuickSortDesc(arr, 0, arr.Length - 1);
        }

        private static void QuickSortDesc(int[] arr, int left, int right)
        {
            if (left >= right) return;

            var partIndex = Partition(arr, left, right);

            QuickSortDesc(arr, partIndex + 1, right);
            QuickSortDesc(arr, left, partIndex - 1);
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];

            var partIndex = left - 1;

            for (var i = left; i < right; i++)
            {
                if (arr[i] >= pivot)
                {
                    partIndex++;
                    Swap(arr, partIndex, i);
                }
            }

            partIndex++;
            Swap(arr, right, partIndex);
            return partIndex;
        }

        private static void Swap(int[] arr, int first, int second)
        {
            var tmp = arr[second];
            arr[second] = arr[first];
            arr[first] = tmp;
        }

    }
}
