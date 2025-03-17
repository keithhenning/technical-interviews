FUNCTION check_rate_limit(user_id, tier)
 key = "rate_limit:{user_id}:{current_minute}"
 current_count = INCR key
 
 IF first increment THEN
   EXPIRE key 60  # Set 60-second expiry
END
 
limit = tier == "premium" ? 1000 : 100
RETURN current_count <= limit
 END