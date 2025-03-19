public List<Integer> getComponent(int x) {
   int root = find(x);
   List<Integer> component = new ArrayList<>();
   
   for (int i = 0; i < parent.length; i++) {
       if (find(i) == root) {
           component.add(i);
       }
   }
   
   return component;
}