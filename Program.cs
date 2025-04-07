using System;
using System.Globalization;

class humancannonball2
{
    static void Main(string[] args)
    {
    
        int N = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            float v0, theta, x1, h1, h2;
            string[] input = Console.ReadLine().Split(" ");
            v0 = float.Parse(input[0], CultureInfo.InvariantCulture); 
            theta = float.Parse(input[1], CultureInfo.InvariantCulture); 
            x1 = float.Parse(input[2], CultureInfo.InvariantCulture);
            h1 = float.Parse(input[3], CultureInfo.InvariantCulture);
            h2 = float.Parse(input[4], CultureInfo.InvariantCulture);
            double time = 0f;
            double height = 0f;
            double gravity = 9.81d;
            //Convert theta from degrees to radians (Cos and sin methods expect radians)
            theta = (float)(theta * Math.PI / 180);

            // Solve x(t) = v0*t*cos(theta) for t (time) --> t = x / v0*cos(theta)
            // Gives the time t when the cannon crosses the wall
            // Now solve for y to calculate the height of cannonball when crossed
            time = x1 / (v0 * Math.Cos(theta));
            height = v0 * time * Math.Sin(theta) - 0.5 * gravity * Math.Pow(time, 2);

            //Check if height is correct for that gap in the wall with 1m extra up and down
            float maxHeight = h2 - 1;
            float minHeight = h1 + 1;
            if (height >= minHeight && height <= maxHeight)
                Console.WriteLine("Safe");
            else Console.WriteLine("Not Safe");
        }
    }
}