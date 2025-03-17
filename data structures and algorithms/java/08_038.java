import java.util.Arrays;

public int countConvoys(int target, int[] positions, int[] speeds) {
    int n = positions.length;
    double[][] cars = new double[n][2];
    
    // Create pairs of position and speed
    for (int i = 0; i < n; i++) {
        cars[i][0] = positions[i];
        cars[i][1] = speeds[i];
    }
    
    // Sort by position in descending order
    Arrays.sort(cars, (a, b) -> Double.compare(b[0], a[0]));
    
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