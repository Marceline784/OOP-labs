using System;
public abstract class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}
public class MyPoint : Point
{
    public MyPoint(int x, int y)
    {
        X = x;
        Y = y;
    }
}
public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }
    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }
    public bool Contains(Point p)
    {
        int minX = Math.Min(TopLeft.X, BottomRight.X);
        int maxX = Math.Max(TopLeft.X, BottomRight.X);
        int minY = Math.Min(TopLeft.Y, BottomRight.Y);
        int maxY = Math.Max(TopLeft.Y, BottomRight.Y);

        return p.X >= minX && p.X <= maxX &&
               p.Y >= minY && p.Y <= maxY;
    }
}
class Program
    {
        static void Main()
        {
        Console.WriteLine("Enter rectangle`s point: ");
        string[] rectPoints = Console.ReadLine().Split();
        int x1 = int.Parse(rectPoints[0]);
        int y1 = int.Parse(rectPoints[1]);
        int x2 = int.Parse(rectPoints[2]);
        int y2 = int.Parse(rectPoints[3]);

        Rectangle rect = new Rectangle(new MyPoint(x1, y1), new MyPoint(x2, y2));

        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] pointCoords = Console.ReadLine().Split();
            int x = int.Parse(pointCoords[0]);
            int y = int.Parse(pointCoords[1]);

            MyPoint p = new MyPoint(x, y);
            Console.WriteLine(rect.Contains(p));
        }
    }
}
