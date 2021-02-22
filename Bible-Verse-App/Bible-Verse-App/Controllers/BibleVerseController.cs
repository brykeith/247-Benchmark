/*
 * Benchmark Bible Project 
 * ver. 1 
 * Brydon Johnson
 * 
 * Controller: BibleVerseController:
 *      this controller handles all actions pertaining to the Bible Verse functionality
 *      
 *      Functions:
 *          Index()
 *              returns "AddBibleVerse" view
 *          GoToSearch()
 *              navigates to "SearchForBibleVerse" view
 *          AddBibleVerse(BibleVerse bibleVerse)
 *              uses the BibleVerseService object to add the user input bible verse to the dbo.verses database table
 *          SearchForBibleVerse(BibleVerse queryVerse)
 *              uses the BibleVerseService object to query the user input bible verse from the dbo.verses database table
 *              
 */





using Bible_Verse_App.Models;
using Bible_Verse_App.Services.Business;
using Bible_Verse_App.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bible_Verse_App.Controllers
{
    public class BibleVerseController : Controller
    {



        // returns AddBibleVerse view
        public ActionResult Index()
        {
            return View("AddBibleVerse");
        }

        // returns SearchForBibleVerse view
        public ActionResult GoToSearch()
        {
            return View("SearchForBibleVerse");
        }

        public ActionResult AddBibleVerse(BibleVerse bibleVerse)
        {
            BibleVerseService bibleVerseService = new BibleVerseService();
            if (bibleVerseService.AddBibleVerse(bibleVerse))
            {
                MyLogger.GetInstance().Info("Added Bible Verse to the database");
                return View("VerseSuccessfullyAdded", bibleVerse);
            }
            else
            {
                MyLogger.GetInstance().Error("Failed to add Bible Verse to database");
                return View("AddFailed");
            }
        }

        public ActionResult SearchForBibleVerse(BibleVerse queryVerse)
        {
            BibleVerseService bibleVerseService = new BibleVerseService();

            BibleVerse bibleVerse = bibleVerseService.SearchForBibleVerse(queryVerse);

            if (bibleVerse.Testament!= null)
            {
                MyLogger.GetInstance().Info("Located Bible Verse with search");
                return View("DisplayBibleVerse", bibleVerse);
            }
            else
            {
                MyLogger.GetInstance().Info("Failed to Locate the Bible Verse with search");
                return View("NoResultsFound");
            }
        }
    }
}