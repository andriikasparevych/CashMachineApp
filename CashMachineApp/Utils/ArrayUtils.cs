using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachineApp.Utils
{
    public static class ArrayUtils
    {
        public static string ToDisplayString(this int[] arr)
        {
            var dic = new Dictionary<int, int>();
            var sb = new StringBuilder();
            foreach (var i in arr)
            {
                if (dic.ContainsKey(i))
                {
                    dic[i]++;
                }
                else
                {
                    dic.Add(i, 1);
                }
            }

            var currentEl = 0;
            foreach (var kvp in dic)
            {

                if (kvp.Value > 1)
                {
                    sb.Append($"{kvp.Value}x{kvp.Key}");
                }
                else
                {
                    sb.Append(kvp.Key);
                }

                if (currentEl < dic.Count - 1)
                {
                    sb.Append(", ");
                }

                currentEl++;
            }

            return sb.ToString();
        }

        public static void SortDesc(this int[] arr)
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
