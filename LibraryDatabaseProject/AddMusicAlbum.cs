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
    public partial class AddMusicAlbum : Form
    {
        List<string> genreList;

        public AddMusicAlbum()
        {
            InitializeComponent();
        }

        private void insertMusicAlbum(object sender, EventArgs e)
        {
            string artist = artistTextBox.Text;
            string title = titleTextBox.Text;
            string numTracksString = numTracksTextBox.Text;
            int gIndex = genreComboBox.SelectedIndex;

            string genre = genreList.ElementAt(gIndex);
            DateTime date = datePicker.Value;

            //validate input

            int numTracks;
            bool result = int.TryParse(numTracksString, out numTracks);

            if (artist == "" || title == "" || numTracksString == "" || !result)
            {
                //validation error
                MessageBox.Show("Please fix invalid input", "Library Database",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                //validation successful
                //insert new music album

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

                    //INSERT INTO musicalbum(item_id, artist, num_of_tracks)
                    //VALUES((SELECT item_id FROM item ORDER BY item_id DESC LIMIT 1), [artist], [numTracks])

                    musicalbum m = new musicalbum
                    {
                        item_id = id,
                        artist = artist,
                        num_of_tracks = numTracks
                    };

                    context.musicalbums.Add(m);
                    context.SaveChanges();

                    var musicWithGenre = from item in context.items
                                          join music in context.musicalbums on item.item_id equals music.item_id
                                          group item.item_id by item.genre into group1
                                          select new
                                          {
                                              count = group1.Count(),
                                              genre = group1.Key

                                          };

                    string message = "____________________________\n\n";
                    foreach (var selectedGenre in musicWithGenre)
                    {
                        message = message + selectedGenre.genre + "(" + selectedGenre.count + ")\n";
                    }


                    MessageBox.Show("You've added '" + title + "'.\nThis music album has been added into the genre '" + genre + "'.\n" + message, "Library Database",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

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
