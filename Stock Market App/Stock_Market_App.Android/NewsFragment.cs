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
using Android.Webkit;

namespace Stock_Market_App.Droid
{
    public class NewsFragment : Fragment
    {
        public static NewsFragment NewInstance(int companyIndex)
        {
            var newsFrag = new NewsFragment { Arguments = new Bundle() };
            newsFrag.Arguments.PutInt("companyIndex", companyIndex);
            return newsFrag;
        }

        public int ShowCompanyIndex
        {
            get { return Arguments.GetInt("companyIndex", 0); }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            int company = ShowCompanyIndex;
            View view = inflater.Inflate(Resource.Layout.NewsFragment, container, false);

            WebView newsWebView = (WebView)view.FindViewById<WebView>(Resource.Id.newsWebView);
            newsWebView.SetWebViewClient(new WebViewClient());
            newsWebView.LoadUrl("https://www.marketwatch.com/investing/stock/" + CompanyList.Companies[company] + "/news");
            newsWebView.Settings.JavaScriptEnabled = true;
            newsWebView.Settings.BuiltInZoomControls = true;
            newsWebView.Settings.SetSupportZoom(true);
            newsWebView.ScrollBarStyle = Android.Views.ScrollbarStyles.InsideOverlay;
            newsWebView.ScrollbarFadingEnabled = false;

            return view;
        }
    }
}