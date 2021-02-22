using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bible_Verse_App.Models
{
    public class BibleVerse
    {

        [Required]
        [DisplayName("Testament")]
        [StringLength(50, ErrorMessage ="Testament muct be between 1 and 50 characters")]
        public string Testament { get; set; }

        [Required]
        [DisplayName("Book")]
        [StringLength(50, ErrorMessage = "Testament muct be between 1 and 50 characters")]
        public string Book { get; set; }

        [Required]
        [DisplayName("Chapter Number")]
        [Range(1, 10000, ErrorMessage = "Must be between 1 and 10,000")]
        public int ChapterNumber { get; set; }

        [Required]
        [DisplayName("Verse Number")]
        [Range(1, 10000, ErrorMessage = "Must be between 1 and 10,000")]
        public int VerseNumber { get; set; }

        [Required]
        [DisplayName("Verse Text")]
        public string VerseText { get; set; }

        public BibleVerse()
        {
        }

        public BibleVerse(string testament, string book, int chapterNumber, int verseNumber, string verseTest)
        {
            Testament = testament;
            Book = book;
            ChapterNumber = chapterNumber;
            VerseNumber = verseNumber;
            VerseText = verseTest;
        }
    }
}