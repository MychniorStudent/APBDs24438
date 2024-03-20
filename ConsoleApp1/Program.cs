// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, Commit1!");
Console.WriteLine("Hello, Commit2!");
Console.WriteLine("Hello, Commit3!");

static float average(int[] tab)
{
    int sum = 0;
    Array.ForEach(tab, x => sum += x);
    return sum / tab.Length;
}


static int max(int[] tab)
{
    int currentMax = 0;
    Array.ForEach(tab, iks =>
    {
        if (iks > currentMax)
        {
            currentMax = iks;
        }
    });
    return currentMax;
}