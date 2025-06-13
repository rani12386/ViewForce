namespace ViewForce.Reports.Infrastructure.Events
{
    using Microsoft.Practices.Prism.Events;
    using System.Collections.Generic;

    /// <summary>
    /// Search Event class
    /// </summary>
    public class SearchEvent : CompositePresentationEvent<IDictionary<string, string>>
    {
    }
}
