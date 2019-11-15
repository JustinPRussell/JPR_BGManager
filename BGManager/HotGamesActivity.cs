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
using BGManager.Adapters;

namespace BGManager
{
    [Activity(Label = "HotGamesActivity")]
    public class HotGamesActivity : Activity
    {
        private RecyclerView _recyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private BoardGameAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_HotGames);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.hotGamesRecyclerView);

            _layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(_layoutManager);

            _adapter = new BoardGameAdapter();
            _recyclerView.SetAdapter(_adapter);
        }
    }
}