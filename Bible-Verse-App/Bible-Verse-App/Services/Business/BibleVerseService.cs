using Bible_Verse_App.Models;
using Bible_Verse_App.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bible_Verse_App.Services.Business
{
    public class BibleVerseService
    {
        BibleVerseDAO daoService = new BibleVerseDAO();

        public bool AddBibleVerse(BibleVerse verse)
        {
            return daoService.AddBibleVerse(verse);
        }

        public BibleVerse SearchForBibleVerse(BibleVerse bibleVerse)
        {
            string testament = bibleVerse.Testament;
            string book = bibleVerse.Book;
            int chapterNumber = bibleVerse.ChapterNumber;
            int verseNumber = bibleVerse.VerseNumber;

            return daoService.SearchForBibleVerse(testament, book, chapterNumber, verseNumber);
        }
    }
}