public static class Arrays
{
   /// <summary>
/// Create and return an array of multiples of a number.
/// Example: MultiplesOf(3, 5) => {3, 6, 9, 12, 15}
/// 
/// Steps / Plan (kept as comments as requested):
/// 1. Validate inputs: if count <= 0, return an empty array.
/// 2. Create a result array of length 'count'.
/// 3. For i from 0 to count-1:
///      - compute multiple = start * (i + 1)
///      - store multiple in result[i]
///    (Because the first multiple should be start * 1, second start * 2, etc.)
/// 4. Return the result array.
/// Edge cases:
/// - If count == 0, return empty array.
/// - If start is any double (including fractional), multiplication still works.
/// </summary>
public static double[] MultiplesOf(double start, int count)
{
    // Step 1: handle edge cases
    if (count <= 0)
        return new double[0];

    // Step 2: create array
    var result = new double[count];

    // Step 3: fill array
    for (int i = 0; i < count; i++)
    {
        result[i] = start * (i + 1);
    }

    // Step 4: return
    return result;
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
