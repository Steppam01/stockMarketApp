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
    public class StockFragment : Fragment
    {
        public static StockFragment NewInstance(int companyIndex)
        {
            var stockFrag = new StockFragment { Arguments = new Bundle() };
            stockFrag.Arguments.PutInt("companyIndex", companyIndex);
            return stockFrag;
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
            View view = inflater.Inflate(Resource.Layout.StockFragment, container, false);

            WebView stockWebView = (WebView)view.FindViewById<WebView>(Resource.Id.stockWebView);
            stockWebView.SetWebViewClient(new WebViewClient());
            stockWebView.LoadUrl("http://stockcharts.com/h-sc/ui?s=" + CompanyList.Companies[company]);
            stockWebView.Settings.JavaScriptEnabled = true;
            stockWebView.Settings.BuiltInZoomControls = true;
            stockWebView.Settings.SetSupportZoom(true);
            stockWebView.ScrollBarStyle = Android.Views.ScrollbarStyles.InsideOverlay;
            stockWebView.ScrollbarFadingEnabled = false;

            return view;
        }
    }
}