public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to store the multiples
        double[] multiples = new double[length];

        // Step 2: Loop from 0 to length - 1
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple by multiplying the number by (i + 1)
            multiples[i] = number * (i + 1);

            // Step 4: Store the multiple in the array at index i
        }

        // Step 5: Return the filled array
        return multiples;
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
        // Step 0: Handle edge cases: empty list, null list, or amount <= 0
        if (data == null || data.Count == 0 || amount <= 0)
        {
            return; // nothing to rotate
        }

        // Step 1: Reduce amount if it is larger than the list size
        amount = amount % data.Count;

        // Step 2: Get the last 'amount' elements from the list
        List<int> lastPart = data.GetRange(data.Count - amount, amount);

        // Step 3: Get the first part (all elements before the last 'amount')
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        // Step 4: Clear the original list to prepare for rotated insertion
        data.Clear();

        // Step 5: Add the last part first (moves to the front)
        data.AddRange(lastPart);

        // Step 6: Add the first part after the last part
        data.AddRange(firstPart);

        // Step 7: The list is now rotated to the right by 'amount'
    }
}
