def handle_collision(self, key, value, bucket):
    for item in bucket:
        if item[0] == key:
            item[1] = value
            return
    bucket.append([key, value])