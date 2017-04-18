using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDatabaseProject
{
 
    public partial class AddMovie : Form
    {
        List<string> genreList;
        string[] ratings;

        public AddMovie()
        {
            InitializeComponent();
        }

        private void insertMovie(object sender, EventArgs e)
        {

            string director = directorTextBox.Text;
            string title = titleTextBox.Text;
            string durationStr = durationTextBox.Text;

            int rIndex = ratingComboBox.SelectedIndex;
            int gIndex = genreComboBox.SelectedIndex;

            string genre = genreList.ElementAt(gIndex);
            string mpaaRating = ratings[rIndex];
            DateTime date = datePicker.Value;

            //validate input

            int duration;
            bool result = int.TryParse(durationStr, out duration);

            if (director == "" || title == "" || durationStr == "" || !result )
            {
                //validation error
                MessageBox.Show("Please fix invalid input", "Library Database",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                //validation successful
                //insert new movie

                using (var context = new LibraryModel())
                {
                    //INSERT INTO item(Item_title, genre, release_date)
                    //VALUES([title], [genre], [date])
                    item i = new item
                    {
                        genre = genre,
                        Item_title = title,
                        release_date = date
                    };

                    context.items.Add(i);
                    context.SaveChanges();

                    int id = (from item in context.items
                              orderby item.item_id descending
                              select item).FirstOrDefault().item_id;

                    //INSERT INTO movie(item_id, director, mpaa_rating, duration)
                    //VALUES((SELECT item_id FROM item ORDER BY item_id DESC LIMIT 1), [director], [mpaa_rating], [duration])

                    movie m = new movie
                    {
                        item_id = id,
                        director = director,
                        mpaa_rating = mpaaRating,
                        duration = duration
                    };

                    context.movies.Add(m);
                    context.SaveChanges();
                    context.Dispose();

                }

                this.Close();
            }
        }

        private void cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onLoad(object sender, EventArgs e)
        {
            using (var context = new LibraryModel())
            {

                ratings = new string[]{ "G", "PG", "PG-13", "R", "NR"};
                ratingComboBox.DataSource = ratings;

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
