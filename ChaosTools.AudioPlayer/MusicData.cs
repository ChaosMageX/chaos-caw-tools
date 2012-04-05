using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Sims3.SimIFace;
using ChaosTools.Sims3Engine;

namespace ChaosTools.AudioPlayer
{
    public class MusicData
    {
        /// <summary>
        /// Copied from <see cref="T:Sims3.UI.OptionsDialog.MusicTypeIndex"/>
        /// </summary>
        public enum MusicTypeIndex
        {
            Stereo,
            Build,
            Buy,
            Map,
            CAS,
            Custom
            //Max
        }

        /// <summary>
        /// Copied from <see cref="T:Sims3.UI.OptionsDialog.SongData"/>
        /// </summary>
        public class SongData
        {
            public string mArtist;
            public string mSongKey;
            public string mSongName;

            public SongData()
            {
            }
            public SongData(string sKey, string sName, string sArtist)
            {
                mSongKey = sKey;
                mSongName = sName;
                mArtist = sArtist;
            }
        }

        private static readonly ulong[] kMusicTypeLocalKeys = new ulong[]
        {
            0x714efa100b52b3d0,
            0xc03d73aa42fa110a,
            0x3d583454303ad452,
            0x2ea01e6e9d4fc716,
            0x3b22a138a18c6942,
            0x465D28DAABD252C2 //"Ui/Caption/Options/MusicSelection:Custom"
        };

        private static ScriptCore.UIManager gUIMgr = null;
        private static ScriptCore.LocalizedStringService gLocalizer = null;

        private static List<Dictionary<string, List<SongData>>> sMusicData;
        private static List<List<string>> sMusicGenres;
        private static Dictionary<string, string> sLocalizedGenres = new Dictionary<string, string>();

        /// <summary>
        /// Get the localized string name of the given music type.
        /// </summary>
        /// <param name="musicType">The music type to localize.</param>
        /// <returns>The localized name of the music type.</returns>
        public static string GetLocalizedMusicType(MusicTypeIndex musicType)
        {
            if (gLocalizer == null)
                return musicType.ToString();
            string result = gLocalizer.GetLocalizedString(kMusicTypeLocalKeys[(int)musicType]);
            if (string.IsNullOrEmpty(result))
                return musicType.ToString();
            return result;
        }

        /// <summary>
        /// Returns a TagValue list of all music types for use in selection GUI controls,
        /// all with localized tags.
        /// </summary>
        /// <returns>A TagValue list of all music types with localized tags.</returns>
        public static List<TagValue<MusicTypeIndex>> GetAllLocalizedMusicTypes()
        {
            List<TagValue<MusicTypeIndex>> results = new List<TagValue<MusicTypeIndex>>(6);
            for (int i = 0; i < 6; i++)
            {
                results.Add(new TagValue<MusicTypeIndex>((MusicTypeIndex)i, GetLocalizedMusicType((MusicTypeIndex)i)));
            }
            return results;
        }

        /// <summary>
        /// Gets all genre tags read from all the MusicEntries XML resources.
        /// </summary>
        /// <returns>All loaded music genre tags.</returns>
        public static string[] GetAllGenres()
        {
            if (sLocalizedGenres == null)
                return null;
            string[] genres = new string[sLocalizedGenres.Count];
            sLocalizedGenres.Keys.CopyTo(genres, 0);
            return genres;
        }

        /// <summary>
        /// Returns a TagValue list of all genres for use in selection GUI controls,
        /// all with localized tags.
        /// </summary>
        /// <returns>A TagValue list of all loaded genres with localized tags.</returns>
        public static List<TagValue<string>> GetAllLocalizedGenres()
        {
            List<TagValue<string>> results = new List<TagValue<string>>(sLocalizedGenres.Count);
            if (sLocalizedGenres == null)
            {
                return results;
            }
            foreach (KeyValuePair<string, string> genre in sLocalizedGenres)
            {
                results.Add(new TagValue<string>(genre.Key, genre.Value));
            }
            return results;
        }

        /// <summary>
        /// Returns the localized name of the given music genre tag.
        /// </summary>
        /// <param name="genre">The music genre name to localize.</param>
        /// <returns>The localized name of music genre.</returns>
        public static string GetLocalizedGenre(string genre)
        {
            if (sLocalizedGenres == null)
            {
                return genre;
            }
            string result;
            if (!sLocalizedGenres.TryGetValue(genre, out result))
            {
                return genre;
            }
            return result;
        }

