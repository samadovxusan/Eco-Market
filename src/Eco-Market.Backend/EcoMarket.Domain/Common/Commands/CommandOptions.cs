namespace EcoMarket.Domaiin.Common.Commands;

public struct CommandOptions()
{
    /// <summary>
    /// Gets or sets a value indicating whether changes made by the command should be automatically saved to the underlying data store.
    /// </summary>
    public bool SkipSaveChanges { get; set; } = false;
}