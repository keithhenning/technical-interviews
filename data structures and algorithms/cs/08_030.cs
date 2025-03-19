public class ArtworkGalleryHeist {
    public static int MaxArtworkValue(int[] values) {
        int n = values.Length;
        if (n == 0) return 0;
        if (n == 1) return values[0];

        int prev2 = values[0];
        int prev1 = Math.Max(values[0], values[1]);

        for (int i = 2; i < n; i++) {
            int current = Math.Max(prev1, prev2 + values[i]);
            prev2 = prev1;
            prev1 = current;
        }

        return prev1;
    }
}