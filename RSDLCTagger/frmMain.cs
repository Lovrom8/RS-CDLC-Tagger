using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Diagnostics;
using RocksmithToolkitLib.DLCPackage;
using KUtility;
using System.Drawing.Imaging;
using RocksmithToolkitLib.Extensions;
using RSDLCTagger.lib;
using System.Drawing.Drawing2D;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace RSDLCTagger
{
    public partial class frmMain : Form
    {
        Stopwatch stopWatch = new Stopwatch();
        private Settings mySettings;
        private List<string> SongCollection = new List<string>();

        int songCount = 0;
        string songExtractedPath = "";
        string manifestsFolderPath = "";
        string toolkitVersionFilePath = "";
        string albumArtFolderPath = "";
        string albumSmallArtPath = "";
        string albumMidArtPath = "";
        string albumBigArtPath = "";
        string tagsFolder = "frackDefault";
        string taggedPreviewPath = "";
        string cleanPreviewPath = "";

        Bitmap smallAlbumArt;
        Bitmap midAlbumArt;
        Bitmap bigAlbumArt;
        DDSImage albumArtDDS;

        bool lead = false;
        bool rhythm = false;
        bool bass = false;
        bool vocals = false;
        bool bonusLead = false;
        bool bonusRhythm = false;
        bool bonusBass = false;
        bool DD = false;
        bool allSelected = false;

        public frmMain()
        {
            InitializeComponent();

            mySettings = new Settings();

            LoadSettings();
            LoadSongs();
            LoadThemes();

            if (tbWorkingFolderPath.Text == "")
                tbWorkingFolderPath.Text = Environment.CurrentDirectory;

            comboTagPacks.SelectedIndex = 0;
        }

        private void LoadThemes()
        {
            foreach (string tagPreview in Directory.EnumerateFiles("tags", "*.png").Where(file => file.ToLower().Contains("prev")))
            {
                comboTagPacks.Items.Add(tagPreview.ToLower().Replace(@"tags\", "").Replace("prev.png", ""));
            }
        }

        private void LoadSongs(string searchCondition = "")
        {
            if (DirOK())
            {
                SongCollection = Directory.EnumerateFiles(Path.Combine(tbRSPath.Text, "dlc"), "*_p.*psarc", SearchOption.AllDirectories).ToList();
                foreach (string song in SongCollection.Where(sng => sng.ToLower().Contains(searchCondition.ToLower())))
                {
                    if (!song.Contains("rs1"))
                    {
                        string songAndFolderPath = new FileInfo(song).Directory.FullName.Replace(tbRSPath.Text + @"\", "").Replace(tbRSPath.Text, "");
                        string fileName = Path.GetFileName(song);
                        var creationTime = File.GetCreationTime(song);

                        if (creationTime == new DateTime(1990, 1, 1) || song.Replace(".disabled", "").LastIndexOf("-") == song.Replace(".disabled", "").LastIndexOf("_p.") - 1)
                            dgvSongs.Rows.Add(false, "Yes", Path.Combine(songAndFolderPath, fileName));
                        else
                            dgvSongs.Rows.Add(false, "No", Path.Combine(songAndFolderPath, fileName));
                    }
                }
            }
        }

        public void LoadSettings()
        {
            if (File.Exists("settings.json"))
            {
                string settingsJson = File.ReadAllText("settings.json");
                Settings settings = JsonConvert.DeserializeObject<Settings>(settingsJson);
                if (settings != null)
                {
                    tbRSPath.Text = settings.RSPath;
                    tbWorkingFolderPath.Text = settings.WorkingFolderPath;
                    checkDeleteExtractedOnDone.Checked = settings.DeleteDirs;
                }
            }
            else
            {
                mySettings.DeleteDirs = false;
                mySettings.RSPath = GetInstallDirFromRegistry();
                mySettings.WorkingFolderPath = Environment.CurrentDirectory;
                tbRSPath.Text = mySettings.RSPath;
            }
        }
        public void SaveSettings()
        {
            mySettings.RSPath = tbRSPath.Text;
            mySettings.DeleteDirs = checkDeleteExtractedOnDone.Checked;
            mySettings.WorkingFolderPath = tbWorkingFolderPath.Text;

            string settingsJson = JsonConvert.SerializeObject(mySettings, Formatting.Indented);

            using (StreamWriter file = new StreamWriter("settings.json"))
            {
                file.Write(settingsJson);
            }
        }

        private bool DirOK()
        {
            if (tbRSPath.Text == "")
            {
                MessageBox.Show("Please fill RS path and press load songs!", "RS path empty!");
                return false;
            }
            else
            {
                if (!Directory.Exists(tbRSPath.Text))
                {
                    MessageBox.Show("Please fix RS path!", "RS Folder doesn't exist!");
                    return false;
                }
            }

            if (!Directory.Exists(tbWorkingFolderPath.Text))
                tbWorkingFolderPath.Text = Environment.CurrentDirectory;

            return true;
        }

        private string GetInstallDirFromRegistry()
        {
            string test = String.Empty;
            const string rsX64Path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Ubisoft\Rocksmith2014";
            const string rsX64Steam = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 221680";

            try
            {
                test = Registry.GetValue(rsX64Path, "installdir", null).ToString();
                if (!String.IsNullOrEmpty(test))
                    return test;
                test = Registry.GetValue(rsX64Steam, "InstallLocation", null).ToString();
            }
            catch (NullReferenceException)
            {
                return test;
            }
            return test;
        }

        //Credits to Mark from StackOverflow
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private bool HasDD(string arrangementPath)
        {
            string songFileContent = File.ReadAllText(arrangementPath);
            var o = JObject.Parse(songFileContent);
            var attributes = o["Entries"].First.Last["Attributes"];

            if (attributes["MaxPhraseDifficulty"].ToString() != "0")
                return true;
            else
                return false;
        }

        private void ClearDirectory(string dirPath)
        {
            var dir = new DirectoryInfo(dirPath);

            dir.EnumerateFiles().ToList().ForEach(f => f.Delete());
            dir.EnumerateDirectories().ToList().ForEach(d => d.Delete(true));
        }

        private void btnRunRS_Click(object sender, EventArgs e)
        {
            var rocksmithProcess = Process.GetProcessesByName("Rocksmith2014.exe");

            if (rocksmithProcess.Length > 0)
                MessageBox.Show("Rocksmith 2014 is already running!");
            else
                Process.Start("steam://rungameid/221680");
        }

        private void btnProcessSelected_Click(object sender, EventArgs e)
        {
            string pathExtension = "_";
            int counter = 0;

            try
            {
                Bitmap backgroundLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Background.png"));
                Bitmap customTagLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Custom.png"));
                Bitmap vocalLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Vocal.png"));
                Bitmap leadLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Lead.png"));
                Bitmap rhythmLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Rhythm.png"));
                Bitmap bassLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Bass.png"));
                Bitmap leadBonusLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Lead Bonus.png"));
                Bitmap rhythmBonusLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Rhythm Bonus.png"));
                Bitmap bassBonusLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Bass Bonus.png"));

                if (DirOK())
                {
                    bgWorker = new BackgroundWorker();
                    bgWorker.DoWork += delegate
                    {
                        bool overwriteTags = checkOverwriteTagsOnTaggedSongs.Checked;
                        dgvSongs.InvokeIfRequired(delegate
                        {
                            songCount = dgvSongs.Rows.Cast<DataGridViewRow>().Where(row => ((Convert.ToBoolean(row.Cells["colSelect"].Value)) || row.Selected)).ToList().Count();
                        });

                        statusStripMain.InvokeIfRequired(delegate
                        {
                            statusLblTagged.Text = "Tagged: 0/" + songCount;
                        });

                        foreach (DataGridViewRow song in dgvSongs.Rows)
                        {
                            bool songTagged = song.Cells["colTagged"].Value.ToString() == "Yes" ? true : false;
                            if ((Convert.ToBoolean(song.Cells["colSelect"].Value) || song.Selected))
                            {
                                if (!songTagged || (songTagged && overwriteTags))
                                {
                                    pathExtension = "_";

                                    string songPath = Path.Combine(tbRSPath.Text, song.Cells["colPath"].Value.ToString());

                                    songExtractedPath = Path.Combine(tbWorkingFolderPath.Text, Path.GetFileName(songPath.Replace(".psarc", "_Pc")));
                                    manifestsFolderPath = Path.Combine(songExtractedPath, "manifests");
                                    albumArtFolderPath = Path.Combine(songExtractedPath, "gfxassets", "album_art");
                                    toolkitVersionFilePath = Path.Combine(songExtractedPath, "toolkit.version");
                                    taggedPreviewPath = Path.Combine(tbWorkingFolderPath.Text, "previews", Path.GetFileName(songPath.Replace("_p.psarc", "")) + "_tagged.png");
                                    cleanPreviewPath = Path.Combine(tbWorkingFolderPath.Text, "previews", Path.GetFileName(songPath.Replace("_p.psarc", "")) + "_clean.png");

                                    Packer.Unpack(songPath, tbWorkingFolderPath.Text);

                                    if (File.Exists(toolkitVersionFilePath))
                                    {
                                        albumSmallArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*64.dds").ToList()[0];
                                        albumMidArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*128.dds").ToList()[0];
                                        albumBigArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*256.dds").ToList()[0];

                                        albumArtDDS = new DDSImage(File.ReadAllBytes(albumBigArtPath));
                                        bigAlbumArt = albumArtDDS.images[0];

                                        midAlbumArt = ResizeImage(bigAlbumArt, 128, 128);
                                        smallAlbumArt = ResizeImage(bigAlbumArt, 64, 64);

                                        if (!Directory.Exists(Path.Combine(tbWorkingFolderPath.Text, "previews")))
                                            Directory.CreateDirectory(Path.Combine(tbWorkingFolderPath.Text, "previews"));

                                        midAlbumArt.Save("albumMidArt.png", ImageFormat.Png);
                                        File.Copy("albumMidArt.png", cleanPreviewPath, true);
                                        File.Delete("albumMidArt.png");

                                        //Check which arrangements it contains
                                        lead = false;
                                        rhythm = false;
                                        bass = false;
                                        vocals = false;
                                        bonusLead = false;
                                        bonusRhythm = false;
                                        bonusBass = false;
                                        DD = false;

                                        var arrangements = Directory.EnumerateFiles(manifestsFolderPath, "*.json", SearchOption.AllDirectories);

                                        foreach (string arrangement in arrangements)
                                        {
                                            // arrangement.Substring(arrangement.LastIndexOf("_") + 1, arrangement.Length - arrangement.LastIndexOf(".") + 1);
                                            if (arrangement.Contains("lead") && !arrangement.Contains("lead2"))
                                            {
                                                lead = true;
                                                pathExtension += "L";
                                                if (!DD)
                                                    DD = HasDD(arrangement);
                                            }
                                            if (arrangement.Contains("lead2"))
                                            {
                                                bonusLead = true;
                                                pathExtension += "l";
                                                if (!DD)
                                                    DD = HasDD(arrangement);
                                            }
                                            if (arrangement.Contains("rhythm") && !arrangement.Contains("rhythm2"))
                                            {
                                                rhythm = true;
                                                pathExtension += "R";
                                                if (!DD)
                                                    DD = HasDD(arrangement);
                                            }
                                            if (arrangement.Contains("rhythm2"))
                                            {
                                                bonusRhythm = true;
                                                pathExtension = "r";
                                                if (!DD)
                                                    DD = HasDD(arrangement);
                                            }
                                            if (arrangement.Contains("bass") && !arrangement.Contains("bass2"))
                                            {
                                                bass = true;
                                                pathExtension += "B";
                                                if (!DD)
                                                    DD = HasDD(arrangement);
                                            }
                                            if (arrangement.Contains("bass2"))
                                            {
                                                bonusBass = true;
                                                pathExtension += "b";
                                                if (!DD)
                                                    DD = HasDD(arrangement);
                                            }
                                            if (arrangement.Contains("vocals"))
                                            {
                                                vocals = true;
                                                pathExtension += "V";
                                            }
                                        }

                                        //Add layers to big album art
                                        using (Graphics gra = Graphics.FromImage(midAlbumArt))
                                        {
                                            gra.DrawImage(backgroundLayer, 0, 0.5f);
                                            if (vocals)
                                                gra.DrawImage(vocalLayer, 0, 0.5f);
                                            if (bass)
                                                gra.DrawImage(bassLayer, 0, 0.5f);
                                            if (bonusBass)
                                                gra.DrawImage(bassBonusLayer, 0, 0.5f);
                                            if (rhythm)
                                                gra.DrawImage(rhythmLayer, 0, 0.5f);
                                            if (bonusRhythm)
                                                gra.DrawImage(rhythmBonusLayer, 0, 0.5f);
                                            if (lead)
                                                gra.DrawImage(leadLayer, 0, 0.5f);
                                            if (bonusLead)
                                                gra.DrawImage(leadBonusLayer, 0, 0.5f);
                                            gra.DrawImage(customTagLayer, 0, 0.5f);
                                        }

                                        //Draw layers to small album art
                                        using (Graphics gra = Graphics.FromImage(smallAlbumArt))
                                        {
                                            gra.DrawImage(new Bitmap(backgroundLayer, backgroundLayer.Width / 2, backgroundLayer.Height / 2), 0, 1.0f);
                                            if (vocals)
                                                gra.DrawImage(new Bitmap(vocalLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.0f);
                                            if (bass)
                                                gra.DrawImage(new Bitmap(bassLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.0f);
                                            if (bonusBass)
                                                gra.DrawImage(new Bitmap(bassBonusLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.0f);
                                            if (rhythm)
                                                gra.DrawImage(new Bitmap(rhythmLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.0f);
                                            if (bonusRhythm)
                                                gra.DrawImage(new Bitmap(rhythmLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.0f);
                                            if (lead)
                                                gra.DrawImage(new Bitmap(leadLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.0f);
                                            if (bonusLead)
                                                gra.DrawImage(new Bitmap(leadBonusLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.0f);
                                            gra.DrawImage(new Bitmap(customTagLayer, customTagLayer.Width / 2, customTagLayer.Height / 2), 0, 1.0f);
                                        }

                                        //Delete existing album art
                                        if (File.Exists(albumMidArtPath))
                                            File.Delete(albumMidArtPath);

                                        if (File.Exists(albumSmallArtPath))
                                            File.Delete(albumSmallArtPath);

                                        //Save modified album art
                                        midAlbumArt.Save("albumMidArt.png", ImageFormat.Png);

                                        ExternalApps.Png2Dds("albumMidArt.png", albumMidArtPath, 128, 128);
                                        File.Copy("albumMidArt.png", taggedPreviewPath, true);

                                        File.Delete("albumMidArt.png");

                                        smallAlbumArt.Save("albumSmallArt.png", ImageFormat.Png);

                                        ExternalApps.Png2Dds("albumSmallArt.png", albumSmallArtPath, 64, 64);

                                        File.Delete("albumSmallArt.png");

                                        // Delete existing song & repack it
                                        if (File.Exists(songPath))
                                            File.Delete(songPath);

                                        var songVar = SongCollection.FirstOrDefault(sng => sng == songPath);

                                        //Add file name tags if the checkbox is checked
                                        if (checkAddTagsToFileName.Checked)
                                            songPath = songPath.Replace("_p.", pathExtension + "_p.");

                                        Packer.Pack(songExtractedPath, songPath);
                                        File.SetCreationTime(songPath, new DateTime(1990, 1, 1));

                                        counter += 1;
                                        statusLblTagged.Text = "Tagged: " + counter + "/" + songCount;

                                        songVar = songPath;

                                        string songAndFolderPath = new FileInfo(songPath).Directory.FullName.Replace(tbRSPath.Text + @"\", "").Replace(tbRSPath.Text, "");
                                        string fileName = Path.GetFileName(songPath);

                                        songPath = Path.Combine(songAndFolderPath, fileName);

                                        song.Cells["colTagged"].Value = "Yes";
                                        song.Cells["colPath"].Value = songPath;

                                        //Delete extracted folders if needed
                                        if (checkDeleteExtractedOnDone.Checked)
                                            Directory.Delete(songExtractedPath, true);
                                    }
                                    else
                                    {
                                        Directory.Delete(songExtractedPath, true);
                                        songCount -= 1;
                                    }
                                }
                            }
                        }
                        if (counter > 0 && songCount > 0)
                        {
                            MessageBox.Show("Tagging finished!", "Done");
                            statusLblTagged.Text = "Tagging finished!";
                        }
                    };
                    bgWorker.RunWorkerAsync();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Make sure that you have all required files in the app folder: \n" +
                                "-nvdxt.exe \n" +
                                "-Newtonsoft.Json.dll \n" +
                                "-RocksmithTookitLib.dll \n" +
                                "-X360.dll \n" +
                                "-zlib.net.dll \n" +
                                "-MiscUtil.dll \n" +
                                "-tags/" + tagsFolder + "/Background.png \n" +
                                "-tags/" + tagsFolder + "/Lead.png \n" +
                                "-tags/" + tagsFolder + "/Lead Bonus.png \n" +
                                "-tags/" + tagsFolder + "/Rhythm.png \n" +
                                "-tags/" + tagsFolder + "/Rhythm Bonus.png \n" +
                                "-tags/" + tagsFolder + "/Custom.png \n" +
                                "-tags/" + tagsFolder + "/Vocal.png");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: \n\n" + ex.Message.ToString(), "IO Error");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void btnSelectAllNone_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSongs.Rows)
            {
                row.Cells["colSelect"].Value = !allSelected;
            }
            allSelected = !allSelected;
        }

        private void btnLoadSongs_Click(object sender, EventArgs e)
        {
            dgvSongs.Rows.Clear();
            LoadSongs();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dgvSongs.Rows.Clear();
            LoadSongs(tbSearch.Text);
        }

        private void btnRemoveTags_Click(object sender, EventArgs e)
        {
            int counter = 0;

            try
            {
                if (DirOK())
                {
                    bgWorker = new BackgroundWorker();
                    bgWorker.DoWork += delegate
                    {
                        dgvSongs.InvokeIfRequired(delegate
                        {
                            songCount = dgvSongs.Rows.Cast<DataGridViewRow>().Where(row => (Convert.ToBoolean(row.Cells["colSelect"].Value) || row.Selected) && row.Cells["colTagged"].Value.ToString() == "Yes").ToList().Count();
                        });

                        statusStripMain.InvokeIfRequired(delegate
                        {
                            statusLblTagged.Text = "Tags removed on: 0/" + songCount;
                        });

                        foreach (DataGridViewRow song in dgvSongs.Rows)
                        {
                            if (((Convert.ToBoolean(song.Cells["colSelect"].Value)) || song.Selected) && song.Cells["colTagged"].Value.ToString() == "Yes")
                            {
                                string songPath = Path.Combine(tbRSPath.Text, song.Cells["colPath"].Value.ToString());

                                songExtractedPath = Path.Combine(tbWorkingFolderPath.Text, Path.GetFileName(songPath.Replace(".psarc", "_Pc")));
                                manifestsFolderPath = Path.Combine(songExtractedPath, "manifests");
                                albumArtFolderPath = Path.Combine(songExtractedPath, "gfxassets", "album_art");
                                toolkitVersionFilePath = Path.Combine(songExtractedPath, "toolkit.version");
                                taggedPreviewPath = Path.Combine(tbWorkingFolderPath.Text, "previews", Path.GetFileName(songPath.Replace("_p.psarc", "")) + "_tagged.png");

                                Packer.Unpack(songPath, tbWorkingFolderPath.Text);

                                if (File.Exists(toolkitVersionFilePath))
                                {
                                    albumSmallArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*64.dds").ToList()[0];
                                    albumMidArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*128.dds").ToList()[0];
                                    albumBigArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*256.dds").ToList()[0];

                                    albumArtDDS = new DDSImage(File.ReadAllBytes(albumBigArtPath));
                                    bigAlbumArt = albumArtDDS.images[0];

                                    midAlbumArt = ResizeImage(bigAlbumArt, 128, 128);
                                    smallAlbumArt = ResizeImage(bigAlbumArt, 64, 64);

                                    //Delete existing album art
                                    if (File.Exists(albumMidArtPath))
                                        File.Delete(albumMidArtPath);

                                    if (File.Exists(albumSmallArtPath))
                                        File.Delete(albumSmallArtPath);

                                    //Save modified album art
                                    albumArtDDS.images[0] = midAlbumArt;
                                    albumArtDDS.images[0].Save("albumMidArt.png", ImageFormat.Png);

                                    ExternalApps.Png2Dds("albumMidArt.png", albumMidArtPath, 128, 128);

                                    if (!Directory.Exists(Path.Combine(tbWorkingFolderPath.Text, "previews")))
                                        Directory.CreateDirectory(Path.Combine(tbWorkingFolderPath.Text, "previews"));
                                    File.Copy("albumMidArt.png", taggedPreviewPath, true);
                                    File.Delete("albumMidArt.png");

                                    albumArtDDS.images[0] = smallAlbumArt;
                                    albumArtDDS.images[0].Save("albumSmallArt.png", ImageFormat.Png);

                                    ExternalApps.Png2Dds("albumSmallArt.png", albumSmallArtPath, 64, 64);

                                    File.Delete("albumSmallArt.png");

                                    //Delete existing song & repack it
                                    if (File.Exists(songPath))
                                        File.Delete(songPath);

                                    var songVar = SongCollection.FirstOrDefault(sng => sng == songPath);

                                    //Replace arrangement tags in file name, if they exist
                                    string[] split = songPath.Split('_');
                                    foreach (string part in split)
                                    {
                                        if (!part.Except("LlVvBbRr-").Any())
                                        {
                                            songPath = songPath.Replace(part, "-").Replace("_-", "").Replace("-_p.psarc", "_p.psarc");
                                        }
                                    }

                                    //Just in case that the changes don't go too well, remove "-" again
                                    if (songPath.EndsWith("-_p.psarc"))
                                        songPath = songPath.Replace("-_p.psarc", "_p.psarc");

                                    if (songPath.EndsWith("-_p.disabled.psarc"))
                                        songPath = songPath.Replace("-_p.disabled.psarc", "_p.disabled.psarc");

                                    Packer.Pack(songExtractedPath, songPath);
                                    File.SetCreationTime(songPath, DateTime.Now);

                                    counter += 1;
                                    statusLblTagged.Text = "Tags removed on: " + counter + "/" + songCount;
                                    songVar = songPath;

                                    string songAndFolderPath = new FileInfo(songPath).Directory.FullName.Replace(tbRSPath.Text + @"\", "").Replace(tbRSPath.Text, "");
                                    string fileName = Path.GetFileName(songPath);
                                    songPath = Path.Combine(songAndFolderPath, fileName);

                                    song.Cells["colTagged"].Value = "No";
                                    song.Cells["colPath"].Value = songPath;

                                    //Delete extracted folders if needed
                                    if (checkDeleteExtractedOnDone.Checked)
                                        Directory.Delete(songExtractedPath, true);
                                }
                                else
                                    songCount -= 1;
                            }
                        }
                        if (counter > 0 && songCount > 0)
                        {
                            MessageBox.Show("Removing tags finished!", "Done");
                            statusLblTagged.Text = "Removing tags finished!";
                        }
                    };
                    bgWorker.RunWorkerAsync();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Make sure that you have all required files in the app folder: \n" +
                                "-nvdxt.exe \n" +
                                "-Newtonsoft.Json.dll \n" +
                                "-RocksmithTookitLib.dll \n" +
                                "-X360.dll \n" +
                                "-zlib.net.dll \n" +
                                "-MiscUtil.dll \n" +
                                "-tags/" + tagsFolder + "/Background.png \n" +
                                "-tags/" + tagsFolder + "/Lead.png \n" +
                                "-tags/" + tagsFolder + "/Lead Bonus.png \n" +
                                "-tags/" + tagsFolder + "/Rhythm.png \n" +
                                "-tags/" + tagsFolder + "/Rhythm Bonus.png \n" +
                                "-tags/" + tagsFolder + "/Custom.png \n" +
                                "-tags/" + tagsFolder + "/Vocal.png");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error: \n\n" + ex.Message.ToString(), "IO Error");
            }
        }

        private void dgvSongs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSongs.SelectedRows.Count > 0)
            {
                string taggedPreviewPath = Path.Combine(tbWorkingFolderPath.Text, "previews", dgvSongs.SelectedRows[0].Cells["colPath"].Value.ToString().Replace("dlc\\", "").Replace("_p.psarc", "") + "_tagged.png");
                string cleanPreviewPath = taggedPreviewPath.Replace("_tagged", "_clean");

                if (File.Exists(taggedPreviewPath))
                {
                    using (FileStream fs = new FileStream(taggedPreviewPath, FileMode.Open))
                    {
                        pictureBoxPreview.Image = Image.FromStream(fs);
                    }
                }
                else if (File.Exists(cleanPreviewPath))
                {
                    using (FileStream fs = new FileStream(cleanPreviewPath, FileMode.Open))
                    {
                        pictureBoxPreview.Image = Image.FromStream(fs);
                    }
                }
                else
                {
                    if (stopWatch.Elapsed.Seconds < 1)
                    {
                        try
                        {
                            if (DirOK())
                            {
                                ThreadPool.QueueUserWorkItem(delegate
                                  {
                                      string songPath = Path.Combine(tbRSPath.Text, dgvSongs.SelectedRows[0].Cells["colPath"].Value.ToString());

                                      songExtractedPath = Path.Combine(tbWorkingFolderPath.Text, Path.GetFileName(songPath.Replace(".psarc", "_Pc")));
                                      manifestsFolderPath = Path.Combine(songExtractedPath, "manifests");
                                      albumArtFolderPath = Path.Combine(songExtractedPath, "gfxassets", "album_art");
                                      toolkitVersionFilePath = Path.Combine(songExtractedPath, "toolkit.version");
                                      cleanPreviewPath = Path.Combine(tbWorkingFolderPath.Text, "previews", Path.GetFileName(songPath.Replace("_p.psarc", "")) + "_clean.png");

                                      try
                                      {
                                          if (Directory.Exists(songExtractedPath))
                                          {
                                              ClearDirectory(songExtractedPath);
                                              Directory.Delete(songExtractedPath, true);
                                          }
                                          Packer.Unpack(songPath, tbWorkingFolderPath.Text);
                                      }
                                      catch (IOException ex)
                                      {
                                          MessageBox.Show(ex.Message.ToString(), "Extracting error");
                                      }

                                      if (File.Exists(toolkitVersionFilePath))
                                      {
                                          albumMidArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*128.dds").ToList()[0];
                                          albumBigArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*256.dds").ToList()[0];

                                          albumArtDDS = new DDSImage(File.ReadAllBytes(albumBigArtPath));
                                          bigAlbumArt = albumArtDDS.images[0];

                                          midAlbumArt = ResizeImage(bigAlbumArt, 128, 128);

                                          if (File.Exists(cleanPreviewPath))
                                              File.Delete(cleanPreviewPath);
                                          if (!Directory.Exists(Path.Combine(tbWorkingFolderPath.Text, "previews")))
                                              Directory.CreateDirectory(Path.Combine(tbWorkingFolderPath.Text, "previews"));

                                          var imgToSave = midAlbumArt;
                                          imgToSave.Save(cleanPreviewPath, ImageFormat.Png);

                                          pictureBoxPreview.Image = midAlbumArt;

                                          if (checkDeleteExtractedOnDone.Checked)
                                          {
                                              if (Directory.Exists(songExtractedPath))
                                              {
                                                  ClearDirectory(songExtractedPath);
                                                  Directory.Delete(songExtractedPath, true);
                                              }
                                          }
                                      }
                                      else
                                      {
                                          if (Directory.Exists(songExtractedPath))
                                          {
                                              ClearDirectory(songExtractedPath);
                                              Directory.Delete(songExtractedPath, true);
                                          }
                                      }
                                  });
                            }
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Error: \n\n" + ex.Message.ToString(), "IO Error");
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Make sure that you have all required files in the app folder: \n" +
                                            "-nvdxt.exe \n" +
                                            "-Newtonsoft.Json.dll \n" +
                                            "-RocksmithTookitLib.dll \n" +
                                            "-X360.dll \n" +
                                            "-zlib.net.dll \n" +
                                            "-MiscUtil.dll \n" +
                                            "-tags/" + tagsFolder + "/Background.png \n" +
                                            "-tags/" + tagsFolder + "/Lead.png \n" +
                                            "-tags/" + tagsFolder + "/Lead Bonus.png \n" +
                                            "-tags/" + tagsFolder + "/Rhythm.png \n" +
                                            "-tags/" + tagsFolder + "/Rhythm Bonus.png \n" +
                                            "-tags/" + tagsFolder + "/Custom.png \n" +
                                            "-tags/" + tagsFolder + "/Vocal.png");

                        }
                    }
                }
            }
        }

        private void btnShowPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (DirOK())
                {
                    bgWorker = new BackgroundWorker();
                    bgWorker.DoWork += delegate
                    {
                        Bitmap backgroundLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Background.png"));
                        Bitmap customTagLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Custom.png"));
                        Bitmap vocalLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Vocal.png"));
                        Bitmap leadLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Lead.png"));
                        Bitmap rhythmLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Rhythm.png"));
                        Bitmap bassLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Bass.png"));
                        Bitmap leadBonusLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Lead Bonus.png"));
                        Bitmap rhythmBonusLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Rhythm Bonus.png"));
                        Bitmap bassBonusLayer = new Bitmap(Path.Combine("tags", tagsFolder, "Bass Bonus.png"));

                        string songPath = Path.Combine(tbRSPath.Text, dgvSongs.SelectedRows[0].Cells["colPath"].Value.ToString());

                        songExtractedPath = Path.Combine(tbWorkingFolderPath.Text, Path.GetFileName(songPath.Replace(".psarc", "_Pc")));
                        manifestsFolderPath = Path.Combine(songExtractedPath, "manifests");
                        albumArtFolderPath = Path.Combine(songExtractedPath, "gfxassets", "album_art");
                        toolkitVersionFilePath = Path.Combine(songExtractedPath, "toolkit.version");

                        Packer.Unpack(songPath, tbWorkingFolderPath.Text);

                        if (File.Exists(toolkitVersionFilePath))
                        {
                            albumBigArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*256.dds").ToList()[0];

                            albumArtDDS = new DDSImage(File.ReadAllBytes(albumBigArtPath));
                            midAlbumArt = ResizeImage(albumArtDDS.images[0], 128, 128);

                            lead = false;
                            rhythm = false;
                            bass = false;
                            vocals = false;
                            bonusLead = false;
                            bonusRhythm = false;
                            bonusBass = false;

                            var arrangements = Directory.EnumerateFiles(manifestsFolderPath, "*.json", SearchOption.AllDirectories);

                            foreach (string arrangement in arrangements)
                            {
                                if (arrangement.Contains("lead") && !arrangement.Contains("lead2"))
                                    lead = true;
                                if (arrangement.Contains("lead2"))
                                    bonusLead = true;
                                if (arrangement.Contains("rhythm") && !arrangement.Contains("rhythm2"))
                                    rhythm = true;
                                if (arrangement.Contains("rhythm2"))
                                    bonusRhythm = true;
                                if (arrangement.Contains("bass") && !arrangement.Contains("bass2"))
                                    bass = true;
                                if (arrangement.Contains("bass2"))
                                    bonusBass = true;
                                if (arrangement.Contains("vocals"))
                                    vocals = true;
                            }

                            using (Graphics gra = Graphics.FromImage(midAlbumArt))
                            {
                                gra.DrawImage(backgroundLayer, 0, 0.5f);
                                if (vocals)
                                    gra.DrawImage(vocalLayer, 0, 0.5f);
                                if (bass)
                                    gra.DrawImage(bassLayer, 0, 0.5f);
                                if (bonusBass)
                                    gra.DrawImage(bassBonusLayer, 0, 0.5f);
                                if (rhythm)
                                    gra.DrawImage(rhythmLayer, 0, 0.5f);
                                if (bonusRhythm)
                                    gra.DrawImage(rhythmBonusLayer, 0, 0.5f);
                                if (lead)
                                    gra.DrawImage(leadLayer, 0, 0.5f);
                                if (bonusLead)
                                    gra.DrawImage(leadBonusLayer, 0, 0.5f);
                                gra.DrawImage(customTagLayer, 0, 0.5f);
                            }

                            pictureBoxPreview.Image = midAlbumArt;
                        }
                        //Clear dirs
                        Directory.Delete(songExtractedPath, true);
                    };
                    bgWorker.RunWorkerAsync();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Make sure that you have all required files in the app folder: \n" +
                                "-nvdxt.exe \n" +
                                "-Newtonsoft.Json.dll \n" +
                                "-RocksmithTookitLib.dll \n" +
                                "-X360.dll \n" +
                                "-zlib.net.dll \n" +
                                "-MiscUtil.dll \n" +
                                "-tags/" + tagsFolder + "/Background.png \n" +
                                "-tags/" + tagsFolder + "/Lead.png \n" +
                                "-tags/" + tagsFolder + "/Lead Bonus.png \n" +
                                "-tags/" + tagsFolder + "/Rhythm.png \n" +
                                "-tags/" + tagsFolder + "/Rhythm Bonus.png \n" +
                                "-tags/" + tagsFolder + "/Custom.png \n" +
                                "-tags/" + tagsFolder + "/Vocal.png");
            }
        }

        private void comboTagPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string packName = comboTagPacks.SelectedItem.ToString();
            string packFolder = Path.Combine("tags", packName);
            string preview = Path.Combine("tags", packName + "prev_tagged.png");
            string info = Path.Combine("tags", packName, "info.txt");

            if (Directory.Exists(packFolder))
            {
                tagsFolder = packFolder.Replace(@"tags\", "");

                if (File.Exists(preview))
                {
                    pictureBoxPreview.Image = Bitmap.FromFile(preview);
                }

                if (File.Exists(info))
                    tbThemeLegend.Text = File.ReadAllText(info);
            }
        }

        private void btnSavePreview_Click(object sender, EventArgs e)
        {
            if (sfdPreview.ShowDialog() == DialogResult.OK)
            {
                Image preview = pictureBoxPreview.Image;
                preview.Save(sfdPreview.FileName);
            }
        }

        private void dgvSongs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                stopWatch.Start();
        }

        private void dgvSongs_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                stopWatch.Reset();
        }
    }
}
