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

namespace BGManager.ViewHolders
{
    public class BoardGameViewHolder : RecyclerView.ViewHolder
    {
        public ImageView BgImageView { get; set; }
        public TextView BgTextView { get; set; }

        public BoardGameViewHolder(View itemView) : base(itemView)
        {
            BgImageView = itemView.FindViewById<ImageView>(Resource.Id.boardgameImageView);
            BgTextView = itemView.FindViewById<TextView>(Resource.Id.boardgameTextView);
        }
    }
}