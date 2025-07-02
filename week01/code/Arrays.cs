
using System;
using System.Collections.Generic;
using System.Diagnostics;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>



    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // 1. Create array with length
        double[] multiples = new double[length];
        // 2. iterate from 0 to length -1
        for (int i = 0; i < length; i++)
        {
            // 3. calculate the current multiple and store it in the array
            multiples[i] = number * (i + 1);
        }
        Debug.WriteLine("MultiplesOf result: " + string.Join(",", multiples));
        // 4. return the array of multiples
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Calculate the effective rotation amount to handle cases where amount == data.Count
    int rotation = amount % data.Count;

    // Step 2: Use GetRange to split the list into two parts
    List<int> endSegment = data.GetRange(data.Count - rotation, rotation);
    List<int> startSegment = data.GetRange(0, data.Count - rotation);

    // Step 3: Clear the original list to prepare for rearranging
    data.Clear();

    // Step 4: Add the rotated endSegment first
    data.AddRange(endSegment);

    // Step 5: Then add the startSegment
    data.AddRange(startSegment);

    // Debug output to show the rotated list
    Debug.WriteLine("RotateListRight result: " + string.Join(", ", data));
    }
}
