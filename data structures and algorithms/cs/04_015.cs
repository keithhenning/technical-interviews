public interface INewSystem
{
   void ProcessData();
}

public class OldSystem
{
   public void ProcessLegacyData() { /* old logic */ }
}

public class SystemAdapter : INewSystem
{
   private OldSystem oldSystem;

   public SystemAdapter(OldSystem oldSystem)
   {
      this.oldSystem = oldSystem;
   }

   public void ProcessData()
   {
      oldSystem.ProcessLegacyData();
   }
}
