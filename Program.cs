namespace  Microsoft;

static class Solution
{
    private static void Test1()
    {
        var row1 = new char[] { '2', '1', '0' };
        var row2 = new char[] { '1', '1', '0' };
        var row3 = new char[] { '0', '1', '1' };
        var grid = new char[3][] { row1, row2, row3 };

        int timeTaken = SlapCalculator.DaysToSpread(grid);
        if (timeTaken != 4) throw new Exception("Wrong");
            else Console.WriteLine("Test1 PASSED!");
    }

    private static void Test2()
    {
        var row1 = new char[] { '2', '1', '0' };
        var row2 = new char[] { '1', '1', '0' };
        var row3 = new char[] { '1', '0', '1' };
        var grid = new char[3][] { row1, row2, row3 };

        int timeTaken = SlapCalculator.DaysToSpread(grid);
        if (timeTaken != -1) throw new Exception("Wrong");
            else Console.WriteLine("Test2 PASSED!");
    }

    private static void Test3()
    {
        var row1 = new char[] { '2', '1', '0', '1' };
        var row2 = new char[] { '1', '1', '0', '2' };
        var row3 = new char[] { '1', '0', '1', '1' };
        var grid = new char[3][] { row1, row2, row3 };

        int timeTaken = SlapCalculator.DaysToSpread(grid);
        if (timeTaken != 2) throw new Exception("Wrong");
            else Console.WriteLine("Test3 PASSED!");
    }

    private static void HugeTest()
    {
        var row1 = new char[] { '2', '1', '0', '1', '2', '1', '0', '1' };
        var row2 = new char[] { '1', '1', '0', '2', '1', '1', '0', '2' };
        var row3 = new char[] { '1', '0', '1', '1', '1', '0', '1', '1' };
        var row4 = new char[] { '2', '1', '0', '1', '2', '1', '0', '1' };
        var row5 = new char[] { '1', '1', '0', '2', '1', '1', '0', '2' };
        var row6 = new char[] { '1', '0', '1', '1', '1', '0', '1', '1' };
        var grid = new char[6][] { row1, row2, row3, row4, row5, row6 };

        int timeTaken = SlapCalculator.DaysToSpread(grid);
        if (timeTaken != 2) throw new Exception("Wrong");
            else Console.WriteLine("HugeTest PASSED!");
    }

    static void Main(String[] args)
    {
        Test1();
        Test2();
        Test3();
        HugeTest();
    }
}
