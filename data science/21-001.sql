SELECT s.query_id, s.query_text, i.listing_id, i.position,
       CASE WHEN p.listing_id IS NOT NULL THEN 4
            WHEN c.listing_id IS NOT NULL THEN 2
            WHEN k.listing_id IS NOT NULL THEN 1
            ELSE 0 END AS grade
FROM search_sessions s
JOIN impressions i USING (query_id)
LEFT JOIN clicks k USING (query_id, listing_id)
LEFT JOIN carts c USING (query_id, listing_id)
LEFT JOIN purchases p USING (query_id, listing_id)
WHERE s.searched_at BETWEEN CURRENT_DATE - 90 AND CURRENT_DATE - 1;
