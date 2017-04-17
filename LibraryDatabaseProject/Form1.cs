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

        public Form1()
        {
            selectedItem = SelectedItem.Book;
            InitializeComponent();

            switchToBookView();

            genres = new List<string>();
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
                        
                        books = addGenreFilter(books);

                        // Execute query
                        foreach (var book1 in books)
                        {
                            searchResultsGrid.Rows.Add(createBookRow(book1));
                        }
                        break;

                    case SelectedItem.Movie:
                        break;

                    case SelectedItem.Music:
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

        private DataGridViewRow createBookRow(item newBook)
        {
            DataGridViewRow newRow = (DataGridViewRow)searchResultsGrid.Rows[0].Clone();

            newRow.Cells[0].Value = newBook.Item_title;
            newRow.Cells[1].Value = newBook.genre;
            newRow.Cells[2].Value = newBook.release_date;
            newRow.Cells[3].Value = newBook.book.author;

            return newRow;
        }

        private void switchToBookView()
        {
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
        }

        private void switchToMovieView()
        {
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
        }

        private void switchToMusicView()
        {
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
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            genres.Clear();

            foreach (var item in checkedListBox1.CheckedItems)
                genres.Add(item.ToString());

            if (e.NewValue == CheckState.Checked)
                genres.Add(checkedListBox1.Items[e.Index].ToString());

            // TODO: doesn't properly remove genres
            //DEBUG
            foreach (var genre in genres){
                Console.Write(genre + " ; ");
            }

            Console.WriteLine("");
        }
    }
}
