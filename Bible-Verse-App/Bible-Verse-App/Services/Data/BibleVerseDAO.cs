using Bible_Verse_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Bible_Verse_App.Services.Data
{
    public class BibleVerseDAO
    {
        public bool AddBibleVerse (BibleVerse queryVerse)
        {

            bool success = false;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleVerses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "INSERT INTO dbo.Verses (Testament, Book, ChapterNumber, VerseNumber, VerseText) VALUES (@Testament, @Book, @ChapterNumber, @VerseNumber, @VerseText);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //create command and parameter objects
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@Testament", queryVerse.Testament);
                command.Parameters.AddWithValue("@Book", queryVerse.Book);
                command.Parameters.AddWithValue("@ChapterNumber", queryVerse.ChapterNumber);
                command.Parameters.AddWithValue("@VerseNumber", queryVerse.VerseNumber);
                command.Parameters.AddWithValue("@VerseText", queryVerse.VerseText);


                // open the database and run the command
                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    success = true;
                }
                catch (Exception e)
                {
                    success = false;
                    Console.WriteLine(e.Message);
                }
            }

            return success;
        }

        public BibleVerse SearchForBibleVerse(string testament, string book, int chapterNumber, int verseNumber)
        {

            BibleVerse bibleVerse = new BibleVerse();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleVerses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "SELECT * FROM dbo.Verses WHERE Testament = @Testament AND Book = @Book AND ChapterNumber = @ChapterNumber AND VerseNumber = @VerseNumber";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                //create command and parameter objects
                SqlCommand command = new SqlCommand(queryString, conn);
                command.Parameters.AddWithValue("@Testament", testament);
                command.Parameters.AddWithValue("@Book", book);
                command.Parameters.AddWithValue("@ChapterNumber", chapterNumber);
                command.Parameters.AddWithValue("@VerseNumber", verseNumber);

                // open the database and run the command
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        bibleVerse.Testament = reader["Testament"].ToString();
                        bibleVerse.Book = reader["Book"].ToString();
                        bibleVerse.ChapterNumber = Convert.ToInt32(reader["ChapterNumber"].ToString());
                        bibleVerse.VerseNumber = Convert.ToInt32(reader["VerseNumber"].ToString());
                        bibleVerse.VerseText = reader["VerseText"].ToString();

                    }
                    reader.Close();
                    conn.Close();
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            return bibleVerse;
        }


    }
}