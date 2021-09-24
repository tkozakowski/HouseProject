using System.Collections.Generic;

namespace Application.Core.Sortings
{
    public class SortingHelper
    {
        public static KeyValuePair<string, string>[] GetSortFields()
        {
            return new[] { SortFields.Title, SortFields.CreationDate };
        }
    }

    /// <summary>
    /// Klasa pomocnicza. Służy do budowy tablicy z danymi, po których można sortować.
    /// </summary>
    public class SortFields
    {
        public static KeyValuePair<string, string> Title { get; } = new KeyValuePair<string, string> ( "title", "Name");
        public static KeyValuePair<string, string> CreationDate { get; } = new KeyValuePair<string, string>("creationdate", "CreatedAt");
    }
}
