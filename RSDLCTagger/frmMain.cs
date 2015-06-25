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

namespace RSDLCTagger
{
    public partial class frmMain : Form
    {
        private Settings mySettings;

        public frmMain()
        {
            InitializeComponent();

            mySettings = new Settings();

            LoadSettings();
            LoadSongs();

            if (tbWorkingFolderPath.Text == "")
                tbWorkingFolderPath.Text = Environment.CurrentDirectory;
        }

        public void LoadSongs()
        {
            if (DirOK())
            {
                string[] songs = Directory.GetFiles(Path.Combine(tbRSPath.Text, "dlc"), "*_p.*psarc", SearchOption.AllDirectories);
                foreach (string song in songs)
                {
                    if (song.LastIndexOf("-") == song.LastIndexOf("_p.") - 1)
                        dgvSongs.Rows.Add(false, "Yes", song);
                    else
                        dgvSongs.Rows.Add(false, "No", song);
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
            int counter = 0;
            int songCount = 0;

            string songExtractedPath = "";
            string manifestsFolderPath = "";
            string toolkitVersionFilePath = "";
            string albumArtFolderPath = "";
            string albumSmallArtPath = "";
            string albumBigArtPath = "";
            string pathExtension = "_";

            bool lead = false;
            bool rhythm = false;
            bool bass = false;
            bool vocals = false;
            bool bonusLead = false;
            bool bonusRhythm = false;
            bool bonusBass = false;

            Bitmap bigAlbumArt;
            Bitmap smallAlbumArt;
            DDSImage albumArtDDS;
            try
            {
                Bitmap customTagLayer = new Bitmap("tags/Custom.png");
                Bitmap vocalLayer = new Bitmap("tags/Vocal.png");
                Bitmap leadLayer = new Bitmap("tags/Lead.png");
                Bitmap rhythmLayer = new Bitmap("tags/Rhythm.png");
                Bitmap bassLayer = new Bitmap("tags/Bass.png");
                Bitmap leadBonusLayer = new Bitmap("tags/Lead Bonus.png");
                Bitmap rhythmBonusLayer = new Bitmap("tags/Rhythm Bonus.png");
                Bitmap bassBonusLayer = new Bitmap("tags/Bass Bonus.png");

                if (DirOK())
                {

                    bgWorker = new BackgroundWorker();
                    bgWorker.DoWork += delegate
                    {
                        dgvSongs.InvokeIfRequired(delegate
                        {
                            songCount = dgvSongs.Rows.Cast<DataGridViewRow>().Where(row => (Convert.ToBoolean(row.Cells["colSelect"].Value) || row.Selected) && row.Cells["colTagged"].Value.ToString() == "No").ToList().Count();
                        });

                        statusStripMain.InvokeIfRequired(delegate
                        {
                            statusLblTagged.Text = "Tagged: 0/" + songCount;
                        });

                        foreach (DataGridViewRow song in dgvSongs.Rows)
                        {
                            if (((Convert.ToBoolean(song.Cells["colSelect"].Value)) || song.Selected) && song.Cells["colTagged"].Value.ToString() == "No")
                            {
                                string songPath = song.Cells["colPath"].Value.ToString();

                                songExtractedPath = Path.Combine(tbWorkingFolderPath.Text, Path.GetFileName(songPath.Replace(".psarc", "_Pc")));
                                manifestsFolderPath = Path.Combine(songExtractedPath, "manifests");
                                albumArtFolderPath = Path.Combine(songExtractedPath, "gfxassets", "album_art");
                                toolkitVersionFilePath = Path.Combine(songExtractedPath, "toolkit.version");

                                Packer.Unpack(song.Cells["colPath"].Value.ToString(), tbWorkingFolderPath.Text);

                                if (File.Exists(toolkitVersionFilePath))
                                {
                                    albumSmallArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*64.dds").ToList()[0];
                                    albumBigArtPath = Directory.EnumerateFiles(albumArtFolderPath, "*128.dds").ToList()[0];

                                    albumArtDDS = new DDSImage(File.ReadAllBytes(albumBigArtPath));
                                    bigAlbumArt = albumArtDDS.images[0];

                                    albumArtDDS = new DDSImage(File.ReadAllBytes(albumSmallArtPath));
                                    smallAlbumArt = albumArtDDS.images[0];

                                    //Check which arrangements it contains
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
                                        // arrangement.Substring(arrangement.LastIndexOf("_") + 1, arrangement.Length - arrangement.LastIndexOf(".") + 1);
                                        if (arrangement.Contains("lead"))
                                        {
                                            lead = true;
                                            pathExtension += "L";
                                        }
                                        if (arrangement.Contains("lead2"))
                                        {
                                            bonusLead = true;
                                            pathExtension += "l";
                                        }
                                        if (arrangement.Contains("rhythm"))
                                        {
                                            rhythm = true;
                                            pathExtension += "R";
                                        }
                                        if (arrangement.Contains("rhythm2"))
                                        {
                                            bonusRhythm = true;
                                            pathExtension = "r";
                                        }
                                        if (arrangement.Contains("bass"))
                                        {
                                            bass = true;
                                            pathExtension += "B";
                                        }
                                        if (arrangement.Contains("bass2"))
                                        {
                                            bonusBass = true;
                                            pathExtension += "b";
                                        }
                                        if (arrangement.Contains("vocals"))
                                        {
                                            vocals = true;
                                            pathExtension += "V";
                                        }
                                    }

                                    //Add layers to big album art
                                    using (Graphics gra = Graphics.FromImage(bigAlbumArt))
                                    {
                                        if (vocals)
                                            gra.DrawImage(vocalLayer, 0, 1.5f);
                                        if (bass)
                                            gra.DrawImage(bassLayer, 0, 1.5f);
                                        if (bonusBass)
                                            gra.DrawImage(bassBonusLayer, 0, 1.5f);
                                        if (rhythm)
                                            gra.DrawImage(rhythmLayer, 0, 1.5f);
                                        if (bonusRhythm)
                                            gra.DrawImage(rhythmBonusLayer, 0, 1.5f);
                                        if (lead)
                                            gra.DrawImage(leadLayer, 0, 1.5f);
                                        if (bonusLead)
                                            gra.DrawImage(leadBonusLayer, 0, 1.5f);
                                        gra.DrawImage(customTagLayer, 0, 1.5f);
                                    }

                                    //Draw layers to small album art
                                    using (Graphics gra = Graphics.FromImage(smallAlbumArt))
                                    {
                                        if (vocals)
                                            gra.DrawImage(new Bitmap(vocalLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.5f);
                                        if (bass)
                                            gra.DrawImage(new Bitmap(bassLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.5f);
                                        if (bonusBass)
                                            gra.DrawImage(new Bitmap(bassBonusLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.5f);
                                        if (rhythm)
                                            gra.DrawImage(new Bitmap(rhythmLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.5f);
                                        if (bonusRhythm)
                                            gra.DrawImage(new Bitmap(rhythmLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.5f);
                                        if (lead)
                                            gra.DrawImage(new Bitmap(leadLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.5f);
                                        if (bonusLead)
                                            gra.DrawImage(new Bitmap(leadBonusLayer, vocalLayer.Width / 2, vocalLayer.Height / 2), 0, 1.5f);
                                        gra.DrawImage(new Bitmap(customTagLayer, customTagLayer.Width / 2, customTagLayer.Height / 2), 0, 1.5f);
                                    }

                                    //Delete existing album art
                                    if (File.Exists(albumBigArtPath))
                                        File.Delete(albumBigArtPath);

                                    if (File.Exists(albumSmallArtPath))
                                        File.Delete(albumSmallArtPath);

                                    //Save modified album art
                                    albumArtDDS.images[0] = bigAlbumArt;
                                    albumArtDDS.images[0].Save("albumBigArt.png", ImageFormat.Png);

                                    ExternalApps.Png2Dds("albumBigArt.png", albumBigArtPath, 128, 128);

                                    File.Delete("albumBigArt.png");

                                    albumArtDDS.images[0] = smallAlbumArt;
                                    albumArtDDS.images[0].Save("albumSmallArt.png", ImageFormat.Png);

                                    ExternalApps.Png2Dds("albumSmallArt.png", albumSmallArtPath, 64, 64);

                                    File.Delete("albumSmallArt.png");

                                    // Delete existing song & repack it
                                    if (File.Exists(songPath))
                                        File.Delete(songPath);

                                    Packer.Pack(songExtractedPath, songPath.Replace("_p.", pathExtension + "-_p."));

                                    //Delete extracted folders if needed
                                    try
                                    {
                                        if (checkDeleteExtractedOnDone.Checked)
                                            Directory.Delete(songExtractedPath, true);
                                    }
                                    catch (IOException ex)
                                    {
                                        MessageBox.Show("Error: \n\n" + ex.Message.ToString(), "IO Error");
                                    }

                                    counter += 1;
                                    statusLblTagged.Text = "Tagged: " + counter + "/" + songCount;

                                    song.Cells["colTagged"].Value = "Yes";
                                    song.Cells["colPath"].Value = songPath.Replace("_p.", pathExtension + "-_p.");
                                }
                            }
                        }
                        if (songCount > 0)
                        {
                            MessageBox.Show("Tagging finished!", "Done");
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
                                "-tags/Lead.png \n" +
                                "-tags/Lead Bonus.png \n" +
                                "-tags/Rhythm.png \n" +
                                "-tags/Rhythm Bonus.png \n" +
                                "-tags/Custom.png \n" +
                                "-tags/Vocal.png");
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
                bool selected = Convert.ToBoolean(row.Cells["colSelect"].Value);
                row.Cells["colSelect"].Value = !selected;
            }
        }

        private void btnLoadSongs_Click(object sender, EventArgs e)
        {
            dgvSongs.Rows.Clear();
            LoadSongs();
        }
    }
}
