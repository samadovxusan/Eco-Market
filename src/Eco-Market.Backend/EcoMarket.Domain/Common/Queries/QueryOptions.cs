namespace EcoMarket.Domaiin.Common.Queries;

public struct QueryOptions()
{
    /// <summary>
    /// Gets or sets change tracking mode for query results. 
    /// Using AsNoTracking change tracking mode can potentially improve the performance.
    /// </summary>
    public QueryTrackingMode TrackingMode { get; set; }

    public QueryOptions(QueryTrackingMode trackingMode) : this() => TrackingMode = trackingMode;
}