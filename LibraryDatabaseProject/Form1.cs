using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqKit;

namespace LibraryDatabaseProject
{
    public partial class Form1 : Form
    {
        enum SelectedItem { Book, Movie, Music };
        SelectedItem selectedItem;
        List<String> genres;
        List<String> durations;
        List<String> mpaaRatings;
        List<String> numTracks;

        public Form1()
        {
            selectedItem = SelectedItem.Book;
            InitializeComponent();

            switchToBookView();

            genres = new List<string>();
            durations = new List<string>();
            mpaaRatings = new List<string>();
            numTracks = new List<string>();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchResultsGrid.Rows.Clear();

            var title = searchTextBox.Text;

            using (var context = new LibraryModel())
            {
                switch (selectedItem)
                {
                    case SelectedItem.Book:
                        // Basic query
                        var books = context.items.Include("book").Where(i => i.Item_title.ToUpper().Contains(title.ToUpper())).Where(i => i.book != null);

                        // Apply filters
                        books = addGenreFilter(books);

                        // Execute query
                        foreach (var book in books)
                        {
                            searchResultsGrid.Rows.Add(createBookRow(book));
                        }
                        break;

                    case SelectedItem.Movie:
                        // Basic query
                        var movies = context.items.Include("movie").Where(i => i.Item_title.ToUpper().Contains(title.ToUpper())).Where(i => i.movie != null);

                        // Apply filters
                        movies = addGenreFilter(movies);
                        movies = addDurationFilter(movies);
                        movies = addMpaaRatingsFilter(movies);

                        // Execute query
                        foreach (var movie in movies)
                        {
                            searchResultsGrid.Rows.Add(createMovieRow(movie));
                        }
                        break;

                    case SelectedItem.Music:
                        // Basic query
                        var music = context.items.Include("musicalbum").Where(i => i.Item_title.ToUpper().Contains(title.ToUpper())).Where(i => i.musicalbum != null);

                        // Apply filters
                        music = addGenreFilter(music);
                        music = addNumTracksFilter(music);

                        // Execute query
                        foreach (var album in music)
                        {
                            searchResultsGrid.Rows.Add(createMusicRow(album));
                        }
                        break;

                    default:
                        break;
                }
            }

            searchResultsGrid.Update();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                selectedItem = SelectedItem.Movie;
                switchToMovieView();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                selectedItem = SelectedItem.Book;
                switchToBookView();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                selectedItem = SelectedItem.Music;
                switchToMusicView();
            }
        }

        private IQueryable<item> addGenreFilter(IQueryable<item> query)
        {
            var pred = PredicateBuilder.False<item>();

            foreach (var genre in genres)
            {
                pred = pred.Or(p => p.genre.Contains(genre));
            }

            return query.AsExpandable().Where(pred);
        }


        private IQueryable<item> addDurationFilter(IQueryable<item> query)
        {
            var pred = PredicateBuilder.False<item>();

            foreach (var duration in durations)
            {
                if (duration.Contains("0 - 30"))
                {
                    pred = pred.Or(p => p.movie.duration >= 0 && p.movie.duration <= 30);
                }
                if (duration.Contains("30 - 60"))
                {
                    pred = pred.Or(p => p.movie.duration >= 30 && p.movie.duration <= 60);
                }
                if (duration.Contains("60 - 120"))
                {
                    pred = pred.Or(p => p.movie.duration >= 60 && p.movie.duration <= 120);
                }
                if (duration.Contains("120 - 180"))
                {
                    pred = pred.Or(p => p.movie.duration >= 120 && p.movie.duration <= 180);
                }
                if (duration.Contains("180 min"))
                {
                    pred = pred.Or(p => p.movie.duration >= 180);
                }
            }

            return query.AsExpandable().Where(pred);
        }

        private IQueryable<item> addMpaaRatingsFilter(IQueryable<item> query)
        {
            var pred = PredicateBuilder.False<item>();

            foreach (var rating in mpaaRatings)
            {
                pred = pred.Or(p => p.movie.mpaa_rating.Equals(rating));
            }

            return query.AsExpandable().Where(pred);
        }

        private IQueryable<item> addNumTracksFilter(IQueryable<item> query)
        {
            var pred = PredicateBuilder.False<item>();

            foreach (var num in numTracks)
            {
                if (num.Contains("0 - 4"))
                {
                    pred = pred.Or(p => p.musicalbum.num_of_tracks >= 0 && p.musicalbum.num_of_tracks <= 4);
                }
                if (num.Contains("4 - 8"))
                {
                    pred = pred.Or(p => p.musicalbum.num_of_tracks >= 4 && p.musicalbum.num_of_tracks <= 8);
                }
                if (num.Contains("8 - 12"))
                {
                    pred = pred.Or(p => p.musicalbum.num_of_tracks >= 8 && p.musicalbum.num_of_tracks <= 12);
                }
                if (num.Contains("12 - 16"))
                {
                    pred = pred.Or(p => p.musicalbum.num_of_tracks >= 12 && p.musicalbum.num_of_tracks <= 16);
                }
                if (num.Contains("16 or"))
                {
                    pred = pred.Or(p => p.musicalbum.num_of_tracks >= 16);
                }
            }

            return query.AsExpandable().Where(pred);
        }


