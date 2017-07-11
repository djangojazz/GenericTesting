namespace CSharpDataAccess.Enterprise.Models
{
  public sealed class TestDefinitionComponent
  {
    public int? TestDefinitionId { get; set; }
    public int? TestDefinitionComponentsId { get; set; }
    public int TestDefinitionComponentsSubTypeId { get; set; }
    public int Sequence { get; set; }
    public int VersionIteration { get; set; }
  }
}
