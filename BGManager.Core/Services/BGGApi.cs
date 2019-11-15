using BGManager.Core.Model;
using BGManager.Core.Services.BggApiEntities;
using BGManager.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace BGManager.Core.Services
{
    public interface IBggApi
    {
        BoardGame GetItemData(string itemId);
        IEnumerable<BoardGame> GetHotItems();
    }

    public class BggApi : IBggApi
    {
        const string bggApiUrl = "https://www.boardgamegeek.com/xmlapi2/";
        const string bggItemUrl = bggApiUrl + "thing?id=";
        const string bggHotItemApiUrl = bggApiUrl + "hot?type=boardgame";

        IWebClient _client;
        IXmlUtility _xml;

        public BggApi() : this(new WebClientWrapper(), new XmlUtility()) { }

        public BggApi(IWebClient client, IXmlUtility xml)
        {
            _client = client;
            _xml = xml;
        }

        public IEnumerable<BoardGame> GetHotItems()
        {
            var rawXml = _client.DownloadString(bggHotItemApiUrl);
            var bggItems = _xml.DeserializeString<BggHotItems>(rawXml);

            List<BoardGame> results = new List<BoardGame>();

            foreach(var item in bggItems.Item)
            {
                results.Add(new BoardGame
                {
                    Name = item.Name.Value,
                    ID = item.Id,
                    ImageLink = item.Thumbnail.Value
                });
            }

            return results;
        }

        public BoardGame GetItemData(string itemId)
        {
            var rawXml = _client.DownloadString($"{bggItemUrl}{itemId}");

            var bggItem = _xml.DeserializeString<BggItems>(rawXml);

            return new BoardGame();
        }
    }
}