        /// <summary>
        /// Returns a dictionary of song lists for each genre in the given music type.
        /// Stereo is the only type that will have multiple genres.
        /// All other types will just have the "All" genre, 
        /// except for Custom, which just has the "Custom" genre.
        /// </summary>
        /// <param name="musicType">The music type of the returned song lists.</param>
        /// <returns>The lists of all songs of the given music type.</returns>
        protected static Dictionary<string, List<SongData>> GetSongData(MusicTypeIndex musicType)
        {
            if (sMusicData == null)
                return null;
            int index = (int)musicType;
            if (index >= sMusicData.Count)
                return null;
            return sMusicData[index];
        }

        /// <summary>
        /// Returns a list of all songs of the given type and genre.
        /// </summary>
        /// <param name="musicType">The music type filter.</param>
        /// <param name="genre">The genre filter.</param>
        /// <returns>Null if the genre could not be found in the given music type.</returns>
        public static List<SongData> GetSongList(MusicTypeIndex musicType, string genre)
        {
            if (sMusicData == null)
                return new List<SongData>();
            int index = (int)musicType;
            if (index >= sMusicData.Count)
                return new List<SongData>();
            int count = sMusicGenres[index].Count;
            if (count == 0)
                return new List<SongData>();
            if (count == 1)
                return sMusicData[index][sMusicGenres[index][0]];
            List<SongData> songList;
            if (!sMusicData[index].TryGetValue(genre, out songList))
                return new List<SongData>();
            return songList;
        }

        /// <summary>
        /// Initializes the music data by reading it from the MusicEntries XML resources in UI.package.
        /// Copied from <see cref="M:Sims3.UI.OptionsDialog.SetupMusicControls()"/>.
        /// </summary>
        public static void Intialize()
        {
            gUIMgr = ChaosTools.Sims3Engine.ScriptCoreManager.UIManager;
            gLocalizer = ChaosTools.Sims3Engine.ScriptCoreManager.LocalizedStringService;

            LoadXmlData("MusicEntries");
            List<string> list = new List<string>();
            foreach (uint num in Enum.GetValues(typeof(ProductVersion)))
            {
                //if (GameUtils.IsInstalled((ProductVersion)num))
                {
                    string name = Enum.GetName(typeof(ProductVersion), num);
                    string item = "MusicEntries" + name;
                    list.Add(item);
                }
            }
            for (int i = list.Count - 1; i >= 0; i--)
            {
                LoadXmlData(list[i]);
            }
            LoadCustomSongData();
        }

        private static string Localize(string key)
        {
            if (gLocalizer == null)
                return key;
            else
            {
                string result = gLocalizer.GetLocalizedString(key);
                if (string.IsNullOrEmpty(result))
                    return key;
                return result;
            }
        }

        private const uint kXmlTID = 0x0333406c;

