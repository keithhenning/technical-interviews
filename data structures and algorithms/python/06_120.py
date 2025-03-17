import heapq
from collections import defaultdict, Counter

def build_huffman_tree(text):
   """
   Build a Huffman tree and return character codes.
   
   Args:
       text (str): Input text to encode
       
   Returns:
       dict: Dictionary mapping characters to their 
            binary codes
       
   Time Complexity: O(n log n) where n is the number 
                  of unique characters
   """
   # Count frequency of each character
   frequency = Counter(text)
   
   # Create a priority queue (min heap)
   heap = [[weight, [char, ""]] 
          for char, weight in frequency.items()]
   heapq.heapify(heap)
   
   # Build Huffman Tree
   while len(heap) > 1:
      lo = heapq.heappop(heap)
      hi = heapq.heappop(heap)
      
      for pair in lo[1:]:
         pair[1] = '0' + pair[1]
      for pair in hi[1:]:
         pair[1] = '1' + pair[1]
         
      heapq.heappush(heap, [lo[0] + hi[0]] + lo[1:] + 
                    hi[1:])
   
   # Extract codes
   huffman_codes = {char: code 
                   for char, code in sorted(
                      heapq.heappop(heap)[1:])}
   return huffman_codes

def huffman_encode(text):
   """
   Encode text using Huffman coding.
   
   Args:
       text (str): Input text to encode
       
   Returns:
       tuple: (encoded_text, codes)
             - encoded_text (str): Binary string of the 
                                encoded text
             - codes (dict): Dictionary mapping 
                          characters to their binary codes
             
   Time Complexity: O(n + k log k) where n is text 
                  length and k is unique characters
   """
   codes = build_huffman_tree(text)
   encoded_text = ''.join(codes[char] for char in text)
   return encoded_text, codes

def huffman_decode(encoded_text, codes):
   """
   Decode Huffman-encoded text.
   
   Args:
       encoded_text (str): Binary string of the 
                         encoded text
       codes (dict): Dictionary mapping characters 
                   to their binary codes
       
   Returns:
       str: Decoded original text
       
   Time Complexity: O(n) where n is the length of 
                  encoded_text
   """
   reversed_codes = {code: char 
                    for char, code in codes.items()}
   current_code = ""
   decoded_text = ""
   
   for bit in encoded_text:
      current_code += bit
      if current_code in reversed_codes:
         decoded_text += reversed_codes[current_code]
         current_code = ""
         
   return decoded_text

# Example usage
text = "this is an example for huffman encoding"
encoded, codes = huffman_encode(text)
decoded = huffman_decode(encoded, codes)
print(f"Original: {text}")
print(f"Encoded: {encoded}")
print(f"Decoded: {decoded}")
print(f"Compression ratio: {len(encoded)/(len(text)*8):.2f}")