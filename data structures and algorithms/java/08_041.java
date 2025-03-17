public int minProcessingSpeed(int[] batches, int h) {
    int left = 1;
    int right = 0;
    
    // Find the maximum batch size
    for (int batch : batches) {
        right = Math.max(right, batch);
    }
    
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (canComplete(batches, mid, h)) {
            right = mid;
        } else {
            left = mid + 1;
        }
    }
    
    return left;
}

private boolean canComplete(int[] batches, int speed, int h) {
    int hours = 0;
    for (int batch : batches) {
        // Ceiling division
        hours += (batch + speed - 1) / speed;
    }
    return hours <= h;
}