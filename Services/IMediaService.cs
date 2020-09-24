namespace MediaCore
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMediaService
    {
        Task<IEnumerable<Media>> GetItemsAsync(string query);
        Task<Media> GetItemAsync(string id);
        Task AddItemAsync(Media item);
        Task UpdateItemAsync(string id, Media item);
        Task DeleteItemAsync(string id);
    }
}