        private static bool LoadXmlData(string xmlFileName)
        {
            try
            {
                XmlDocument document = Simulator.LoadXML(xmlFileName);
                if (document == null)
                {
                    return false;
                }
                if (sMusicData == null)
                {
                    sMusicData = new List<Dictionary<string, List<SongData>>>(6);
                    sMusicData.Add(new Dictionary<string, List<SongData>>());
                    sMusicData.Add(new Dictionary<string, List<SongData>>());
                    sMusicData.Add(new Dictionary<string, List<SongData>>());
                    sMusicData.Add(new Dictionary<string, List<SongData>>());
                    sMusicData.Add(new Dictionary<string, List<SongData>>());
                }
                if (sMusicGenres == null)
                {
                    sMusicGenres = new List<List<string>>(6);
                    sMusicGenres.Add(new List<string>());
                    sMusicGenres.Add(new List<string>());
                    sMusicGenres.Add(new List<string>());
                    sMusicGenres.Add(new List<string>());
                    sMusicGenres.Add(new List<string>());
                }
                XmlElement topLevel = document.GetElementsByTagName("MusicSelection")[0] as XmlElement;
                if (topLevel != null)
                {
                    LoadSongData(topLevel, "Stereo", 0);
                    LoadSongData(topLevel, "Build", 1);
                    LoadSongData(topLevel, "Buy", 2);
                    LoadSongData(topLevel, "Map", 3);
                    LoadSongData(topLevel, "CAS", 4);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static void LoadSongData(XmlElement topLevel, string musicTypeName, int musicInfoIndex)
        {
            XmlNodeList musicTypeList = topLevel.GetElementsByTagName(musicTypeName);
            if (musicTypeList.Count > 0)
            {
                XmlNodeList genreList = (musicTypeList[0] as XmlElement).GetElementsByTagName("Genre");
                if (genreList.Count > 0)
                {
                    foreach (XmlElement genre in genreList)
                    {
                        XmlNodeList songEntryList = genre.GetElementsByTagName("Entry");
                        if (songEntryList.Count > 0)
                        {
                            string genreName = genre.Attributes.GetNamedItem("name").Value;
                            List<SongData> songDataList = null;
                            if (!sMusicData[musicInfoIndex].TryGetValue(genreName, out songDataList))
                            {
                                AddGenreButton(genre);
                                songDataList = new List<SongData>();
                                sMusicData[musicInfoIndex].Add(genreName, songDataList);
                                sMusicGenres[musicInfoIndex].Add(genreName);
                            }
                            foreach (XmlElement songEntry in songEntryList)
                            {
                                string sKey = songEntry.Attributes.GetNamedItem("songkey").Value;
                                string sName = songEntry.Attributes.GetNamedItem("title").Value;
                                string sArtist = songEntry.Attributes.GetNamedItem("artist").Value;
                                if (Convert.ToByte(songEntry.Attributes.GetNamedItem("ToBeLocalized").Value.Trim(), 10) != 0)
                                {
                                    sName = Localize(sName);
                                    sArtist = Localize(sArtist);
                                }
                                songDataList.Add(new SongData(sKey, sName, sArtist));
                            }
                            continue;
                        }
                    }
                }
            }
        }

        private static void AddGenreButton(XmlElement genre)
        {
            XmlNode namedItem = genre.Attributes.GetNamedItem("localizedName");
            if (namedItem != null)
            {
                sLocalizedGenres.Add(
                    genre.Attributes.GetNamedItem("name").Value,
                    Localize(namedItem.Value));
            }
            /*else
            {
                string name = genre.Attributes.GetNamedItem("name").Value;
                sLocalizedGenres.Add(name, name);
            }/**/
        }

        private static bool GetCustomMusicInfo(uint songNumber, ref string stringKey, ref string name, ref string artist)
        {
            if (gUIMgr == null)
                return false;
            string customMusicInfo;
            try
            {
                customMusicInfo = gUIMgr.GetCustomMusicInfo(songNumber);
            }
            catch
            {
                // Probably AccessViolationException because CAW's game engine can't read MP3s.
                return false;
            }
            if (customMusicInfo == null)
            {
                return false;
            }
            char[] separator = new char[] { '|' };
            string[] strArray = customMusicInfo.Split(separator);
            if (strArray.Length > 0)
            {
                stringKey = strArray[0];
            }
            else
            {
                stringKey = null;
            }
            if (strArray.Length > 1)
            {
                name = strArray[1];
            }
            else
            {
                name = "";
            }
            if (strArray.Length > 2)
            {
                artist = strArray[2];
            }
            if ((strArray.Length <= 2) || string.IsNullOrEmpty(artist))
            {
                artist = Localize("Ui/Caption/Options/MusicSelection:UnknownArtist");
            }
            return true;
        }

        private static readonly string kCustomGenreString = "Custom";

        private static void LoadCustomSongData()
        {
            List<SongData> list = new List<SongData>();
            uint songNumber = 0;
            SongData info = new SongData();
            while (GetCustomMusicInfo(songNumber, ref info.mSongKey, ref info.mSongName, ref info.mArtist))
            {
                list.Add(info);
                info = new SongData();
                songNumber++;
            }
            if (songNumber > 0)
            {
                sMusicData[0].Add(kCustomGenreString, list);
                sLocalizedGenres.Add(kCustomGenreString, 
                    Localize("Ui/Caption/Options/MusicSelection:Custom"));
            }
        }
    }
}