        private DataGridViewRow createBookRow(item newBook)
        {
            DataGridViewRow newRow = (DataGridViewRow)searchResultsGrid.Rows[0].Clone();

            newRow.Cells[0].Value = newBook.Item_title;
            newRow.Cells[1].Value = newBook.genre;
            newRow.Cells[2].Value = newBook.release_date;
            newRow.Cells[3].Value = newBook.book.author;

            return newRow;
        }

        private DataGridViewRow createMovieRow(item newMovie)
        {
            DataGridViewRow newRow = (DataGridViewRow)searchResultsGrid.Rows[0].Clone();

            newRow.Cells[0].Value = newMovie.Item_title;
            newRow.Cells[1].Value = newMovie.genre;
            newRow.Cells[2].Value = newMovie.release_date;
            newRow.Cells[5].Value = newMovie.movie.duration;
            newRow.Cells[6].Value = newMovie.movie.director;
            newRow.Cells[7].Value = newMovie.movie.mpaa_rating;

            return newRow;
        }

        private DataGridViewRow createMusicRow(item newAlbum)
        {
            DataGridViewRow newRow = (DataGridViewRow)searchResultsGrid.Rows[0].Clone();

            newRow.Cells[0].Value = newAlbum.Item_title;
            newRow.Cells[1].Value = newAlbum.genre;
            newRow.Cells[2].Value = newAlbum.release_date;
            newRow.Cells[8].Value = newAlbum.musicalbum.artist;
            newRow.Cells[9].Value = newAlbum.musicalbum.num_of_tracks;

            return newRow;
        }

        private void switchToBookView()
        {
            searchResultsGrid.Rows.Clear();

            // Reset all columns to visible
            foreach (DataGridViewColumn column in searchResultsGrid.Columns)
            {
                column.Visible = true;
            }

            //Hide unwanted columns
            searchResultsGrid.Columns[5].Visible = false;
            searchResultsGrid.Columns[6].Visible = false;
            searchResultsGrid.Columns[7].Visible = false;
            searchResultsGrid.Columns[8].Visible = false;
            searchResultsGrid.Columns[9].Visible = false;
            searchResultsGrid.Columns[10].Visible = false;

            // Show/hide sidebar panels
            panel1.Visible = true;
            panel2.Visible = true;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
        }

        private void switchToMovieView()
        {
            searchResultsGrid.Rows.Clear();

            // Reset all columns to visible
            foreach (DataGridViewColumn column in searchResultsGrid.Columns)
            {
                column.Visible = true;
            }

            //Hide unwanted columns
            searchResultsGrid.Columns[3].Visible = false;
            searchResultsGrid.Columns[4].Visible = false;
            searchResultsGrid.Columns[8].Visible = false;
            searchResultsGrid.Columns[9].Visible = false;
            searchResultsGrid.Columns[10].Visible = false;

            // Show/hide sidebar panels
            panel1.Visible = true;
            panel2.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = false;
        }

        private void switchToMusicView()
        {
            searchResultsGrid.Rows.Clear();

            // Reset all columns to visible
            foreach (DataGridViewColumn column in searchResultsGrid.Columns)
            {
                column.Visible = true;
            }

            //Hide unwanted columns
            searchResultsGrid.Columns[3].Visible = false;
            searchResultsGrid.Columns[4].Visible = false;
            searchResultsGrid.Columns[5].Visible = false;
            searchResultsGrid.Columns[6].Visible = false;
            searchResultsGrid.Columns[7].Visible = false;

            // Show/hide sidebar panels
            panel1.Visible = true;
            panel2.Visible = true;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            genres.Clear();

            foreach (var item in checkedListBox1.CheckedItems)
                genres.Add(item.ToString());
            
            if (e.NewValue == CheckState.Checked)
                genres.Add(checkedListBox1.Items[e.Index].ToString());
            else if (e.NewValue == CheckState.Unchecked)
                genres.Remove(checkedListBox1.Items[e.Index].ToString());
        }


        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            durations.Clear();

            foreach (var item in checkedListBox2.CheckedItems)
                durations.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
                durations.Add(checkedListBox2.Items[e.Index].ToString());
            else if (e.NewValue == CheckState.Unchecked)
                durations.Remove(checkedListBox2.Items[e.Index].ToString());
        }

        private void checkedListBox3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            mpaaRatings.Clear();

            foreach (var item in checkedListBox3.CheckedItems)
                mpaaRatings.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
                mpaaRatings.Add(checkedListBox3.Items[e.Index].ToString());
            else if (e.NewValue == CheckState.Unchecked)
                mpaaRatings.Remove(checkedListBox3.Items[e.Index].ToString());
        }

        private void checkedListBox4_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            numTracks.Clear();

            foreach (var item in checkedListBox4.CheckedItems)
                numTracks.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
                numTracks.Add(checkedListBox4.Items[e.Index].ToString());
            else if (e.NewValue == CheckState.Unchecked)
                numTracks.Remove(checkedListBox4.Items[e.Index].ToString());
        }
    }
}
