using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryDatabaseProject
{
    public partial class AddBook : Form
    {
        List<string> publishersList;
        List<string> genreList;

        //INSERT INTO item(item_title, genre)
        //VALUES( "Gregg Brobeans",  "Comedy");

        //INSERT INTO book(author, item_id)
        //VALUES("Gregg is the best", (SELECT item_id FROM item ORDER BY item_id DESC LIMIT 1))


        //INSERT INTO book_publishedby(item_id, publisher_id)
        //VALUES((SELECT item_id FROM item ORDER BY item_id DESC LIMIT 1),    14   )


        public AddBook()
        {
            InitializeComponent();
        }

        private void insertBookButton_Click(object sender, EventArgs e)
        {

            //validate fields
            //insert new book

            int genreIndex = genreComboBox.SelectedIndex;
            int pubIndex = publisherComboBox.SelectedIndex;

            string p = publishersList.ElementAt(pubIndex);
            string g = genreList.ElementAt(genreIndex);

            string title = titleTextBox.Text;
            string author = authorTextBox.Text;
            DateTime date = datePicker.Value;

            if (author == "" || title == "" )
            {
                //validation error
                MessageBox.Show("Please fix invalid input", "Library Database",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {

                using (var context = new LibraryModel())
                {

                    //INSERT INTO item(item_title, genre)
                    //VALUES([title], [genre]);

                    item i = new item
                    {
                        genre = g,
                        Item_title = title,
                        release_date = date
                    };

                    context.items.Add(i);
                    context.SaveChanges();

                    int id = (from item in context.items
                              orderby item.item_id descending
                              select item).FirstOrDefault().item_id;

                    //INSERT INTO book(author, item_id)
                    //VALUES([author], (SELECT item_id FROM item ORDER BY item_id DESC LIMIT 1))

                    book b = new book
                    {
                        item_id = id,
                        author = author
                    };

                    context.books.Add(b);

                    int pid = (from pub in context.publishers
                               where pub.publisher_name == p
                               select pub).First().publisher_id;

                    //INSERT INTO book_publishedby(item_id, publisher_id)
                    //VALUES((SELECT item_id FROM item ORDER BY item_id DESC LIMIT 1), [publisherid])

                    book_publishedby published = new book_publishedby
                    {
                        item_id = id,
                        publisher_id = pid

                    };

                    context.book_publishedby.Add(published);
                    context.SaveChanges();
                    context.Dispose();
                }

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBookLoad(object sender, EventArgs e)
        {

            using (var context = new LibraryModel())
            {
                var publishers = from p in context.publishers
                                 select p;

                publishersList = new List<string>();

                foreach(var p in publishers)
                {
                    publishersList.Add(p.publisher_name);
                }

                publishersList.Sort();

                publisherComboBox.DataSource = publishersList;

                var genres = (from item in context.items
                                 select item.genre).Distinct();

                genreList = new List<string>();

                foreach (var g in genres)
                {
                    genreList.Add(g);
                }

                genreComboBox.DataSource = genreList;

            }

        }
    }
}
