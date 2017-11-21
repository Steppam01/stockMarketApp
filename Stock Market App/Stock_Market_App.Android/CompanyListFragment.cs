using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Stock_Market_App.Droid
{
    public class CompanyListFragment : ListFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            var adapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItem1, CompanyList.Companies);
            ListAdapter = adapter;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            DisplayInformation(position);
        }

        private void DisplayInformation(int companyIndex)
        {
            ListView.SetItemChecked(companyIndex, true);

            var stock = FragmentManager.FindFragmentById(Resource.Id.stockChart);
            var news = FragmentManager.FindFragmentById(Resource.Id.news);
            stock = StockFragment.NewInstance(companyIndex);
            news = NewsFragment.NewInstance(companyIndex);
            var ft = FragmentManager.BeginTransaction();
            var ft1 = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.stockChart, stock);
            ft1.Replace(Resource.Id.news, news);
            ft.SetTransition(FragmentTransit.FragmentFade);
            ft1.SetTransition(FragmentTransit.FragmentFade);
            ft.Commit();
            ft1.Commit();
        }
    }
}