using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGrabDemo.WebGrabMgmt
{
    public class DocProcessor
    {
        private HtmlDocument _doc;
        public DocProcessor(HtmlDocument doc)
        {
            _doc = doc;
        }

        /// <summary>
        /// Grabs all the words
        /// </summary>
        /// <returns>All words from the URL</returns>
        public List<string> GetWordsFromDoc()
        {
            char[] delimiter = new char[] { ' ' };

            List<string> allWords = new List<string>();
            foreach (string text in _doc.DocumentNode
                .SelectNodes("//body//text()[not(parent::script)]")
                .Select(node => node.InnerText))
            {
                List<string> words = text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).Where(s => Char.IsLetter(s[0])).ToList();

                if (words != null && words.Count > 0)
                    allWords.AddRange(words);
            }

            return allWords;
        }

        /// <summary>
        /// Grabs all the image URLs
        /// </summary>
        /// <returns>All image URLs from the URL</returns>
        public List<string> GetImageUrls()
        {
            List<string> imageUrls = _doc.DocumentNode.Descendants("img")
                                      .Select(e => e.GetAttributeValue("src", null))
                                      .Where(s => !String.IsNullOrEmpty(s))
                                      .ToList();

            return imageUrls;
        }
    }
}