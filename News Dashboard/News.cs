using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_Dashboard.News
{
    public class News
    {
        /// <summary>
        /// Returns Headlines from News API
        /// </summary>
        /// <param name="q"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public static Article[] HeadlinesQuery(Countries country, string q)
        {
            try
            {
                //Setting API Key to consume API
                var newsApiClient = new NewsApiClient("f8d0717df9844f2d8d1339037b93fd35");

                //Get headlines based on given parms
                var articlesReturn = newsApiClient.GetTopHeadlines(new TopHeadlinesRequest
                {
                    Country = country,
                    Q = q
                });

                return articlesReturn.Articles.ToArray(); //Put List<> to Array as that is what the model type is
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

       
    }
}
