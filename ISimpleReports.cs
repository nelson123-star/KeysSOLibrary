﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    interface ISimpleReports
    {
        public Task<string> KeyWord(string context, string @base, string domain);
        public Task<string> Concurents(string @base, string domain);
    }
    interface IDashboard   //Дэшборд
    {
        public Task<string> Dashboard(string @base, string domain);
        public Task<string> DashboardKey(string @base, string keyword);
    }
    interface IContext   //Реклама
    {
        public Task<string> KeyWordObyavlenia(string @base, string domain, int ads_id);
        public Task<string> Advertisement(string @base, string domain, bool full);
        public Task<string> ULink(string @base, string domain);
        public Task<string> UFact(string @base, string domain);
    }
    interface IOrganic   //Органическая выдача
    {
        public Task<string> SitePage(string @base, string domain);
        public Task<string> KeyWordPage(string @base, string domain, string page_url);
        public Task<string> PageConcurents(string @base, string domain, string page_url);
    }
    interface ISimilarkeys  //Дополняющие фразы
    {
        public Task<string> Similarkeys(string @base, string keyword);
    }
    interface IOwner    //Сайт владельца
    {
        public Task<string> Owner(string id, string mode);
    }


    public class SimpleReports : ISimpleReports, IDashboard, IContext, IOrganic, ISimilarkeys, IOwner
    {
        string token = string.Empty;
        private const string baseUrl = "report/simple/";

        public SimpleReports()
        {
            vHttpClient client = new vHttpClient(token);
        }

        public async Task<string> Dashboard(string @base, string domain)
        {
            string Url = "domain_dashboard";
           
            return baseUrl + Url + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> DashboardKey(string @base, string keyword)
        {
            string Url = "domain_dashboard";

            return baseUrl + Url + "?base=" + @base + "&domain=" + keyword;
        }
        
        public async Task<string> KeyWordObyavlenia(string @base, string domain, int ads_id)   //?????????????????????
        {
            string Url = "context/keywords/byads";

            return baseUrl + Url + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> Advertisement(string @base, string domain, bool full)
        {
            string Url = "report/simple/context/ads";

            return baseUrl + Url + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> UFact(string @base, string domain)
        {
            string Url = "report/simple/context/ads/facts";

            return baseUrl + Url + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> ULink(string @base, string domain)
        {
            string Url = "report/simple/context/ads/links";

            return baseUrl + Url + "?base=" + @base + "&domain=" + domain;
        }

        public async Task<string> SitePage(string @base, string domain)
        {
            string Url = "report/simple/organic/sitepages";

            return baseUrl + Url + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> KeyWordPage(string @base, string domain, string page_url)
        {
            string Url = "report/simple/organic/keywords/bypage?";

            return baseUrl + Url + "?base=" + @base + "&domain=" + domain + "&page_url=" + page_url;
        }
        public async Task<string> PageConcurents(string @base, string domain, string page_url)
        {
            string Url = "report/simple/organic/concurent_pages";

            return baseUrl + Url + "?base=" + @base + "&domain=" + "&page_url=" + page_url;
        }

        public async Task<string> KeyWord(string context, string @base, string domain)
        {
            if (context == "context" || context == "organic")
            {
                string Url = baseUrl + context + "/keywords";

                return Url + "?base=" + @base + "&domain=" + domain; 
            }
            else
            {
                return "Неверный контекст";
            }
        }
        public async Task<string> Concurents(string @base, string domain)
        {
            string Url = "organic/concurents";

            return baseUrl + Url + "?base=" + @base + "&domain=" + domain;;
        }

        public async Task<string> Owner(string id, string mode)
        {
            string Url = "report/owner/";

            return Url + mode + "?id=" + id;

        }
        public async Task<string> Similarkeys(string @base, string keyword)
        {
            string Url = "similarkeys";

            return  baseUrl + Url + "?base=" + @base + "&domain=" + keyword;;
        }



    }

}
