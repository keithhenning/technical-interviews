using System;
using System.Linq;

public class ConvoyCounter {
    public static int CountConvoys(int target, int[] positions, int[] speeds) {
        int n = positions.Length;
        var cars = new double[n][];

        for (int i = 0; i < n; i++) {
            cars[i] = new double[] { positions[i], speeds[i] };
        }

        Array.Sort(cars, (a, b) => b[0].CompareTo(a[0]));

        int convoys = 0;
        double prevTime = -1;

        for (int i = 0; i < n; i++) {
            double position = cars[i][0];
            double speed = cars[i][1];
            double time = (target - position) / speed;

            if (time > prevTime) {
                convoys++;
                prevTime = time;
            }
        }

        return convoys;
    }
}