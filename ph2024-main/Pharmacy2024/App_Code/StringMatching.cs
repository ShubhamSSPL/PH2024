using FuzzySharp;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;




public class Solution
{
    private List<IList<string>> result = new List<IList<string>>();

    public IList<IList<string>> Permute(string[] nums)
    {
        Generate(nums, new List<string>(), new bool[nums.Length]);
        return result;
    }

    private void Generate(string[] nums, List<string> combination, bool[] visited)
    {
        if (combination.Count == nums.Length)
        {
            result.Add(new List<string>(combination));
            return;
        }

        for (int index = 0; index < nums.Length; ++index)
        {
            // Check to see if this index has been visited
            if (visited[index])
            {
                continue;
            }

            // Set that this index has been visited
            visited[index] = true;

            // Add this number to the combination
            combination.Add(nums[index]);

            // Keep generating permutations
            Generate(nums, combination, visited);

            // Unset that this index has been visited
            visited[index] = false;

            // Remove last item as its already been explored
            combination.RemoveAt(combination.Count - 1);
        }
    }
}
public class StringMatching
{
    public int LevenshteinDistance(string source, string target)
    {
        // degenerate cases
        if (source == target) return 0;
        if (source.Length == 0) return target.Length;
        if (target.Length == 0) return source.Length;

        // create two work vectors of integer distances
        int[] v0 = new int[target.Length + 1];
        int[] v1 = new int[target.Length + 1];

        // initialize v0 (the previous row of distances)
        // this row is A[0][i]: edit distance for an empty s
        // the distance is just the number of characters to delete from t
        for (int i = 0; i < v0.Length; i++)
            v0[i] = i;

        for (int i = 0; i < source.Length; i++)
        {
            // calculate v1 (current row distances) from the previous row v0

            // first element of v1 is A[i+1][0]
            //   edit distance is delete (i+1) chars from s to match empty t
            v1[0] = i + 1;

            // use formula to fill in the rest of the row
            for (int j = 0; j < target.Length; j++)
            {
                var cost = (source[i] == target[j]) ? 0 : 1;
                v1[j + 1] = Math.Min(v1[j] + 1, Math.Min(v0[j + 1] + 1, v0[j] + cost));
            }

            // copy v1 (current row) to v0 (previous row) for next iteration
            for (int j = 0; j < v0.Length; j++)
                v0[j] = v1[j];
        }

        return v1[target.Length];
    }
    public double CheckString_old(string source, string target)
    {
        if ((source == null) || (target == null)) return 0.0;
        if ((source.Length == 0) || (target.Length == 0)) return 0.0;
        if (source == target) return 1.0;

        int stepsToSame = LevenshteinDistance(source, target);
        return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
    }

    public int CheckString(string compare1, string compare2)
    {
        compare1 = compare1.ToLower();
        compare2 = compare2.ToLower();
        Solution s1 = new Solution();
        Solution s2 = new Solution();

        string[] list1 = compare1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        string[] list2 = compare2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        int Maxvalue = 0;

        var permutations1 = s1.Permute(list1);
        var permutations2 = s2.Permute(list2);

        string[][] permutationsAsArray1 = permutations1.Select(x => x.ToArray()).ToArray();
        string[][] permutationsAsArray2 = permutations2.Select(x => x.ToArray()).ToArray();

        Maxvalue = 0;
        int Resval = 0;
        string val1 = "";
        string val2 = "";

        bool FoundAll = false;
        bool Foundpartial = false;
        if (compare1 == compare2)
        {
            FoundAll = true;
        }
        else
        {
            for (int i = 0; i < permutationsAsArray1.Length; i++)
            {
                for (int j = 0; j < permutationsAsArray2.Length; j++)
                {
                    bool notfound = false;
                    for (int k = 0; k < permutationsAsArray1[i].Length; k++)
                    {
                        if (k < permutationsAsArray2[j].Length)
                        {
                            if (permutationsAsArray1[i][k] == permutationsAsArray2[j][k])
                            {
                                Foundpartial = true;
                            }
                            else
                            {
                                notfound = true;
                            }
                        }
                    }
                    if (notfound == false)
                    {
                        if (permutationsAsArray1[i].Length == permutationsAsArray2[j].Length)
                        {
                            FoundAll = true;
                        }
                    }

                }
            }
        }
        Maxvalue = 0;
        if (FoundAll == true)
        {
            Maxvalue = 100;
        }
        else if (Foundpartial == true)
        {
            Maxvalue = 50;
        }
        else
        {
            Maxvalue = 0;
        }



        return Maxvalue;
    }
    public int CheckStringFuzzy(string compare1, string compare2)
    {
        string[] list1 = compare1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        string[] list2 = compare2.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        Solution s1 = new Solution();
        Solution s2 = new Solution();
        int Maxvalue = 0;

        var permutations1 = s1.Permute(list1);
        var permutations2 = s2.Permute(list2);

        string[][] permutationsAsArray1 = permutations1.Select(x => x.ToArray()).ToArray();
        string[][] permutationsAsArray2 = permutations2.Select(x => x.ToArray()).ToArray();

        Maxvalue = 0;
        int Resval = 0;
        string val1 = "";
        string val2 = "";
        for (int i = 0; i < permutationsAsArray1.Length; i++)
        {
            val1 = "";
            for (int j = 0; j < permutationsAsArray1[i].Length; j++)
            {
                if (val1.Length > 0)
                {
                    val1 = val1 + " ";
                }
                val1 = val1 + permutationsAsArray1[i][j];
            }
            for (int j = 0; j < permutationsAsArray2.Length; j++)
            {

                val2 = "";
                for (int k = 0; k < permutationsAsArray2[j].Length; k++)
                {
                    if (val2.Length > 0)
                    {
                        val2 = val2 + " ";
                    }
                    val2 = val2 + permutationsAsArray2[j][k];
                }

                Resval = Fuzz.Ratio(val1, val2);
                if (Resval > Maxvalue)
                {
                    Maxvalue = Resval;
                }
            }
        }


        return Maxvalue;
    }
}
