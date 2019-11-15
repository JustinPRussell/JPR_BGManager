using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BGManager.Core.Model;
using BGManager.Core.Services;
using BGManager.Core.Utility;
using BGManager.ViewHolders;

namespace BGManager.Adapters
{
    public class BoardGameAdapter : RecyclerView.Adapter
    {
        private IBggApi _bggApi = new BggApi();
        private List<BoardGame> _boardGames;

        public BoardGameAdapter()
        {
            _boardGames = _bggApi.GetHotItems().ToList();
        }

        public override int ItemCount => _boardGames.Count();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is BoardGameViewHolder boardGameViewHolder)
            {
                boardGameViewHolder.BgTextView.Text = _boardGames[position].Name;

                var imageBitmap = ImageHelper.GetImageBitmapFromUrl(_boardGames[position].ImageLink);
                boardGameViewHolder.BgImageView.SetImageBitmap(imageBitmap);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.boardgame_viewholder, parent, false);

            BoardGameViewHolder bgViewHolder = new BoardGameViewHolder(itemView);
            return bgViewHolder;
        }
    }
}