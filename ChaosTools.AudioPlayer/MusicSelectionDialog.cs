using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChaosTools.AudioPlayer
{
    public partial class MusicSelectionDialog : Form
    {
        public MusicSelectionDialog()
        {
            InitializeComponent();
            this.musicTypeCMB.Items.Clear();
            int i, count;
            List<TagValue<MusicData.MusicTypeIndex>> musicTypes = MusicData.GetAllLocalizedMusicTypes();
            count = musicTypes.Count;
            for (i = 0; i < count; i++)
            {
                this.musicTypeCMB.Items.Add(musicTypes[i]);
            }
            this.genreCMB.Items.Clear();
            List<TagValue<string>> genres = MusicData.GetAllLocalizedGenres();
            count = genres.Count;
            for (i = 0; i < count; i++)
            {
                this.genreCMB.Items.Add(genres[i]);
            }
        }

        private MusicData.MusicTypeIndex mSelectedMusicType;
        private string mSelectedGenre;
        private MusicData.SongData mSelectedSong;

        public MusicData.MusicTypeIndex SelectedMusicType
        {
            get { return this.mSelectedMusicType; }
        }

        public string SelectedGenre
        {
            get { return this.mSelectedGenre; }
        }

        public MusicData.SongData SelectedSong
        {
            get { return this.mSelectedSong; }
        }

        private void musicTypeGenreSelectionChangeCommitted(object sender, EventArgs e)
        {
            TagValue<MusicData.MusicTypeIndex> musicType = this.musicTypeCMB.SelectedItem as TagValue<MusicData.MusicTypeIndex>;
            TagValue<string> genre = this.genreCMB.SelectedItem as TagValue<string>;
            if (musicType != null && genre != null)
            {
                this.mSelectedMusicType = musicType.Value;
                this.mSelectedGenre = genre.Value;
                this.mSelectedSong = null;
                this.songListView.Items.Clear();
                List<MusicData.SongData> songList = MusicData.GetSongList(musicType.Value, genre.Value);
                MusicData.SongData song;
                for (int i = 0; i < songList.Count; i++)
                {
                    song = songList[i];
                    this.songListView.Items.Add(new ListViewItem(new string[] { song.mSongName, song.mArtist, song.mSongKey }));
                }
            }
        }

        private void songListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.songListView.SelectedItems.Count == 0)
                this.mSelectedSong = null;
            else
            {
                ListViewItem selectedSong = this.songListView.SelectedItems[0];
                this.mSelectedSong = new MusicData.SongData(
                    selectedSong.SubItems[2].Text,
                    selectedSong.SubItems[0].Text,
                    selectedSong.SubItems[1].Text);
            }
        }
    }
}
