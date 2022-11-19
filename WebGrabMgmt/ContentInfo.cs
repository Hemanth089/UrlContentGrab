using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebGrabDemo.Models;

namespace WebGrabDemo.WebGrabMgmt
{
    public class ContentInfo
    {
        /// <summary>
        /// Grabs the content of the URL
        /// </summary>
        /// <param name="url">Enter Valid website URL</param>
        /// <returns>Content of the URL</returns>
        public ContentModel GetContentInfo(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            WebGrabProcessor processor = new WebGrabProcessor();
            string html = processor.GrabContent(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            DocProcessor docProcessor = new DocProcessor(doc);
            List<string> imageUrls = docProcessor.GetImageUrls();

            List<string> allWords = docProcessor.GetWordsFromDoc();
            int wordsCount = allWords.Count();

            List<WordModel> topWordsCountList = allWords.GroupBy(g => g.ToLower())
                                                     .Select(w => new WordModel
                                                     {
                                                         Word = w.Key,
                                                         WordCount = w.Count()
                                                     })
                                                     .OrderByDescending(d => d.WordCount)
                                                     .Take(10)
                                                     .ToList();

            List<WordModel> allWordsCountList = allWords.GroupBy(g => g.ToLower())
                                                     .Select(w => new WordModel
                                                     {
                                                         Word = w.Key,
                                                         WordCount = w.Count()
                                                     })
                                                     .OrderByDescending(d => d.WordCount)
                                                     .ToList();

            ContentModel contentModel = new ContentModel
            {
                ImageUrls = imageUrls,
                AllWordsCount = wordsCount,
                TopWords = topWordsCountList,
                AllWords = allWordsCountList

            };

            return contentModel;
        }
    }
}